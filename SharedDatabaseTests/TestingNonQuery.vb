Imports System.Data.Entity
Imports EngineeringOffice.SharedDatabase.DAL
Imports EngineeringOffice.SharedDatabase.Models
Imports Moq
Imports Xunit

<Trait("Category", "DataLayer")>
Public Class TestingNonQuery
    <Fact(DisplayName := "Set up MOQ")>
    Public Sub CreateOffice_saves_a_office_via_context()
        Dim mockSet = New Mock(Of DbSet(Of Office))()

        Dim mockContext = New Mock(Of EngineeringOfficeContext)
        mockContext.Setup(Function(m) m.Offices).Returns(mockSet.Object)

        Dim service = New EngineerOfficeService(mockContext.Object)
        service.AddOffice("Long Lane")

        mockSet.Verify(Sub(m) m.Add(It.IsAny (Of Office)()), Times.Once())
        mockContext.Verify(Function(m) m.SaveChanges(), Times.Once())
    End Sub
End Class
