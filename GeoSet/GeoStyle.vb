Public Class GeoStyle
    Implements IGeoStyle
    Public Property FKGeoSet As Integer
    Public Property Style_id As String
    Public Property color As String
    Public Property scale As Nullable(Of Double)
    Public Property Icon As String
    Public Property hotSpot_x As Nullable(Of Double)
    Public Property hotSpot_y As Nullable(Of Double)
    Public Property hotSpot_xunits As String
    Public Property hotSpot_yunits As String
    Public Property LineStyle_color As String
    Public Property LineStyle_width As Nullable(Of Integer)
    Public Property LabelStyle_scale As Nullable(Of Double)

    Public Overridable Property IGeoFolder As GeoFolder
End Class
