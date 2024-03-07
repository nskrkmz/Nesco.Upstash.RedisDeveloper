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
            string encodedAuthInfo = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes($"{authUser.Email}:{authUser.ApiKey}"));

            using (HttpClient client = new())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + encodedAuthInfo);
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
        public async Task<RedisDatabase?> CreateGlobalDatabaseAsync(IAuthUser authUser, INewGlobalRedisDatabaseRequest newGlobalRedisDatabaseRequest)
        {
            string targetUrl = $"{Consts.UPSTASH_ROOT_URL}/database";
            string encodedAuthInfo = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes($"{authUser.Email}:{authUser.ApiKey}"));

            using (HttpClient client = new())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + encodedAuthInfo);
                HttpResponseMessage response = await client.PostAsync(targetUrl, new StringContent(JsonSerializer.Serialize(newGlobalRedisDatabaseRequest)));
                string responseBody = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return JsonSerializer.Deserialize<RedisDatabase>(responseBody);
                }
                else
                    throw new HttpRequestException($"HTTP Request Error: {responseBody}", null, response.StatusCode);
            }
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
            string targetUrl = $"{Consts.UPSTASH_ROOT_URL}/databases";
            string encodedAuthInfo = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes($"{authUser.Email}:{authUser.ApiKey}"));

            using (HttpClient client = new())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + encodedAuthInfo);
                HttpResponseMessage response = await client.GetAsync(targetUrl);
                string responseBody = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return JsonSerializer.Deserialize<RedisDatabase[]>(responseBody);
                }
                else
                    throw new HttpRequestException($"HTTP Request Error: {responseBody}", null, response.StatusCode);
            }
        }
        public async Task<RedisDatabaseDetails?> GetDatabaseDetailsAsync(IAuthUser authUser, string id, bool hideCredentials)
        {
            string targetUrl;

            if (hideCredentials)
                targetUrl = $"{Consts.UPSTASH_ROOT_URL}/database/{id}";
            else
                targetUrl = $"{Consts.UPSTASH_ROOT_URL}/database/{id}?credentials=hide";

            string encodedAuthInfo = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes($"{authUser.Email}:{authUser.ApiKey}"));

            using (HttpClient client = new())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + encodedAuthInfo);
                HttpResponseMessage response = await client.GetAsync(targetUrl);
                string responseBody = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return JsonSerializer.Deserialize<RedisDatabaseDetails>(responseBody);
                }
                else
                    throw new HttpRequestException($"HTTP Request Error: {responseBody}", null, response.StatusCode);
            }
        }
        public async Task<RedisDatabaseStats?> GetDatabaseStatsAsync(IAuthUser authUser, string id)
        {
            string targetUrl = $"{Consts.UPSTASH_ROOT_URL}/stats/{id}";


            string encodedAuthInfo = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes($"{authUser.Email}:{authUser.ApiKey}"));

            using (HttpClient client = new())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + encodedAuthInfo);
                HttpResponseMessage response = await client.GetAsync(targetUrl);
                string responseBody = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return JsonSerializer.Deserialize<RedisDatabaseStats>(responseBody);
                }
                else
                    throw new HttpRequestException($"HTTP Request Error: {responseBody}", null, response.StatusCode);
            }
        }
        public async Task<bool> UpdateGlobalDatabaseRegionsAsync(IAuthUser authUser, string id, string[] readRegions)
        {
            string targetUrl = $"{Consts.UPSTASH_ROOT_URL}/update-regions/{id}";
            string encodedAuthInfo = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes($"{authUser.Email}:{authUser.ApiKey}"));

            using (HttpClient client = new())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + encodedAuthInfo);
                HttpResponseMessage response = await client.PostAsync(targetUrl, new StringContent(JsonSerializer.Serialize(readRegions)));
                string responseBody = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                else
                    throw new HttpRequestException($"HTTP Request Error: {responseBody}", null, response.StatusCode);
            }
        }
        public void UpdateGlobalDatabaseRegions(IAuthUser authUser, string id, string[] readRegions)
        {
            string targetUrl = $"{Consts.UPSTASH_ROOT_URL}/update-regions/{id}";
            string encodedAuthInfo = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes($"{authUser.Email}:{authUser.ApiKey}"));

            using (HttpClient client = new())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + encodedAuthInfo);
                client.PostAsync(targetUrl, new StringContent(JsonSerializer.Serialize(readRegions)));
            }
        }
        public async Task<RedisDatabase?> ResetPasswordAndGetDatabaseAsync(IAuthUser authUser, string id)
        {
            string targetUrl = $"{Consts.UPSTASH_ROOT_URL}/reset-password/{id}";
            string encodedAuthInfo = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes($"{authUser.Email}:{authUser.ApiKey}"));

            using (HttpClient client = new())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + encodedAuthInfo);
                HttpResponseMessage response = await client.PostAsync(targetUrl, null);
                string responseBody = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return JsonSerializer.Deserialize<RedisDatabase>(responseBody);
                }
                else
                    throw new HttpRequestException($"HTTP Request Error: {responseBody}", null, response.StatusCode);
            }
        }
        public async Task<bool> ResetPasswordAsync(IAuthUser authUser, string id)
        {
            string targetUrl = $"{Consts.UPSTASH_ROOT_URL}/reset-password/{id}";
            string encodedAuthInfo = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes($"{authUser.Email}:{authUser.ApiKey}"));

            using (HttpClient client = new())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + encodedAuthInfo);
                HttpResponseMessage response = await client.PostAsync(targetUrl, null);
                string responseBody = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                else
                    throw new HttpRequestException($"HTTP Request Error: {responseBody}", null, response.StatusCode);
            }
        }
        public void ResetPassword(IAuthUser authUser, string id)
        {
            string targetUrl = $"{Consts.UPSTASH_ROOT_URL}/reset-password/{id}";
            string encodedAuthInfo = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes($"{authUser.Email}:{authUser.ApiKey}"));

            using (HttpClient client = new())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + encodedAuthInfo);
                client.PostAsync(targetUrl, null);
            }
        }
        public async Task<RedisDatabase?> RenameAndGetDatabaseAsync(IAuthUser authUser, string id, string name)
        {
            string targetUrl = $"{Consts.UPSTASH_ROOT_URL}/reset-password/{id}";
            string encodedAuthInfo = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes($"{authUser.Email}:{authUser.ApiKey}"));

            using (HttpClient client = new())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + encodedAuthInfo);
                HttpResponseMessage response = await client.PostAsync(targetUrl, new StringContent(name));
                string responseBody = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return JsonSerializer.Deserialize<RedisDatabase>(responseBody);
                }
                else
                    throw new HttpRequestException($"HTTP Request Error: {responseBody}", null, response.StatusCode);
            }
        }
        public async Task<bool> RenameDatabaseAsync(IAuthUser authUser, string id, string name)
        {
            string targetUrl = $"{Consts.UPSTASH_ROOT_URL}/reset-password/{id}";
            string encodedAuthInfo = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes($"{authUser.Email}:{authUser.ApiKey}"));

            using (HttpClient client = new())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + encodedAuthInfo);
                HttpResponseMessage response = await client.PostAsync(targetUrl, new StringContent(name));
                string responseBody = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                else
                    throw new HttpRequestException($"HTTP Request Error: {responseBody}", null, response.StatusCode);
            }
        }
        public void RenameDatabase(IAuthUser authUser, string id, string name)
        {
            string targetUrl = $"{Consts.UPSTASH_ROOT_URL}/reset-password/{id}";
            string encodedAuthInfo = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes($"{authUser.Email}:{authUser.ApiKey}"));

            using (HttpClient client = new())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + encodedAuthInfo);
                client.PostAsync(targetUrl, new StringContent(name));
            }
        }
        public async Task<bool> EnableTLSAsync(IAuthUser authUser, string id)
        {
            string targetUrl = $"{Consts.UPSTASH_ROOT_URL}/enable-tls/{id}";
            string encodedAuthInfo = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes($"{authUser.Email}:{authUser.ApiKey}"));

            using (HttpClient client = new())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + encodedAuthInfo);
                HttpResponseMessage response = await client.PostAsync(targetUrl, null);
                string responseBody = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                else
                    throw new HttpRequestException($"HTTP Request Error: {responseBody}", null, response.StatusCode);
            }
        }
        public void EnableTLS(IAuthUser authUser, string id)
        {
            string targetUrl = $"{Consts.UPSTASH_ROOT_URL}/enable-tls/{id}";
            string encodedAuthInfo = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes($"{authUser.Email}:{authUser.ApiKey}"));

            using (HttpClient client = new())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + encodedAuthInfo);
                client.PostAsync(targetUrl, null);
            }
        }
        public async Task<bool> EnableEvictionAsync(IAuthUser authUser, string id)
        {
            string targetUrl = $"{Consts.UPSTASH_ROOT_URL}/enable-eviction/{id}";
            string encodedAuthInfo = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes($"{authUser.Email}:{authUser.ApiKey}"));

            using (HttpClient client = new())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + encodedAuthInfo);
                HttpResponseMessage response = await client.PostAsync(targetUrl, null);
                string responseBody = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                else
                    throw new HttpRequestException($"HTTP Request Error: {responseBody}", null, response.StatusCode);
            }
        }
        public void EnableEviction(IAuthUser authUser, string id)
        {
            string targetUrl = $"{Consts.UPSTASH_ROOT_URL}/enable-eviction/{id}";
            string encodedAuthInfo = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes($"{authUser.Email}:{authUser.ApiKey}"));

            using (HttpClient client = new())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + encodedAuthInfo);
                client.PostAsync(targetUrl, null);
            }
        }
        public async Task<bool> DisableEvictionAsync(IAuthUser authUser, string id)
        {
            string targetUrl = $"{Consts.UPSTASH_ROOT_URL}/disable-eviction/{id}";
            string encodedAuthInfo = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes($"{authUser.Email}:{authUser.ApiKey}"));

            using (HttpClient client = new())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + encodedAuthInfo);
                HttpResponseMessage response = await client.PostAsync(targetUrl, null);
                string responseBody = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                else
                    throw new HttpRequestException($"HTTP Request Error: {responseBody}", null, response.StatusCode);
            }
        }
        public void DisableEviction(IAuthUser authUser, string id)
        {
            string targetUrl = $"{Consts.UPSTASH_ROOT_URL}/disable-eviction/{id}";
            string encodedAuthInfo = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes($"{authUser.Email}:{authUser.ApiKey}"));

            using (HttpClient client = new())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + encodedAuthInfo);
                client.PostAsync(targetUrl, null);
            }
        }
        public async Task<bool> EnableAutoUpgradeAsync(IAuthUser authUser, string id)
        {
            string targetUrl = $"{Consts.UPSTASH_ROOT_URL}/enable-autoupgrade/{id}";
            string encodedAuthInfo = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes($"{authUser.Email}:{authUser.ApiKey}"));

            using (HttpClient client = new())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + encodedAuthInfo);
                HttpResponseMessage response = await client.PostAsync(targetUrl, null);
                string responseBody = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                else
                    throw new HttpRequestException($"HTTP Request Error: {responseBody}", null, response.StatusCode);
            }
        }
        public void EnableAutoUpgrade(IAuthUser authUser, string id)
        {
            string targetUrl = $"{Consts.UPSTASH_ROOT_URL}/enable-autoupgrade/{id}";
            string encodedAuthInfo = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes($"{authUser.Email}:{authUser.ApiKey}"));

            using (HttpClient client = new())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + encodedAuthInfo);
                client.PostAsync(targetUrl, null);
            }
        }
        public async Task<bool> DisableAutoUpgradeAsync(IAuthUser authUser, string id)
        {
            string targetUrl = $"{Consts.UPSTASH_ROOT_URL}/disable-autoupgrade/{id}";
            string encodedAuthInfo = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes($"{authUser.Email}:{authUser.ApiKey}"));

            using (HttpClient client = new())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + encodedAuthInfo);
                HttpResponseMessage response = await client.PostAsync(targetUrl, null);
                string responseBody = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                else
                    throw new HttpRequestException($"HTTP Request Error: {responseBody}", null, response.StatusCode);
            }
        }
        public void DisableAutoUpgrade(IAuthUser authUser, string id)
        {
            string targetUrl = $"{Consts.UPSTASH_ROOT_URL}/disable-autoupgrade/{id}";
            string encodedAuthInfo = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes($"{authUser.Email}:{authUser.ApiKey}"));

            using (HttpClient client = new())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + encodedAuthInfo);
                client.PostAsync(targetUrl, null);
            }
        }
        public async Task<bool> MoveToTeamAsync(IAuthUser authUser, string teamID, string databaseID)
        {
            string targetUrl = $"{Consts.UPSTASH_ROOT_URL}/move-to-team";
            string encodedAuthInfo = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes($"{authUser.Email}:{authUser.ApiKey}"));

            MoveToTeamData data = new MoveToTeamData
            {
                database_id = databaseID,
                team_id = teamID,
            };

            using (HttpClient client = new())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + encodedAuthInfo);
                HttpResponseMessage response = await client.PostAsync(targetUrl, new StringContent(JsonSerializer.Serialize(data)));
                string responseBody = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                else
                    throw new HttpRequestException($"HTTP Request Error: {responseBody}", null, response.StatusCode);
            }
        }
        public void MoveToTeam(IAuthUser authUser, string teamID, string databaseID)
        {
            string targetUrl = $"{Consts.UPSTASH_ROOT_URL}/move-to-team";
            string encodedAuthInfo = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes($"{authUser.Email}:{authUser.ApiKey}"));

            MoveToTeamData data = new MoveToTeamData
            {
                database_id = databaseID,
                team_id = teamID,
            };

            using (HttpClient client = new())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + encodedAuthInfo);
                client.PostAsync(targetUrl, new StringContent(JsonSerializer.Serialize(data)));
            }
        }
    }
}