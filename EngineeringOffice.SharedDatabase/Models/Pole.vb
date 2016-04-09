Imports System.Data.Entity.Spatial
Imports EngineeringOffice.SharedDatabase.Models.ValueObjects
Imports ManageOps.SharedKernel

Namespace Models
''' <summary>
''' Represents a customer's order
''' </summary>
    Public Class Pole

        Inherits Entity(Of Pole)

        Protected Sub New(id As Pole)
            MyBase.New(id)
        End Sub

        Public Sub New(poleClass As Poleclass, depth As single)
            PoleClass = poleClass
            Depth = depth
        End Sub

        Public Property PoleClass As PoleClass
        Private Property Depth as Single
        Public Property Location As DbGeography
        Public Property Components As List(Of Component)
        Public Property PoleHoles as new list(Of PoleHole)
        Public Function CircumferenceGroundLine(heightAboveGround As Single) As Single
            CircumferenceGroundLine = PoleClass.CircumferenceSix - (heightAboveGround - 6)*PoleClass.Taper
            Return CircumferenceGroundLine
        End Function
    End Class
End Namespace