namespace YouTubePlaylists.Data.Contracts
{
    using System.Data.Entity;
    using YouTubePlaylists.Models;

    public interface IYouTubePlaylistsDbContext
    {
        IDbSet<Category> Categories { get; set; }

        IDbSet<Playlist> Playlists { get; set; }

        IDbSet<Rating> Ratings { get; set; }

        IDbSet<Video> Videos { get; set; }

        int SaveChanges();
    }
}