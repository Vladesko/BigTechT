namespace Logging.Correlation
{
    internal class CorrelationIdGenerator : ICorrelationIdGenerator
    {
        private string _correlationId = Guid.NewGuid().ToString("D");
        public string Get() => _correlationId;
       

        public void Set(string correlationId) =>
            _correlationId = correlationId;
    }
}
