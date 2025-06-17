using System.Diagnostics.Metrics;

namespace TelemetryAndTracing.Metrics
{
    public static class GetCountOfProductMetrics
    {
        public static Meter ProductCounter = new("Product-Couneter", "1.0.0");
        public static Counter<int> CountGetHttpProducts { get; } = ProductCounter.
            CreateCounter<int>("ProductCouneter.Count", "Count the number of get products");
    }
}
