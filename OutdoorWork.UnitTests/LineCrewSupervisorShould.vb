

Imports EngineeringOffice.SharedDatabase.Models
Imports Ploeh.AutoFixture.Xunit2
Imports Xunit


Public Class CreateACrew

End Class
Public Class Calculator
    Private _number1 As Double
    Private _number2 As Double

    Function Add(number1 As Double, number2 As Double) As Double
        Add = number1 + number2
        _number1 = number1
        _number2 = number2
    End Function
End Class

Public Class FieldNotesShould
    <Fact, AutoData>
    Public Sub OrderMaterial(number1 As Integer, number2 As Integer)
        Dim sut = New Calculator()

        Dim result = sut.Add(number1, number2)

        Assert.Equals(number1 + number2, result)
    End Sub

    <Fact, AutoData>
    Public Sub AssignCrew(a As String, p As Person)
        Assert.IsTrue(True)
    End Sub

    <Fact, InlineAutoData(42), InlineAutoData>
    Public Sub HaveACrew(number1 As Integer, number2 As Integer)
        Dim sut = New Calculator()

        Dim result = sut.Add(number1, number2)

        Assert.Equals(number1 + number2, result)
    End Sub
End Class

