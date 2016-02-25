namespace YouTubePlaylists.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using YouTubePlaylists.Models;

    public class YouTubePlaylistsDbContext : IdentityDbContext<User>
    {
        public YouTubePlaylistsDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static YouTubePlaylistsDbContext Create()
        {
            return new YouTubePlaylistsDbContext();
        }
    }
}