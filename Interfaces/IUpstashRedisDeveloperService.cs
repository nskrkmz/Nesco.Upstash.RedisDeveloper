namespace Nesco.Upstash.RedisDeveloper
{
    public interface IUpstashRedisDeveloperService
    {
        public Task<RedisDatabase?> CreateDatabaseAsync(IAuthUser authUser, INewRedisDatabaseRequest newRedisDatabaseRequest);
        public Task<RedisDatabase> CreateGlobalDatabaseAsync(IAuthUser authUser, INewGlobalRedisDatabaseRequest newGlobalRedisDatabaseRequest);
        public Task<bool> DeleteDatabaseAsync(IAuthUser authUser, string databaseID);
        public void DeleteDatabase(IAuthUser authUser, string databaseID);
        public Task<RedisDatabase[]> ListDatabasesAsync(IAuthUser authUser);
        public Task<RedisDatabaseDetails> GetDatabaseDetailsAsync(IAuthUser authUser, string databaseID, bool credentials);
        public Task<RedisDatabaseStats> GetDatabaseStatsAsync(IAuthUser authUser, string databaseID);
        public Task<bool> UpdateGlobalDatabaseRegionsAsync(IAuthUser authUser, string databaseID, string[] readRegions);
        public void UpdateGlobalDatabaseRegions(IAuthUser authUser, string databaseID, string[] readRegions);
        public Task<RedisDatabase> ResetPasswordAsync(IAuthUser authUser, string databaseID);
        public Task<RedisDatabase> RenameDatabaseAsync(IAuthUser authUser, string databaseID, string name);
        public Task<bool> EnableTLSAsync(IAuthUser authUser, string databaseID);
        public void EnableTLS(IAuthUser authUser, string databaseID);
        public Task<bool> EnableEvictionAsync(IAuthUser authUser, string databaseID);
        public void EnableEviction(IAuthUser authUser, string databaseID);
        public Task<bool> DisableEvictionAsync(IAuthUser authUser, string databaseID);
        public void DisableEviction(IAuthUser authUser, string databaseID);
        public Task<bool> EnableAutoUpgradeAsync(IAuthUser authUser, string databaseID);
        public void EnableAutoUpgrade(IAuthUser authUser, string databaseID);
        public Task<bool> DisableAutoUpgradeAsync(IAuthUser authUser, string databaseID);
        public void DisableAutoUpgrade(IAuthUser authUser, string databaseID);
        public Task<bool> MoveToTeamAsync(IAuthUser authUser, string teamID, string databaseID);
        public void MoveToTeam(IAuthUser authUser, string teamID, string databaseID);
    }
}
