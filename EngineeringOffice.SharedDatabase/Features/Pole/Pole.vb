Imports System.ComponentModel.DataAnnotations
Imports AutoMapper
Imports EngineeringOffice.SharedDatabase.DAL
Imports EngineeringOffice.SharedDatabase.Models
Imports MediatR

Namespace Features.Pole
    Public Class Create
        Public Class Command
            Implements IRequest

            <Display(Name := "Number")>
            Public Property PoleId As Integer
            Public Property Title As String
            Public Property Credits As Integer

            Public Property Department As New PoleClass(height1 := 45, class2 := 1)
        End Class

        Public Class Handler
            Inherits RequestHandler(Of Command)
            Private ReadOnly _db As EngineeringOfficeContext
            Private ReadOnly _mapper As IMapper

            Public Sub New(db As EngineeringOfficeContext, mapper As IMapper)
                _db = db
                _mapper = mapper
            End Sub

            Protected Overrides Sub HandleCore(message As Command)
                Dim pole As Models.Pole = _mapper.Map (Of Command, Models.Pole)(message)

                _db.Poles.Add(pole)
            End Sub
        End Class
    End Class
End Namespace
