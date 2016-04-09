Imports EngineeringOffice.SharedDatabase.Models
Imports EngineeringOffice.SharedDatabase.Models.ValueObjects
Imports Ploeh.AutoFixture.Xunit2
Imports Xunit

<Trait("Category", "Clearance")>
Public Class Assignment
    <Fact(DisplayName:="")>
    <Theory, InlineAutoData(), InlineAutoData(), InlineAutoData(),InlineAutoData()>
    Public Sub AddHoleToPole(pole As Pole, absoluteAngle as Double, elevation As Double, holeDiameter As Double)
        Dim sut = New PoleHole(pole, absoluteAngle,elevation, holeDiameter)
    End Sub
    <Fact(DisplayName:="Offsets")>
    <Theory>
    Public Sub VerifyRadiusAtElevation(poleclass As PoleClass, height As Double, depth As Double, elevation As Double)
        Dim sut1 = New PoleClass(class2 := 1,height1 := 45)
        Dim sut = New Pole(sut1, depth)
        Dim result = sut.CircumferenceGroundLine(12)
        Assert.Equals(15, result)
    End Sub
End Class

