Imports System.Data.Entity
Imports EngineeringOffice.SharedDatabase.DAL
Imports EngineeringOffice.SharedDatabase.Models
Imports Moq
Imports Xunit

<Trait("Category", "DataLayer")>
Public Class QueryTests
    <Fact>
    Public Sub GetAllOffices_orders_by_name()
        Dim data = New List(Of Office)() From {
                New Office("KLH Engineering"),
                New Office("Colvin, Jones, and Davis"),
                New Office("BFA Engineers")
                }.AsQueryable()

        Dim mockSet = New Mock(Of DbSet(Of Office))()
        mockSet.As (Of IQueryable(Of Office))().Setup(Function(m) m.Provider).Returns(data.Provider)
        mockSet.As (Of IQueryable(Of Office))().Setup(Function(m) m.Expression).Returns(data.Expression)
        mockSet.As (Of IQueryable(Of Office))().Setup(Function(m) m.ElementType).Returns(data.ElementType)
        mockSet.As (Of IQueryable(Of Office))().Setup(Function(m) m.GetEnumerator()).Returns(data.GetEnumerator())

        Dim mockContext = New Mock(Of EngineeringOfficeContext)()
        mockContext.Setup(Function(m) m.Offices).Returns(mockSet.Object)

        Dim service = New EngineerOfficeService(mockContext.Object)
        Dim offices = service.GetAllOffices()

        Assert.Equal(3, offices.Count)
        Assert.Equal("KLH Engineering", offices(0).Name)
        Assert.Equal("Colvin, Jones, and Davis", offices(1).Name)
        Assert.Equal("BFA Engineers", offices(2).Name)
    End Sub
End Class