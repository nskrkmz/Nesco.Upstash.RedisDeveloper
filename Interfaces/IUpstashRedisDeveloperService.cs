namespace Nesco.Upstash.RedisDeveloper
{
    public interface IUpstashRedisDeveloperService
    {
        public Task<RedisDatabase?> CreateDatabaseAsync(IAuthUser authUser, INewRedisDatabaseRequest newRedisDatabaseRequest);
        public Task<RedisDatabase?> CreateGlobalDatabaseAsync(IAuthUser authUser, INewGlobalRedisDatabaseRequest newGlobalRedisDatabaseRequest);
        public Task<bool> DeleteDatabaseAsync(IAuthUser authUser, string id);
        public void DeleteDatabase(IAuthUser authUser, string id);
        public Task<RedisDatabase[]?> ListDatabasesAsync(IAuthUser authUser);
        public Task<RedisDatabaseDetails?> GetDatabaseDetailsAsync(IAuthUser authUser, string id, bool hideCredentials);
        public Task<RedisDatabaseStats?> GetDatabaseStatsAsync(IAuthUser authUser, string id);
        public Task<bool> UpdateGlobalDatabaseRegionsAsync(IAuthUser authUser, string id, string[] readRegions);
        public void UpdateGlobalDatabaseRegions(IAuthUser authUser, string id, string[] readRegions);
        public Task<RedisDatabase?> ResetPasswordAndGetDatabaseAsync(IAuthUser authUser, string id);
        public Task<bool> ResetPasswordAsync(IAuthUser authUser, string id);
        public void ResetPassword(IAuthUser authUser, string id);
        public Task<RedisDatabase?> RenameAndGetDatabaseAsync(IAuthUser authUser, string id, string name);
        public Task<bool> RenameDatabaseAsync(IAuthUser authUser, string id, string name);
        public void RenameDatabase(IAuthUser authUser, string id, string name);
        public Task<bool> EnableTLSAsync(IAuthUser authUser, string id);
        public void EnableTLS(IAuthUser authUser, string id);
        public Task<bool> EnableEvictionAsync(IAuthUser authUser, string id);
        public void EnableEviction(IAuthUser authUser, string id);
        public Task<bool> DisableEvictionAsync(IAuthUser authUser, string id);
        public void DisableEviction(IAuthUser authUser, string id);
        public Task<bool> EnableAutoUpgradeAsync(IAuthUser authUser, string id);
        public void EnableAutoUpgrade(IAuthUser authUser, string id);
        public Task<bool> DisableAutoUpgradeAsync(IAuthUser authUser, string id);
        public void DisableAutoUpgrade(IAuthUser authUser, string id);
        public Task<bool> MoveToTeamAsync(IAuthUser authUser, string teamID, string databaseID);
        public void MoveToTeam(IAuthUser authUser, string teamID, string databaseID);
    }
}
