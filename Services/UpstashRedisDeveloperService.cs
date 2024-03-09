using System.Text;
using System.Text.Json;
using System.Net;
using System.Runtime.Serialization;

namespace Nesco.Upstash.RedisDeveloper
{
    public class UpstashRedisDeveloperService : IUpstashRedisDeveloperService
    {
        public async Task<RedisDatabase?> CreateDatabaseAsync(IAuthUser authUser, INewRedisDatabaseRequest newRedisDatabaseRequest)
        {
            return await PostRequestAsync<RedisDatabase, INewRedisDatabaseRequest>(authUser, newRedisDatabaseRequest, "database");
        }
        public async Task<RedisDatabase?> CreateGlobalDatabaseAsync(IAuthUser authUser, INewGlobalRedisDatabaseRequest newGlobalRedisDatabaseRequest)
        {
            return await PostRequestAsync<RedisDatabase, INewGlobalRedisDatabaseRequest>(authUser, newGlobalRedisDatabaseRequest, "database");
        }
        public async Task<bool> DeleteDatabaseAsync(IAuthUser authUser, string id)
        {
            string targetUrl = $"{Consts.UPSTASH_ROOT_URL}/database/{id}";
            string encodedAuthInfo = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes($"{authUser.Email}:{authUser.ApiKey}"));

            using (HttpClient client = new())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + encodedAuthInfo);
                HttpResponseMessage response = await client.DeleteAsync(targetUrl);
                string responseBody = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                else
                    throw new HttpRequestException($"HTTP Request Error: {responseBody}", null, response.StatusCode);
            }
        }
        public void DeleteDatabase(IAuthUser authUser, string id)
        {
            string targetUrl = $"{Consts.UPSTASH_ROOT_URL}/database/{id}";
            string encodedAuthInfo = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes($"{authUser.Email}:{authUser.ApiKey}"));

            using (HttpClient client = new())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + encodedAuthInfo);
                client.DeleteAsync(targetUrl);
            }
        }
        public async Task<RedisDatabase[]?> ListDatabasesAsync(IAuthUser authUser)
        {
            return await GetRequestAsync<RedisDatabase[]>(authUser, "databases");
        }
        public async Task<RedisDatabaseDetails?> GetDatabaseDetailsAsync(IAuthUser authUser, string id, bool hideCredentials)
        {
            string endPoint = hideCredentials ? $"database/{id}" : $"database/{id}?credentials=hide";
            return await GetRequestAsync<RedisDatabaseDetails>(authUser, endPoint);
        }
        public async Task<RedisDatabaseStats?> GetDatabaseStatsAsync(IAuthUser authUser, string id)
        {
            return await GetRequestAsync<RedisDatabaseStats>(authUser, $"stats/{id}");
        }
        public async Task<bool> UpdateGlobalDatabaseRegionsAsync(IAuthUser authUser, string id, string[] readRegions)
        {
            return await PostRequestAsync<bool, string[]>(authUser, readRegions, $"update-regions/{id}");
        }
        public void UpdateGlobalDatabaseRegions(IAuthUser authUser, string id, string[] readRegions)
        {
            PostRequest<string[]>(authUser, readRegions, $"update-regions/{id}");
        }
        public async Task<RedisDatabase?> ResetPasswordAndGetDatabaseAsync(IAuthUser authUser, string id)
        {
            return await PostRequestAsync<RedisDatabase, string>(authUser, null, $"reset-password/{id}");
        }
        public async Task<bool> ResetPasswordAsync(IAuthUser authUser, string id)
        {
            return await PostRequestAsync<bool, string>(authUser, null, $"reset-password/{id}");
        }
        public void ResetPassword(IAuthUser authUser, string id)
        {
            PostRequest<string>(authUser, null, $"reset-password/{id}");
        }
        public async Task<RedisDatabase?> RenameAndGetDatabaseAsync(IAuthUser authUser, string id, string name)
        {
            return await PostRequestAsync<RedisDatabase, string>(authUser, name, $"reset-password/{id}");
        }
        public async Task<bool> RenameDatabaseAsync(IAuthUser authUser, string id, string name)
        {
            return await PostRequestAsync<bool, string>(authUser, name, $"reset-password/{id}");
        }
        public void RenameDatabase(IAuthUser authUser, string id, string name)
        {
            PostRequest<string>(authUser, name, $"reset-password/{id}");
        }
        public async Task<bool> EnableTLSAsync(IAuthUser authUser, string id)
        {
            return await PostRequestAsync<bool, string>(authUser, null, $"enable-tls/{id}");
        }
        public void EnableTLS(IAuthUser authUser, string id)
        {
            PostRequest<string>(authUser, null, $"enable-tls/{id}");
        }
        public async Task<bool> EnableEvictionAsync(IAuthUser authUser, string id)
        {
            return await PostRequestAsync<bool, string>(authUser, null, $"enable-eviction/{id}");
        }
        public void EnableEviction(IAuthUser authUser, string id)
        {
            PostRequest<string>(authUser, null, $"enable-eviction/{id}");
        }
        public async Task<bool> DisableEvictionAsync(IAuthUser authUser, string id)
        {
            return await PostRequestAsync<bool, string>(authUser, null, $"disable-eviction/{id}");
        }
        public void DisableEviction(IAuthUser authUser, string id)
        {
            PostRequest<string>(authUser, null, $"disable-eviction/{id}");
        }
        public async Task<bool> EnableAutoUpgradeAsync(IAuthUser authUser, string id)
        {
            return await PostRequestAsync<bool, string>(authUser, null, $"enable-autoupgrade/{id}");
        }
        public void EnableAutoUpgrade(IAuthUser authUser, string id)
        {
            PostRequest<string>(authUser, null, $"enable-autoupgrade/{id}");
        }
        public async Task<bool> DisableAutoUpgradeAsync(IAuthUser authUser, string id)
        {
            return await PostRequestAsync<bool, string>(authUser, null, $"disable-autoupgrade/{id}");
        }
        public void DisableAutoUpgrade(IAuthUser authUser, string id)
        {
            PostRequest<string>(authUser, null, $"disable-autoupgrade/{id}");
        }
        public async Task<bool> MoveToTeamAsync(IAuthUser authUser, string teamID, string databaseID)
        {
            MoveToTeamData data = new MoveToTeamData
            {
                database_id = databaseID,
                team_id = teamID,
            };
            return await PostRequestAsync<bool, MoveToTeamData>(authUser, data, $"move-to-team");
        }
        public void MoveToTeam(IAuthUser authUser, string teamID, string databaseID)
        {
            MoveToTeamData data = new MoveToTeamData
            {
                database_id = databaseID,
                team_id = teamID,
            };
            PostRequest<MoveToTeamData>(authUser, data, "move-to-team");
        }

        private async Task<T?> GetRequestAsync<T>(IAuthUser authUser, string endPoint)
        {
            string targetUrl = $"{Consts.UPSTASH_ROOT_URL}/{endPoint}";
            string encodedAuthInfo = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes($"{authUser.Email}:{authUser.ApiKey}"));

            using (HttpClient client = new())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + encodedAuthInfo);
                HttpResponseMessage response = await client.GetAsync(targetUrl);
                string responseBody = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    try
                    {
                        return JsonSerializer.Deserialize<T>(responseBody);
                    }
                    catch
                    {
                        throw new SerializationException($"An error occurred while deserializing the HTTP response body:{responseBody}");
                    }
                }
                else
                    throw new HttpRequestException($"HTTP Request Error: {responseBody}", null, response.StatusCode);
            }
        }
        private async Task<T?> PostRequestAsync<T, RB>(IAuthUser authUser, RB? requestBody, string endPoint)
        {
            string targetUrl = $"{Consts.UPSTASH_ROOT_URL}/{endPoint}";
            string encodedAuthInfo = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes($"{authUser.Email}:{authUser.ApiKey}"));

            using (HttpClient client = new())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + encodedAuthInfo);
                HttpResponseMessage response;

                if (requestBody == null)
                    response = await client.PostAsync(targetUrl, null);
                else
                    response = await client.PostAsync(targetUrl, new StringContent(JsonSerializer.Serialize(requestBody)));


                string responseBody = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    if (typeof(T) == typeof(bool))
                        return JsonSerializer.Deserialize<T>(Boolean.TrueString);
                    else
                    {
                        try
                        {
                            return JsonSerializer.Deserialize<T>(responseBody);
                        }
                        catch
                        {
                            throw new SerializationException($"An error occurred while deserializing the HTTP response body:{responseBody}");
                        }
                    }

                }
                else
                    throw new HttpRequestException($"HTTP Request Error: {responseBody}", null, response.StatusCode);
            }
        }
        private void PostRequest<T>(IAuthUser authUser, T? requestBody, string endPoint)
        {
            string targetUrl = $"{Consts.UPSTASH_ROOT_URL}/{endPoint}";
            string encodedAuthInfo = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes($"{authUser.Email}:{authUser.ApiKey}"));

            using (HttpClient client = new())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + encodedAuthInfo);

                if (requestBody == null)
                    client.PostAsync(targetUrl, null);
                else
                    client.PostAsync(targetUrl, new StringContent(JsonSerializer.Serialize(requestBody)));
            }
        }
    }
}