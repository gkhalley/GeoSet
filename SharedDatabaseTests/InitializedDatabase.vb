Imports Ploeh.AutoFixture.Xunit2
Imports Xunit
Imports EngineeringOffice.SharedDatabase

Public Class FieldNotesShould
    <Fact>
    Public Sub ContextShould()

        Dim sut = New Calculator()

        Dim result = sut.Add(number1, number2)

        Assert.Equal(number1 + number2, result)
    End Sub

    <Fact, AutoData()>
    Public Sub AutoDataTypes(ByVal a As String, ByVal p As Person)
        Assert.True(True)
    End Sub

    <Theory, InlineAutoData(42), InlineAutoData()>
    Public Sub InlineAutoData(ByVal number1 As Integer, ByVal number2 As Integer)
        Dim sut = New Calculator()

        Dim result = sut.Add(number1, number2)

        Assert.Equal(number1 + number2, result)
    End Sub

End Class