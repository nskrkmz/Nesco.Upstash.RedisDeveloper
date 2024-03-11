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

        public NewGlobalRedisDatabaseRequest(string name, Region region, Region primaryRegion, Region[]? readRegions, bool tls)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            _name = name;

            try
            {
                _region = RegionEndpoints.GetRegionString(region);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message}: {nameof(region)}", ex);
            }

            try
            {
                _primaryRegion = RegionEndpoints.GetRegionString(primaryRegion);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{ex.Message}: {nameof(primaryRegion)}", ex);
            }
            
            if (readRegions != null)
            {
                try
                {
                    List<string> tmpRegions = new List<string>();
                    foreach (Region c_region in readRegions)
                    {
                        tmpRegions.Add(RegionEndpoints.GetRegionString(c_region));
                    }
                    _readRegions = tmpRegions.ToArray();
                }
                catch (ArgumentException ex)
                {
                    throw new ArgumentException($"{ex.Message}: {nameof(readRegions)}", ex);
                }
            }
            _tls = tls;
        }

        public string name { get { return _name; } }
        public string region { get { return _region; } }
        public string primary_region { get { return _primaryRegion; } }
        public string[]? read_regions { get { return _readRegions; } }
        public bool tls { get { return _tls; } }
    }
}
