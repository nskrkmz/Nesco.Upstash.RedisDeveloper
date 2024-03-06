namespace Nesco.Upstash.RedisDeveloper
{
#pragma warning disable IDE1006 // Naming Styles
    public class RedisDatabaseDetails : RedisDatabase
    {
        public int db_max_clients { get; set; }
        public int db_max_request_size { get; set; }
        public int db_disk_threshold { get; set; }
        public int db_max_entry_size { get; set; }
        public int db_memory_threshold { get; set; }
        public int db_daily_bandwidth_limit { get; set; }
        public int db_max_commands_per_second { get; set; }
        public int db_request_limit { get; set; }
    }
}
