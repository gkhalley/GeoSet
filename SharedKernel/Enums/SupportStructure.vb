Namespace Enums
    Public Enum Component
        Pole
        Cabinet
        FaultInterrupter

    End Enum
    Public Enum BaseQuantity
        Length
        Mass
        Time
        ElectricCurrent
        ThermodynamicTemperature
        AmountOfSubstance
        LuminousIntensity
    End Enum
    Public Enum UnitModifier
        Diameter
        Radius
        LineToLine
        LineToPhase
        Quantity
    End Enum
    Public Enum Unit
        Amperes
        Volts
        Watts
        DegF
        WattHours
        Unitless
        Inches
        Feet
        Miles
        Hertz
    End Enum
    Public Enum PoleSpecies
        SouthernPine
        DouglasFir
        WesternRedCedar
    End Enum
    Public Enum StructuralFunction
        SmallAngle = 1
        LargeAngle = 2
        Tangent = 3
        Deadend = 4
        DoubleDeadend = 5
        Band = 6
        Arm = 7
        Brace = 8
        FiberLoop = 9
        Equipment = 10
        Cable = 11
        Conduit = 12
        Wire = 13
        Riser = 14
        JunctionBox = 15
        Guy = 16
        Rack = 17
        Grade = 18
        PadMounted = 19
        PoleTop = 20
        DoubleArms = 21
        Anchor = 22
        RoadCenterline = 23
        PoleGradeLine = 24
    End Enum

    Public Enum PoleClasses
        One = 1
        Two = 2
        Three = 3
        Four = 4
        Five = 5
        H1
    End Enum
    Public Enum TrackingState
        Unchanged = 0
        Added = 1
        Modified = 2
        Deleted = 3
    End Enum
    Public Enum ElectricFunction
        Transformer
        FaultInterrupter
        Switch
        Capacitor
        Regulator
        Meter
        Wire
    End Enum
End Namespace
