Namespace Models
    Public Class FaultInterrupter
        Public Property Id As Long
        Public Property SubstationId As Long 'Foreign Key 1-M
        Public Property FeederNumber As Integer 'Sequential per Substation
        Public Property TransformerNumber As Integer _
        'Enum: North, East, South, West, Northeast, Southeast, Southwest, Northwest
        Public Property Vertex As Long
        Public Property RatingInterrupt As Integer
        Public Property PickupPhase As Single
        Public Property PickupGround As Single
        Public Property AlarmPhase As Single
    End Class
End Namespace