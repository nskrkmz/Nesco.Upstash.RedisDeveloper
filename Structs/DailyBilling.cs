namespace Nesco.Upstash.RedisDeveloper
{
#pragma warning disable IDE1006 // Naming Styles
    /// <summary>
    /// Represents the billing amount for a specific date along with the timestamp of when the measurement was taken.
    /// </summary>
    public struct DailyBilling
    {
        /// <summary>
        /// Timestamp indicating when the measurement was taken.
        /// </summary>
        public string? x { get; set; }
        /// <summary>
        /// The billing amount for that specific date.
        /// </summary>
        public int y { get; set; }
    }
}