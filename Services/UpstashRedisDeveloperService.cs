using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Data;

namespace Nesco.Upstash.RedisDeveloper
{
    public class UpstashRedisDeveloperService : IUpstashRedisDeveloperService
    {
        public async Task<RedisDatabase?> CreateDatabaseAsync(IAuthUser authUser, INewRedisDatabaseRequest newRedisDatabaseRequest)
        {
            string targetUrl = $"{Consts.UPSTASH_ROOT_URL}/database";
            string encoded = System.Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes($"{authUser.Email}:{authUser.ApiKey}"));

            using (HttpClient client = new())
            {
                //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("email", authUser.AuthInfo);
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + encoded);
                HttpResponseMessage response = await client.PostAsync(targetUrl, new StringContent(JsonSerializer.Serialize(newRedisDatabaseRequest)));
                string responseBody = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return JsonSerializer.Deserialize<RedisDatabase>(responseBody);
                }
                else
                    throw new HttpRequestException($"HTTP Request Error: {responseBody}", null, response.StatusCode);
            }
        }

        public Task<RedisDatabase> CreateGlobalDatabaseAsync(IAuthUser authUser, INewGlobalRedisDatabaseRequest newGlobalRedisDatabaseRequest)
        {
            throw new NotImplementedException();
        }

        public void DeleteDatabase(IAuthUser authUser, string databaseID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteDatabaseAsync(IAuthUser authUser, string databaseID)
        {
            throw new NotImplementedException();
        }

        public void DisableAutoUpgrade(IAuthUser authUser, string databaseID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DisableAutoUpgradeAsync(IAuthUser authUser, string databaseID)
        {
            throw new NotImplementedException();
        }

        public void DisableEviction(IAuthUser authUser, string databaseID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DisableEvictionAsync(IAuthUser authUser, string databaseID)
        {
            throw new NotImplementedException();
        }

        public void EnableAutoUpgrade(IAuthUser authUser, string databaseID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EnableAutoUpgradeAsync(IAuthUser authUser, string databaseID)
        {
            throw new NotImplementedException();
        }

        public void EnableEviction(IAuthUser authUser, string databaseID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EnableEvictionAsync(IAuthUser authUser, string databaseID)
        {
            throw new NotImplementedException();
        }

        public void EnableTLS(IAuthUser authUser, string databaseID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EnableTLSAsync(IAuthUser authUser, string databaseID)
        {
            throw new NotImplementedException();
        }

        public Task<RedisDatabaseDetails> GetDatabaseDetailsAsync(IAuthUser authUser, string databaseID, bool credentials)
        {
            throw new NotImplementedException();
        }

        public Task<RedisDatabaseStats> GetDatabaseStatsAsync(IAuthUser authUser, string databaseID)
        {
            throw new NotImplementedException();
        }

        public Task<RedisDatabase[]> ListDatabasesAsync(IAuthUser authUser)
        {
            throw new NotImplementedException();
        }

        public void MoveToTeam(IAuthUser authUser, string teamID, string databaseID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> MoveToTeamAsync(IAuthUser authUser, string teamID, string databaseID)
        {
            throw new NotImplementedException();
        }

        public Task<RedisDatabase> RenameDatabaseAsync(IAuthUser authUser, string databaseID, string name)
        {
            throw new NotImplementedException();
        }

        public Task<RedisDatabase> ResetPasswordAsync(IAuthUser authUser, string databaseID)
        {
            throw new NotImplementedException();
        }

        public void UpdateGlobalDatabaseRegions(IAuthUser authUser, string databaseID, string[] readRegions)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateGlobalDatabaseRegionsAsync(IAuthUser authUser, string databaseID, string[] readRegions)
        {
            throw new NotImplementedException();
        }
    }
}
