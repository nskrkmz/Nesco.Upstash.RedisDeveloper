namespace Nesco.Upstash.RedisDeveloper
{
#pragma warning disable IDE1006 // Naming Styles
    /// <summary>
    /// Represents a measurement of connection count at a specific timestamp.
    /// </summary>
    public struct ConnectionCount
    {
        /// <summary>
        /// Timestamp indicating when the measurement was taken.
        /// </summary>
        public string? x { get; set; }
        /// <summary>
        /// Total number of connections momentarily
        /// </summary>
        public int y { get; set; }
    }
}