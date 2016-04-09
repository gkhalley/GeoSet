	Public Class DateTimeRange
		Inherits ValueObject(Of DateTimeRange)

    Public Sub New(start As Date, [end] As Date)
        Guard.ForPrecedesDate(start, [end], "start")
        Me.Start = start
        Me.End = [end]
    End Sub

    Public Sub New(start As Date, duration As TimeSpan)
        Me.New(start, start.Add(duration))
    End Sub

    Protected Sub New()
    End Sub

    Public Property Start As Date
    Public Property [End] As Date

    Public Function DurationInMinutes() As Integer
        Return ([End].Subtract(Start)).Minutes
    End Function
    Public Function NewEnd(ByVal newEndRenamed As Date) As DateTimeRange
        Return New DateTimeRange(Start, newEndRenamed)
    End Function
    Public Function NewDuration(ByVal newDurationRenamed As TimeSpan) As DateTimeRange
        Return New DateTimeRange(Start, newDurationRenamed)
    End Function
    Public Function NewStart(ByVal newStartRenamed As Date) As DateTimeRange
        Return New DateTimeRange(newStartRenamed, [End])
    End Function

    Public Shared Function CreateOneDayRange(day As Date) As DateTimeRange
        Return New DateTimeRange(day, day.AddDays(1))
    End Function
    Public Shared Function CreateOneWeekRange(startDay As Date) As DateTimeRange
        Return New DateTimeRange(startDay, startDay.AddDays(7))
    End Function
    Public Function Overlaps(dateTimeRangeRenamed As DateTimeRange) As Boolean
        Return Start < dateTimeRangeRenamed.End AndAlso [End] > dateTimeRangeRenamed.Start
    End Function
    Protected Overrides Function EqualsCore(other As DateTimeRange) As Boolean
        Throw New NotImplementedException
    End Function

    Protected Overrides Function GetHashCodeCore() As Integer
        Throw New NotImplementedException
    End Function
End Class

