namespace Flafel.Applications.CQRS
{
    public interface IQuery<out TResponse> : IRequest<TResponse> where TResponse : notnull { }
}
