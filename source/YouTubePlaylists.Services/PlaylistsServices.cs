﻿namespace YouTubePlaylists.Services
{
    using System.Data.Entity;
    using System.Linq;
    using Contracts;
    using Data.Contracts;
    using Models;

    public class PlaylistsServices : IPlaylistsServices
    {
        private IRepository<Playlist> playlists;

        public PlaylistsServices(IRepository<Playlist> playlists)
        {
            this.playlists = playlists;
        }

        public IQueryable<Playlist> GetTop(int count)
        {
            var playlists = this.playlists.All()
                .Include(p => p.Creator)
                .Include(p => p.Ratings)
                .Include(p => p.Category)
                .Include(p => p.Videos)
                .OrderByDescending(p => p.Ratings.Average(r => r.Value))
                .Take(count);

            return playlists;
        }

        public Playlist GetById(int id)
        {
            return this.playlists.All()
                .Where(p => p.Id == id)
                .Include(p => p.Creator)
                .Include(p => p.Ratings)
                .Include(p => p.Category)
                .Include(p => p.Videos)
                .FirstOrDefault();
        }
    }
}