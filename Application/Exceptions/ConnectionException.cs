namespace Application.Exceptions
{
    public class ConnectionException : Exception
    {
        public string Name { get; }
        public ConnectionException(string name) : base("Problems with connection string")
        {
            Name = name;
        }
    }
}
