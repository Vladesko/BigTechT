using Application.Abstrations.Messaging;

namespace Application.Interfaces.CachingInterfaces
{
    public interface ICachedQuery
    {
        string Key { get; }
        TimeSpan? Expiration { get; }
    }
    public interface ICachedQuery<TResponce> : IQuery<TResponce>, ICachedQuery;
}
