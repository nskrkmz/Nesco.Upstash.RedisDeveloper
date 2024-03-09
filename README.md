This package includes an implementation of the [Upstash Redis Developer API](https://upstash.com/docs/devops/developer-api/redis/).

[API Pool](#api-pool)

# Usage

* add it to your script file before using

```c#
using Nesco.Upstash.RedisDeveloper;
```

* This package requires an instance of IAuthUser interface for all calls.

```c#
IAuthUser authUser = new AuthUser(YOUR_EMAIL, YOUR_API_KEY);
```


<details open>
<summary>Create a Redis Database</summary>

```csharp
    IUpstashRedisDeveloperService redisDeveloperService = new UpstashRedisDeveloperService();
    INewRedisDatabaseRequest databaseRequest = new NewRedisDatabaseRequest(name:"test-db", region:"eu-west-1", tls:true);
    RedisDatabase db = await redisDeveloperService.CreateDatabaseAsync(authUser, newRedisDatabaseRequest);
    /* ===== db includes
    * string? database_id
    * string? database_name
    * string? database_type
    * string? region
    * string? type
    * int port
    * int creation_time
    * int budget
    * string? state
    * string? password
    * string? user_email
    * string? endpoint
    * bool tls
    * bool eviction
    * bool auto_upgrade
    * bool consistent
    * int reserved_per_region_price
    * string? modifying_state
    * string? rest_token
    * string? read_only_rest_token
    */
```
</details>
<details>
<summary>Get detailed stats of a given database</summary>

```c#
    IUpstashRedisDeveloperService redisDeveloperService = new UpstashRedisDeveloperService();
    RedisDatabaseStats dbStats = await redisDeveloperService.GetDatabaseStatsAsync(authUser, db.database_id)
```
</details>

</br>
</br>
</br>
</br>

# API Pool

```C#   
    // Creates a new Redis database
    RedisDatabase? CreateDatabaseAsync(IAuthUser authUser, INewRedisDatabaseRequest newRedisDatabaseRequest)
        
    // creates a new Global Redis database
    RedisDatabase? CreateGlobalDatabaseAsync(IAuthUser authUser, INewGlobalRedisDatabaseRequest newGlobalRedisDatabaseRequest)
        
    // deletes a database
    bool DeleteDatabaseAsync(IAuthUser authUser, string id)
        
    // deletes a database
    void DeleteDatabase(IAuthUser authUser, string id)
        
    // list all databases of user
    RedisDatabase[]? ListDatabasesAsync(IAuthUser authUser)
        
    // gets details of a database
    RedisDatabaseDetails? GetDatabaseDetailsAsync(IAuthUser authUser, string id, bool hideCredentials)
        
    // gets detailed stats of a database
    RedisDatabaseStats? GetDatabaseStatsAsync(IAuthUser authUser, string id)
        
    // Update the regions of global database
    bool UpdateGlobalDatabaseRegionsAsync(IAuthUser authUser, string id, string[] readRegions)
        
    // Update the regions of global database
    void UpdateGlobalDatabaseRegions(IAuthUser authUser, string id, string[] readRegions)
        
    // updates the password of a database and returns database
    RedisDatabase? ResetPasswordAndGetDatabaseAsync(IAuthUser authUser, string id)
        
    // updates the password of a database
    bool ResetPasswordAsync(IAuthUser authUser, string id)
        
    // updates the password of a database
    void ResetPassword(IAuthUser authUser, string id)
        
    // renames a database and returns database
    RedisDatabase? RenameAndGetDatabaseAsync(IAuthUser authUser, string id, string name)
        
    // renames a database
    bool RenameDatabaseAsync(IAuthUser authUser, string id, string name)
        
    // renames a database
    void RenameDatabase(IAuthUser authUser, string id, string name)
        
    // enables tls on a database
    bool EnableTLSAsync(IAuthUser authUser, string id)
        
    // enables tls on a database
    void EnableTLS(IAuthUser authUser, string id)
        
    // enables eviction for given database
    bool EnableEvictionAsync(IAuthUser authUser, string id)
        
    // enables eviction for given database
    void EnableEviction(IAuthUser authUser, string id)
        
    // disables eviction for given database
    bool DisableEvictionAsync(IAuthUser authUser, string id)
        
    // disables eviction for given database
    void DisableEviction(IAuthUser authUser, string id)
        
    // enables Auto Upgrade for given database
    bool EnableAutoUpgradeAsync(IAuthUser authUser, string id)
        
    // enables Auto Upgrade for given database
    void EnableAutoUpgrade(IAuthUser authUser, string id)
        
    // disables Auto Upgrade for given database
    bool DisableAutoUpgradeAsync(IAuthUser authUser, string id)
        
    // disables Auto Upgrade for given database
    void DisableAutoUpgrade(IAuthUser authUser, string id)
        
    // moves database under a target team
    bool MoveToTeamAsync(IAuthUser authUser, string teamID, string databaseID)
        
    // moves database under a target team
    void MoveToTeam(IAuthUser authUser, string teamID, string databaseID)

```