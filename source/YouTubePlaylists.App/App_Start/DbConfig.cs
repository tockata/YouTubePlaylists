namespace YouTubePlaylists.App.App_Start
{
    using System.Data.Entity;
    using YouTubePlaylists.Data;
    using YouTubePlaylists.Data.Migrations;

    public class DbConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<YouTubePlaylistsDbContext, Configuration>());
            YouTubePlaylistsDbContext.Create().Database.Initialize(true);
        }
    }
}