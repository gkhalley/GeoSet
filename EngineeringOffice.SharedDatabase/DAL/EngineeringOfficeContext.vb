Imports System.Data.Entity
Imports EngineeringOffice.SharedDatabase.Models

Namespace DAL
    Public Class EngineeringOfficeContext
        Inherits DbContext

        ' Your context has been configured to use a 'EngineeringOfficeContext' connection string from your application's 
        ' configuration file (App.config or Web.config). By default, this connection string targets the 
        ' 'EngineeringOffice.SharedDatabase.EngineeringOfficeContext' database on your LocalDb instance. 
        ' 
        ' If you wish to target a different database and/or database provider, modify the 'EngineeringOfficeContext' 
        ' connection string in the application configuration file.
        Public Sub New()
            MyBase.New("name=EngineeringOfficeContext")
        End Sub

        ' Add a DbSet for each entity type that you want to include in your model. For more information 
        ' on configuring and using a Code First model, see http:'go.microsoft.com/fwlink/?LinkId=390109.
        Public Property Company As DbSet(Of Company)
        Public Property Elevations As DbSet(Of Elevation)
        Public Property MapSets As DbSet(Of MapSet)
        Public Property Offices As DbSet(Of Office)
        Public Property PushPins As DbSet(Of Pushpin)
        Public Property Vertices As DbSet(Of Vertex)
        Public Property WorkAreas As DbSet(Of WorkArea)
        Public Property Poles As DbSet(Of Pole)
        Public Property PoleCalsses As DbSet(Of PoleClass)

        Protected Overrides Sub OnModelCreating(modelbuilder As DbModelBuilder)
            modelbuilder.Entity (Of Pole)().HasMany(Function(d) d.Components).WithOptional(Function(l) l.Pole)
            modelbuilder.Entity (Of Pole).HasRequired(Function(a) a.PoleClass).WithRequiredPrincipal()
        End Sub
    End Class

    Public Class TestInitializerforEngineeringContext
        Inherits DropCreateDatabaseAlways(Of EngineeringOfficeContext)
    End Class
End Namespace