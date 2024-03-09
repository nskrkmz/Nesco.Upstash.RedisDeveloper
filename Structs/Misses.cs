namespace Nesco.Upstash.RedisDeveloper
{
#pragma warning disable IDE1006 // Naming Styles
    /// <summary>
    /// Represents the total number of requests made to the database that resulted in a miss, along with the timestamp indicating when the measurement was taken.
    /// </summary>
    public struct Misses
    {
        /// <summary>
        /// Timestamp indicating when the measurement was taken.
        /// </summary>
        public string? x { get; set; }
        /// <summary>
        /// Total number requests made to the database that are miss
        /// </summary>
        public int y { get; set; }
    }
}