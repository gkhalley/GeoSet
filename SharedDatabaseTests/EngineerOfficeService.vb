Imports System.Data.Entity
Imports EngineeringOffice.SharedDatabase.DAL
Imports EngineeringOffice.SharedDatabase.Models
Imports Xunit

<Trait("Category", "DataLayer")>
Public Class EngineerOfficeService
    Private ReadOnly _officesShould As OfficesShould = New OfficesShould()
    Private ReadOnly _engineeringOfficeContext As EngineeringOfficeContext

    Sub New(engineeringOfficeContext As EngineeringOfficeContext)
        _engineeringOfficeContext = engineeringOfficeContext
    End Sub

    Public Function AddOffice(name As String) As Office
        Dim office = _engineeringOfficeContext.Offices.Add(New Office(name))
        _engineeringOfficeContext.SaveChanges()
        Return office
    End Function

    Public Function GetAllOffices() As List(Of Office)
        Dim query = From b In _engineeringOfficeContext.Offices
                Order By b.Name
                Select b
        Return query.ToList()
    End Function

    Public Async Function GetAllOfficesAsync() As Task(Of List(Of Office))
        Dim query = From b In _engineeringOfficeContext.Offices
                Order By b.Name
                Select b
        Return Await query.ToListAsync()
    End Function
End Class