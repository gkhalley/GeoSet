
Imports EngineeringOffice.SharedDatabase.Models
Imports Moq
Imports Ploeh.AutoFixture.Xunit2
Imports Xunit
Imports EngineeringOffice.SharedDatabase.DAL

<Trait("Category", "Offices should")>
Public Class OfficesShould
    <Fact, AutoData>
    Public Sub HaveProperType()
        Dim mock = New Mock(Of Office)
        Dim data = New List(Of Office) From {
            New Office("KLH Engineering"),
            New Office("GKH Software")
            }
    End Sub

    <Theory, InlineAutoData(42), InlineAutoData>
    Public Sub InlineAutoData(number1 As Integer, number2 As Integer)
        Dim sut = New Calculator()

        Dim result = sut.Add(number1, number2)

        Assert.Equal(number1 + number2, result)
    End Sub
End Class