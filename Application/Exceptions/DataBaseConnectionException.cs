namespace Application.Exceptions
{
    public sealed class DataBaseConnectionException : ConnectionException
    {
        public DataBaseConnectionException(string name) : base(name)
        {
        }
    }
}
