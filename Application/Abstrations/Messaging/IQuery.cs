using Domain.Abstractions;
using MediatR;

namespace Application.Abstrations.Messaging
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
