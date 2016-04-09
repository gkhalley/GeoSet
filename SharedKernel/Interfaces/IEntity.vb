Namespace Interfaces
' Container of Events (Jimmy Bogart)
    Public Interface IEntity
        ReadOnly Property Events() As ICollection(Of IDomainEvent)
    End Interface
End NameSpace