namespace Nesco.Upstash.RedisDeveloper
{
    public interface IUpstashRedisDeveloperService
    {
        /// <summary>
        /// Creates a new Redis database
        /// </summary>
        public Task<RedisDatabase?> CreateDatabaseAsync(IAuthUser authUser, INewRedisDatabaseRequest newRedisDatabaseRequest);
        /// <summary>
        /// creates a new Global Redis database
        /// </summary>
        public Task<RedisDatabase?> CreateGlobalDatabaseAsync(IAuthUser authUser, INewGlobalRedisDatabaseRequest newGlobalRedisDatabaseRequest);
        /// <summary>
        /// deletes a database
        /// </summary>
        public Task<bool> DeleteDatabaseAsync(IAuthUser authUser, string id);
        /// <summary>
        /// deletes a database
        /// </summary>
        public void DeleteDatabase(IAuthUser authUser, string id);
        /// <summary>
        /// list all databases of user
        /// </summary>
        public Task<RedisDatabase[]?> ListDatabasesAsync(IAuthUser authUser);
        /// <summary>
        /// gets details of a database
        /// </summary>
        public Task<RedisDatabaseDetails?> GetDatabaseDetailsAsync(IAuthUser authUser, string id, bool hideCredentials);
        /// <summary>
        /// gets detailed stats of a database
        /// </summary>
        public Task<RedisDatabaseStats?> GetDatabaseStatsAsync(IAuthUser authUser, string id);
        /// <summary>
        /// Update the regions of global database
        /// </summary>
        public Task<bool> UpdateGlobalDatabaseRegionsAsync(IAuthUser authUser, string id, string[] readRegions);
        /// <summary>
        /// Update the regions of global database
        /// </summary>
        public void UpdateGlobalDatabaseRegions(IAuthUser authUser, string id, string[] readRegions);
        /// <summary>
        /// updates the password of a database and returns database
        /// </summary>
        public Task<RedisDatabase?> ResetPasswordAndGetDatabaseAsync(IAuthUser authUser, string id);
        /// <summary>
        /// updates the password of a database
        /// </summary>
        public Task<bool> ResetPasswordAsync(IAuthUser authUser, string id);
        /// <summary>
        /// updates the password of a database
        /// </summary>
        public void ResetPassword(IAuthUser authUser, string id);
        /// <summary>
        /// renames a database and returns database
        /// </summary>
        public Task<RedisDatabase?> RenameAndGetDatabaseAsync(IAuthUser authUser, string id, string name);
        /// <summary>
        /// renames a database
        /// </summary>
        public Task<bool> RenameDatabaseAsync(IAuthUser authUser, string id, string name);
        /// <summary>
        /// renames a database
        /// </summary>
        public void RenameDatabase(IAuthUser authUser, string id, string name);
        /// <summary>
        /// enables tls on a database
        /// </summary>
        public Task<bool> EnableTLSAsync(IAuthUser authUser, string id);
        /// <summary>
        /// enables tls on a database
        /// </summary>
        public void EnableTLS(IAuthUser authUser, string id);
        /// <summary>
        /// enables eviction for given database
        /// </summary>
        public Task<bool> EnableEvictionAsync(IAuthUser authUser, string id);
        /// <summary>
        /// enables eviction for given database
        /// </summary>
        public void EnableEviction(IAuthUser authUser, string id);
        /// <summary>
        /// disables eviction for given database
        /// </summary>
        public Task<bool> DisableEvictionAsync(IAuthUser authUser, string id);
        /// <summary>
        /// disables eviction for given database
        /// </summary>
        public void DisableEviction(IAuthUser authUser, string id);
        /// <summary>
        /// enables Auto Upgrade for given database
        /// </summary>
        public Task<bool> EnableAutoUpgradeAsync(IAuthUser authUser, string id);
        /// <summary>
        /// enables Auto Upgrade for given database
        /// </summary>
        public void EnableAutoUpgrade(IAuthUser authUser, string id);
        /// <summary>
        /// disables Auto Upgrade for given database
        /// </summary>
        public Task<bool> DisableAutoUpgradeAsync(IAuthUser authUser, string id);
        /// <summary>
        /// disables Auto Upgrade for given database
        /// </summary>
        public void DisableAutoUpgrade(IAuthUser authUser, string id);
        /// <summary>
        /// moves database under a target team
        /// </summary>
        public Task<bool> MoveToTeamAsync(IAuthUser authUser, string teamID, string databaseID);
        /// <summary>
        /// moves database under a target team
        /// </summary>
        public void MoveToTeam(IAuthUser authUser, string teamID, string databaseID);
    }
}
