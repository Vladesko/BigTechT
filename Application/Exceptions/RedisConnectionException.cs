namespace Application.Exceptions
{
    public sealed class RedisConnectionException : ConnectionException
    {
        public RedisConnectionException(string name) : base(name)
        {
            
        }
    }
}
