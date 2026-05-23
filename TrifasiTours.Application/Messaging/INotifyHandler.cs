using MediatR;

namespace TrifasiTours.Application.Messaging;

public interface INotifyHandler<TCommand> : INotificationHandler<TCommand>
where TCommand : INotify {

}
