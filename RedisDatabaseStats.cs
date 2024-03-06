namespace Nesco.Upstash.RedisDeveloper
{
#pragma warning disable IDE1006 // Naming Styles
    public class RedisDatabaseStats
    {
        public ConnectionCount? connection_count { get; set; }
        public KeySpace? keyspace { get; set; }
        public Throughput? throughput { get; set; }
        public ProduceThroughput? produce_throughput { get; set; }
        public ConsumeThroughput? consume_throughput { get; set; }
        public DiskUsage? diskusage { get; set; }
        public LatencyMean? latencymean { get; set; }
        public ReadLatencyMean? read_latency_mean { get; set; }
        public ReadLatency99? read_latency_99 { get; set; }
        public WriteLatencyMean? write_latency_mean { get; set; }
        public WriteLatency99? write_latency_99 { get; set; }
        public Hits? hits { get; set; }
        public Misses? misses { get; set; }
        public Read? read { get; set; }
        public Write? write { get; set; }
        public DailyRequests? dailyrequests { get; set; }
        public string[]? days { get; set; }
        public DailyBilling? dailybilling { get; set; }
        /// <summary>
        /// The total daily bandwidth usage (in bytes).
        /// </summary>
        public int dailybandwidth { get; set; }
        public BandWidths? bandwidths { get; set; }
        /// <summary>
        /// Total number of daily produced commands
        /// </summary>
        public int dailyproduce { get; set; }
        /// <summary>
        /// Total number of daily consumed commands
        /// </summary>
        public int dailyconsume { get; set; }
        /// <summary>
        /// The total number of requests made in the current month.
        /// </summary>
        public int total_monthly_requests { get; set; }
        /// <summary>
        /// The total number of read requests made in the current month.
        /// </summary>
        public int total_monthly_read_requests { get; set; }
        /// <summary>
        /// The total number of write requests made in the current month.
        /// </summary>
        public int total_monthly_write_requests { get; set; }
        /// <summary>
        /// The total amount of storage used (in bytes) in the current month.
        /// </summary>
        public int total_monthly_storage { get; set; }
        /// <summary>
        /// Total cost of the database in the current month
        /// </summary>
        public int total_monthly_billing { get; set; }
        /// <summary>
        /// Total number of produce commands in the current month
        /// </summary>
        public int total_monthly_produce { get; set; }
        /// <summary>
        /// Total number of consume commands in the current month
        /// </summary>
        public int total_monthly_consume { get; set; }
    }
}
