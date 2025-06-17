namespace Flafel.Applications.CQRS
{
    public interface ICommand : ICommand<Unit> { }
    public interface ICommand<out TResponse> : IRequest<TResponse> { }
}
