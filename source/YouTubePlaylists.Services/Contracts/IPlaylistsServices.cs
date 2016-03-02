namespace YouTubePlaylists.Services.Contracts
{
    using System.Linq;
    using YouTubePlaylists.Models;

    public interface IPlaylistsServices
    {
        IQueryable<Playlist> GetTop(int count);
    }
}