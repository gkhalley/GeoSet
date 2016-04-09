Imports Microsoft.Practices.Unity
Class Application

    ' Application-level events, such as Startup, Exit, and DispatcherUnhandledException
    ' can be handled in this file.
    Protected Overrides Sub OnStartup(ByVal e As StartupEventArgs)
        Dim container As IUnityContainer = New UnityContainer()
        container.RegisterType(Of IStyleMap, StyleMap)()
        container.RegisterType(Of IGeoSet, GeoSet)()
        container.RegisterType(Of IFolder, Folder)()

        Dim mainWindow As MainWindow = container.Resolve(Of MainWindow)()
        mainWindow.Show()
    End Sub
End Class
