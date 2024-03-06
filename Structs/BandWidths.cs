namespace Nesco.Upstash.RedisDeveloper
{
#pragma warning disable IDE1006 // Naming Styles
    /// <summary>
    /// Represents a measurement of bandwidth size at a specific timestamp.
    /// </summary>
    public struct BandWidths
    {
        /// <summary>
        /// Timestamp indicating when the measurement was taken.
        /// </summary>
        public string x { get; set; }
        /// <summary>
        /// The total bandwidth size for that specific timestamp
        /// </summary>
        public int y { get; set; }
    }
}