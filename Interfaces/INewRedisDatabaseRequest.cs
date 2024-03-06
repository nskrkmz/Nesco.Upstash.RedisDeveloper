namespace Nesco.Upstash.RedisDeveloper
{
#pragma warning disable IDE1006 // Naming Styles
    public interface INewRedisDatabaseRequest
    {
        public string name { get; }
        public string region { get; }
        public bool tls { get; }
    }
    public class NewRedisDatabaseRequest : INewRedisDatabaseRequest
    {
        private readonly string _name;
        private readonly string _region;
        private readonly bool _tls;

        public NewRedisDatabaseRequest(string name, string region, bool tls)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrEmpty(region))
                throw new ArgumentNullException(nameof(region));

            _name = name;
            _region = region;
            _tls = tls;
        }

        public string name { get { return _name; } }
        public string region { get { return _region; } }
        public bool tls { get { return _tls; } }
    }
}