﻿namespace Nesco.Upstash.RedisDeveloper
{
#pragma warning disable IDE1006 // Naming Styles
    /// <summary>
    /// Represents the average write latency value measured in the last hour, along with the timestamp indicating when the measurement was taken.
    /// </summary>
    public struct WriteLatencyMean
    {
        /// <summary>
        /// Timestamp indicating when the measurement was taken.
        /// </summary>
        public string? x { get; set; }
        /// <summary>
        /// The average write latency value measured in the last hour
        /// </summary>
        public int y { get; set; }
    }
}