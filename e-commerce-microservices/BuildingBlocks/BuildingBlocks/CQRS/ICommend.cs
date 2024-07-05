using MediatR;

namespace BuildingBlocks.CQRS
{
    public interface ICommend : ICommend<Unit>
    {
    }

    public interface ICommend<out TResponse> : IRequest<TResponse>
    {
    }
}