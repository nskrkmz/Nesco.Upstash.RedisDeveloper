namespace Nesco.Upstash.RedisDeveloper
{
    public interface IAuthUser
    {
        public string Email { get; }
        public string ApiKey { get; }
    }

    public class AuthUser:IAuthUser
    {
        private readonly string email;
        private readonly string apiKey;

        public AuthUser(string email, string apiKey)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException(nameof(email));
            if (string.IsNullOrEmpty(apiKey))
                throw new ArgumentNullException(nameof(apiKey));

            this.email = email;
            this.apiKey = apiKey;
        }

        public string Email { get { return email; } }
        public string ApiKey { get {  return apiKey; } }
    }
}
