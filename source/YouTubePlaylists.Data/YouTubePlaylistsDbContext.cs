namespace YouTubePlaylists.Data
{
    using System.Data.Entity;
    using Contracts;
    using Microsoft.AspNet.Identity.EntityFramework;
    using YouTubePlaylists.Models;

    public class YouTubePlaylistsDbContext : IdentityDbContext<User>, IYouTubePlaylistsDbContext
    {
        public YouTubePlaylistsDbContext()
            : base("YouTubePlaylists", throwIfV1Schema: false)
        {
        }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Playlist> Playlists { get; set; }

        public IDbSet<Rating> Ratings { get; set; }

        public IDbSet<Video> Videos { get; set; }

        public static YouTubePlaylistsDbContext Create()
        {
            return new YouTubePlaylistsDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rating>()
                .HasRequired(r => r.Voter)
                .WithMany(u => u.Ratings)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}