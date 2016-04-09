Imports System
Imports Systems.Collections.Generic
Imports ManageOps.SharedKernel.Interfaces
Imports Unity

Namespace ManageOps.SharedKernel
    Public NotInheritable Class DomainEvents

        Private Sub New()
        End Sub
        <ThreadStatic>
        Private Shared actions As List(Of System.Delegate)

        Shared Sub New()
            Dim Container = New UnityContainer()
        End Sub

        Public Shared Property Container() As IContainer
        Public Shared Sub Register(Of T As IDomainEvent)(ByVal callback As Action(Of T))
            If actions Is Nothing Then
                actions = New List(Of System.Delegate)()
            End If
            actions.Add(callback)
        End Sub

        Public Shared Sub ClearCallbacks()
            actions = Nothing
        End Sub

        Public Shared Sub Raise(Of T As IDomainEvent)(ByVal args As T)
            For Each handler In Container.GetAllInstances(Of IHandle(Of T))()
                handler.Handle(args)
            Next handler

            If actions IsNot Nothing Then
                For Each action In actions
                    If TypeOf action Is Action(Of T) Then
                        CType(action, Action(Of T))(args)
                    End If
                Next action
            End If
        End Sub
    End Class
End Namespace
