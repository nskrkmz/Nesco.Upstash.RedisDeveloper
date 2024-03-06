namespace Nesco.Upstash.RedisDeveloper
{
#pragma warning disable IDE1006 // Naming Styles
    /// <summary>
    /// Represents the total number of requests made to the database on a corresponding day, along with the timestamp indicating when the measurement was taken.
    /// </summary>
    public struct DailyRequests
    {
        /// <summary>
        /// Timestamp indicating when the measurement was taken.
        /// </summary>
        public string x { get; set; }
        /// <summary>
        /// Total number requests made to the database on the corresponding day
        /// </summary>
        public int y { get; set; }
    }
}