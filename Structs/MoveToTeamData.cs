namespace Nesco.Upstash.RedisDeveloper
{
    internal struct MoveToTeamData
    {
        /// <summary>
        /// The ID of the target team
        /// </summary>
        public string? team_id;
        /// <summary>
        /// The ID of the database to be moved
        /// </summary>
        public string database_id;
    }
}
