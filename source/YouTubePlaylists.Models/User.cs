namespace YouTubePlaylists.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        private ICollection<Playlist> playlists;
        private ICollection<Rating> ratings;

        public User()
        {
            this.playlists = new HashSet<Playlist>();
            this.ratings = new HashSet<Rating>();
        }

        public ClaimsIdentity GenerateUserIdentity(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            return Task.FromResult(GenerateUserIdentity(manager));
        }

        [Required]
        [MinLength(3)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        public string LastName { get; set; }

        public string ProfileImageUrl { get; set; }

        public string FacebookUrl { get; set; }

        public string GooglePlusUrl { get; set; }

        public string YouTubeUrl { get; set; }

        public double Rating
        {
            get
            {
                if (this.playlists.Count == 0)
                {
                    return 0;
                }

                return this.Playlists
                    .Average(p => p.Ratings.Count != 0 ? p.Ratings.Average(r => r.Value) : 0);
            }
        }

        public virtual ICollection<Playlist> Playlists
        {
            get { return this.playlists; }
            set { this.playlists = value; }
        }

        public virtual ICollection<Rating> Ratings
        {
            get { return this.ratings; }
            set { this.ratings = value; }
        }
    }
}