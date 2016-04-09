Imports System.Data.Entity
Imports OutdoorWork.Core.Model.ScheduleAggregate

Namespace OutdoorWork.Data
    Public Class OutdoorWorkContext
        Inherits DbContext

        Public Sub New()
            MyBase.New("name=EngineeringOfficeContext")
        End Sub
        Public Property Companys() As DbSet(Of Company)
        Public Property Elevations() As DbSet(Of Elevation)
        Public Property MapSets() As DbSet(Of MapSet)
        Public Property Nodes() As DbSet(Of Node)
        Public Property Offices() As DbSet(Of Office)
        Public Property WorkAreas() As DbSet(Of WorkArea)

        Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
            modelBuilder.Entity(Of Client)().HasKey(Function(c) c.Id)

            modelBuilder.Entity(Of Appointment)().Ignore(Function(a) a.State)
            modelBuilder.Entity(Of Appointment)().Ignore(Function(a) a.IsPotentiallyConflicting)

            modelBuilder.Entity(Of Schedule)().Ignore(Function(s) s.DateRange)

            MyBase.OnModelCreating(modelBuilder)
        End Sub
    End Class
End Namespace
