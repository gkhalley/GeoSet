Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports EngineeringOffice.SharedDatabase.DAL
Imports EngineeringOffice.SharedDatabase.Models
Imports Moq
Imports Xunit

<Trait("Category", "DataLayer")>
Public Class AsyncQueryTests
    <Fact>
    Public Async Function GetAllOfficesAsync_orders_by_name() As Task

        Dim data = New List(Of Office)() From {
                New Office("BBB"),
                New Office("ZZZ"),
                New Office("AAA")
                }.AsQueryable()

        Dim mockSet = New Mock(Of DbSet(Of Office))()
        mockSet.As (Of IDbAsyncEnumerable(Of Office))().Setup(Function(m) m.GetAsyncEnumerator()).Returns(
            New TestDbAsyncEnumerator(Of Office)(data.GetEnumerator()))

        mockSet.As (Of IQueryable(Of Office))().Setup(Function(m) m.Provider).Returns(
            New TestDbAsyncQueryProvider(Of Office)(data.Provider))

        mockSet.As (Of IQueryable(Of Office))().Setup(Function(m) m.Expression).Returns(data.Expression)
        mockSet.As (Of IQueryable(Of Office))().Setup(Function(m) m.ElementType).Returns(data.ElementType)
        mockSet.As (Of IQueryable(Of Office))().Setup(Function(m) m.GetEnumerator()).Returns(data.GetEnumerator())

        Dim mockContext = New Mock(Of EngineeringOfficeContext)()
        mockContext.Setup(Function(c) c.Offices).Returns(mockSet.Object)

        Dim service = New EngineerOfficeService(mockContext.Object)
        Dim blogs = Await service.GetAllOfficesAsync()

        Assert.Equal(3, blogs.Count)
        Assert.Equal("AAA", blogs(0).Name)
        Assert.Equal("BBB", blogs(1).Name)
        Assert.Equal("ZZZ", blogs(2).Name)
    End Function
End Class
