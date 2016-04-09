Imports System.Data.Entity.Infrastructure
Imports System.Linq.Expressions
Imports System.Threading

Friend Class TestDbAsyncQueryProvider (Of TEntity)
    Implements IDbAsyncQueryProvider

    Private ReadOnly _inner As IQueryProvider

    Friend Sub New(inner As IQueryProvider)
        _inner = inner
    End Sub

    Public Function CreateQuery(expression As Expression) As IQueryable Implements IQueryProvider.CreateQuery
        Return New TestDbAsyncEnumerable(Of TEntity)(expression)
    End Function

    Public Function CreateQuery (Of TElement)(expression As Expression) As IQueryable(Of TElement) _
        Implements IQueryProvider.CreateQuery
        Return New TestDbAsyncEnumerable(Of TElement)(expression)
    End Function

    Public Function Execute(expression As Expression) As Object Implements IQueryProvider.Execute
        Return _inner.Execute(expression)
    End Function

    Public Function Execute (Of TResult)(expression As Expression) As TResult Implements IQueryProvider.Execute
        Return _inner.Execute (Of TResult)(expression)
    End Function

    Public Function ExecuteAsync(expression As Expression, cancellationToken As CancellationToken) As Task(Of Object) _
        Implements IDbAsyncQueryProvider.ExecuteAsync
        Return Task.FromResult(Execute(expression))
    End Function

    Public Function ExecuteAsync (Of TResult)(expression As Expression, cancellationToken As CancellationToken) _
        As Task(Of TResult) Implements IDbAsyncQueryProvider.ExecuteAsync
        Return Task.FromResult(Execute (Of TResult)(expression))
    End Function
End Class

Friend Class TestDbAsyncEnumerable (Of T)
    Inherits EnumerableQuery(Of T)
    Implements IDbAsyncEnumerable(Of T), IQueryable(Of T)

    Public Sub New(enumerable As IEnumerable(Of T))
        MyBase.New(enumerable)
    End Sub

    Public Sub New(expression As Expression)
        MyBase.New(expression)
    End Sub

    Public Function GetAsyncEnumerator() As IDbAsyncEnumerator(Of T) _
        Implements IDbAsyncEnumerable(Of T).GetAsyncEnumerator
        Return New TestDbAsyncEnumerator(Of T)(Me.AsEnumerable().GetEnumerator())
    End Function

    Private ReadOnly Property IQueryable_Provider As IQueryProvider Implements IQueryable.Provider
        Get
            Return New TestDbAsyncQueryProvider(Of T)(Me)
        End Get
    End Property

    Public Function IDbAsyncEnumerable_GetAsyncEnumerator() As IDbAsyncEnumerator _
        Implements IDbAsyncEnumerable.GetAsyncEnumerator
        Return New TestDbAsyncEnumerator(Of T)(Me.AsEnumerable().GetEnumerator())
    End Function
End Class

Friend Class TestDbAsyncEnumerator (Of T)
    Implements IDbAsyncEnumerator(Of T)

    Private ReadOnly _inner As IEnumerator(Of T)

    Public Sub New(inner As IEnumerator(Of T))
        _inner = inner
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        _inner.Dispose()
    End Sub

    Public Function MoveNextAsync(cancellationToken As CancellationToken) As Task(Of Boolean) _
        Implements IDbAsyncEnumerator.MoveNextAsync
        Return Task.FromResult(_inner.MoveNext())
    End Function

    Public ReadOnly Property Current As T Implements IDbAsyncEnumerator(Of T).Current
        Get
            Return _inner.Current
        End Get
    End Property

    Private ReadOnly Property IDbAsyncEnumerator_Current As Object Implements IDbAsyncEnumerator.Current
        Get
            Return Current
        End Get
    End Property
End Class