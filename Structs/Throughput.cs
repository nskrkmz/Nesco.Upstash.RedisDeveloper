namespace Nesco.Upstash.RedisDeveloper
{
#pragma warning disable IDE1006 // Naming Styles
    /// <summary>
    /// Represents the throughput observed on the database connections at a specific timestamp.
    /// </summary>
    public struct Throughput
    {
        /// <summary>
        /// Timestamp indicating when the measurement was taken.
        /// </summary>
        public string x { get; set; }
        /// <summary>
        /// Throughput seen on the database connections
        /// </summary>
        public int y { get; set; }
    }
}