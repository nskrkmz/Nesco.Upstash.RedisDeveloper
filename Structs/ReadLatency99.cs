namespace Nesco.Upstash.RedisDeveloper
{
#pragma warning disable IDE1006 // Naming Styles
    /// <summary>
    /// Represents the 99th percentile server read latency observed in the last hour, along with the timestamp indicating when the measurement was taken.
    /// </summary>
    public struct ReadLatency99
    {
        /// <summary>
        /// Timestamp indicating when the measurement was taken.
        /// </summary>
        public string? x { get; set; }
        /// <summary>
        /// The 99th percentile server read latency observed in the last hour
        /// </summary>
        public int y { get; set; }
    }
}