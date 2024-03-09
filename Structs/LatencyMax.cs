﻿namespace Nesco.Upstash.RedisDeveloper
{
#pragma warning disable IDE1006 // Naming Styles
    /// <summary>
    /// Represents the maximum server latency observed in the last hour, along with the timestamp indicating when the measurement was taken.
    /// </summary>
    public struct LatencyMax
    {
        /// <summary>
        /// Timestamp indicating when the measurement was taken.
        /// </summary>
        public string? x { get; set; }
        /// <summary>
        /// Maximum server latency observed in the last hour
        /// </summary>
        public int y { get; set; }
    }
}