using MediatR;

namespace BuildingBlocks.CQRS
{
    public interface ICommendHandler<in TCommend> : ICommendHandler<TCommend, Unit>
        where TCommend : ICommend<Unit>
    {
    }

    public interface ICommendHandler<in TCommend, TResponse> : IRequestHandler<TCommend, TResponse>
        where TCommend : ICommend<TResponse>
        where TResponse : notnull
    {
    }
}