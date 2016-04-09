Imports ManageOps.SharedKernel.Interfaces

Public MustInherit Class AggregateRoot
    Implements IEntity

    Private ReadOnly _domainEvents As New List(Of IDomainEvent)()

    Protected Sub New()
    End Sub


    Public Overridable ReadOnly Property DomainEvent() As IReadOnlyList(Of IDomainEvent)
        Get
            Return _domainEvents
        End Get
    End Property

    Public Property Events As ICollection(Of IDomainEvent) Implements IEntity.Events
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As ICollection(Of IDomainEvent))
            Throw New NotImplementedException()
        End Set
    End Property

    Protected Overridable Sub AddDomainEvent(ByVal newEvent As IDomainEvent)
        _domainEvents.Add(newEvent)
    End Sub

    Public Overridable Sub ClearEvents()
        _domainEvents.Clear()
    End Sub
End Class

