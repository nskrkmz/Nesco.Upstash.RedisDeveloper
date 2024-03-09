namespace Nesco.Upstash.RedisDeveloper
{
#pragma warning disable IDE1006 // Naming Styles
    /// <summary>
    /// Represents the total amount of disk usage of the database at a specific timestamp.
    /// </summary>
    public struct DiskUsage
    {
        /// <summary>
        /// Timestamp indicating when the measurement was taken.
        /// </summary>
        public string? x { get; set; }
        /// <summary>
        /// Total amount of this usage of the database
        /// </summary>
        public int y { get; set; }
    }
}