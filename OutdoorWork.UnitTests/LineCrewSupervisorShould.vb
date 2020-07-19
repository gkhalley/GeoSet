

Imports AutoFixture.Xunit2
Imports EngineeringOffice.SharedDatabase.Models
Imports Xunit

Public Class FieldNotesShould
    <Fact, AutoData>
    Public Sub OrderMaterial(number1 As Integer, number2 As Integer)
        Dim sut = New MaterialList()
        Dim result = sut.Add(ItemNumber:=1, Quantity:=1)
        Assert.Equals(number1 + number2, result)
    End Sub

    <Fact, AutoData>
    Public Sub AssignCrew(a As String, p As Person)
        Assert.IsTrue(True)
    End Sub

    <Fact, InlineAutoData(42), InlineAutoData>
    Public Sub HaveACrew(number1 As Integer, number2 As Integer)
        Dim sut = New Crew()

        Dim result = sut.Add(CrewName:="Glen's",CrewSize:=3)

        Assert.Equals(number1 + number2, result)
    End Sub
End Class

Public Class Crew
    Public Function Add(CrewName As String, CrewSize As Integer) As Object
        Throw New NotImplementedException
    End Function
End Class

Public Class MaterialList
    Public Function Add(ItemNumber As Integer, Quantity As Integer) As Object
        Throw New NotImplementedException
    End Function
End Class

