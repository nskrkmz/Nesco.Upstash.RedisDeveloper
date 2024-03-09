namespace Nesco.Upstash.RedisDeveloper
{
#pragma warning disable IDE1006 // Naming Styles
    /// <summary>
    /// Represents the total number of keys existing in the database at a specific timestamp.
    /// </summary>
    public struct KeySpace
    {
        /// <summary>
        /// Timestamp indicating when the measurement was taken.
        /// </summary>
        public string? x { get; set; }
        /// <summary>
        /// Total number keys exists in the database
        /// </summary>
        public int y { get; set; }
    }
}