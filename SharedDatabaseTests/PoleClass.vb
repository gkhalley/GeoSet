Imports SharedGeography.Enums

Public Class PoleClass
    Inherits ValueObject(Of PoleClass)
    Public Sub New(circumferenceTop As Single, circumferenceSix As Double)
        Me.CircumferenceTop = circumferenceTop
        Me.CircumferenceSix = circumferenceSix
        Me.Class = PoleClasses.C1
    End Sub
    Public Sub New(height As Double, [class] As PoleClasses, species As String, circumferenceTop As Double, circumferenceSix As Double)
        Me.Height = height
        Me.[Class] = [class]
        Me.Species = species
        Me.CircumferenceTop = circumferenceTop
        Me.CircumferenceSix = circumferenceSix
    End Sub
    Public Property Id As Integer
    Public Property Height As Double
    Public Property [Class] As PoleClasses
    Public Property CircumferenceTop As Single
    Public Property CircumferenceSix As Double
    Public Property Taper As Single
    Public Property Species As String
    Public Property FiberStress As Single

    Public Function CircumferenceGroundLine(heightAboveGround As Double) As Double
        CircumferenceGroundLine = CircumferenceSix - (heightAboveGround - 6) * Taper
        Return CircumferenceGroundLine
    End Function
End Class