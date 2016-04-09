
Imports EngineeringOffice.SharedDatabase.Models
Imports Ploeh.AutoFixture.Xunit2
Imports Xunit

<Trait("Category", "Crews should")>
Public Class CrewShould
    <Fact, AutoData>
    Public Sub AutoDataTypes(a As String, p As Person)
        'Assert.True(True)
    End Sub

    <Theory, InlineAutoData(42), InlineAutoData>
    Public Sub InlineAutoData(number1 As Integer, number2 As Integer)
        Dim sut = New Calculator()

        Dim result = sut.Add(number1, number2)

        Assert.Equal(number1 + number2, result)
    End Sub
End Class

Public Class Calculator
    Function Add(number1 As Integer,number2 as Integer) As Integer
        Add = number1 + number2
    End Function
End Class