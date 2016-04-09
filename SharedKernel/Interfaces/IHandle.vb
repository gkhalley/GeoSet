Namespace Interfaces
    Public Interface IHandle (Of T As IDomainEvent)
        Sub Handle(args As T)
    End Interface
End Namespace