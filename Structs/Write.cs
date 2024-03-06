namespace Nesco.Upstash.RedisDeveloper
{
#pragma warning disable IDE1006 // Naming Styles
    /// <summary>
    /// Represents the total number of write requests made to the database at a specific timestamp.
    /// </summary>
    public struct Write
    {
        /// <summary>
        /// Timestamp indicating when the measurement was taken.
        /// </summary>
        public string x { get; set; }
        /// <summary>
        /// Total number write requests made to the database
        /// </summary>
        public int y { get; set; }
    }
}