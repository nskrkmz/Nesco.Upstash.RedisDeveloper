using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nesco.Upstash.RedisDeveloper
{
#pragma warning disable IDE1006 // Naming Styles
    public class RedisDatabase
    {
        public string? database_id { get; set; }
        public string? database_name { get; set; }
        public string? database_type { get; set; }
        public string? region { get; set; }
        public string? type { get; set; }
        public int port { get; set; }
        public int creation_time { get; set; }
        public int budget { get; set; }
        public string? state { get; set; }
        public string? password { get; set; }
        public string? user_email { get; set; }
        public string? endpoint { get; set; }
        public bool tls { get; set; }
        public bool eviction { get; set; }
        public bool auto_upgrade { get; set; }
        public bool consistent { get; set; }
        public int reserved_per_region_price { get; set; }
        public string? modifying_state { get; set; }
        public string? rest_token { get; set; }
        public string? read_only_rest_token { get; set; }
    }
}
