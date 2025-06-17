using System.Diagnostics;

namespace TelemetryAndTracing.Activities
{
    public static class ActivitieSources
    {
        public static ActivitySource GetProductCounter { get; } = new ActivitySource("BigTechT.ProductCounter");

    }
}
