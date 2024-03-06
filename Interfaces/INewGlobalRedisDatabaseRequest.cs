namespace Nesco.Upstash.RedisDeveloper
{
    public interface INewGlobalRedisDatabaseRequest
    {
        public string name { get; }
        public string region { get; }
        public string primary_region { get; }
        public string[]? read_regions { get; }
        public bool tls { get; }
    }

    public class NewGlobalRedisDatabaseRequest : INewGlobalRedisDatabaseRequest
    {
        private readonly string _name;
        private readonly string _region;
        private readonly string _primaryRegion;
        private readonly string[]? _readRegions;
        private readonly bool _tls;

        public NewGlobalRedisDatabaseRequest(string name, string region, string primaryRegion, string[]? readRegions, bool tls)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrEmpty(region))
                throw new ArgumentNullException(nameof(region));
            if (string.IsNullOrEmpty(primaryRegion))
                throw new ArgumentNullException(nameof(primaryRegion));

            _name = name;
            _region = region;
            _primaryRegion = primaryRegion;
            if (readRegions != null)
                _readRegions = readRegions;

            _tls = tls;
        }

        public string name { get { return _name; } }
        public string region { get { return _region; } }
        public string primary_region { get { return _primaryRegion; } }
        public string[]? read_regions { get { return _readRegions; } }
        public bool tls { get { return _tls; } }
    }
}
