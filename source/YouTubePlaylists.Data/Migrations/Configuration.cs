namespace YouTubePlaylists.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public sealed class Configuration : DbMigrationsConfiguration<YouTubePlaylistsDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            ContextKey = "YouTubePlaylists.Data.YouTubePlaylistsDbContext";
        }

        protected override void Seed(YouTubePlaylistsDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            this.CreateAdmin(context);
            this.CreateUsers(context);
            this.CreateCategories(context);
            this.CreatePlaylists(context);
        }

        private void CreateAdmin(YouTubePlaylistsDbContext context)
        {
            var userManager = new UserManager<User>(new UserStore<User>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            string roleName = "Administrator";
            IdentityResult roleResult;

            if (!roleManager.RoleExists(roleName))
            {
                roleResult = roleManager.Create(new IdentityRole(roleName));
            }

            var adminUser = new User()
            {
                UserName = "admin",
                FirstName = "admin",
                LastName = "admin",
                Email = "admin@site.com",
            };

            var result = userManager.Create(adminUser, "admin123");
            if (result.Succeeded)
            {
                var currentUser = userManager.FindByName(adminUser.UserName);
                var roleresult = userManager.AddToRole(currentUser.Id, "Administrator");
            }

            context.SaveChanges();
        }

        private void CreateUsers(YouTubePlaylistsDbContext context)
        {
            var userManager = new UserManager<User>(new UserStore<User>(context));

            for (int i = 1; i <= 5; i++)
            {
                var newUser = new User()
                {
                    UserName = "user" + i,
                    FirstName = "UserFirstName" + i,
                    LastName = "UserLastName" + i,
                    Email = "user" + i + "@site.com",
                };

                var result = userManager.Create(newUser, "user" + i + "789");
            }

            context.SaveChanges();
        }

        private void CreateCategories(YouTubePlaylistsDbContext context)
        {
            context.Categories.Add(new Category { Name = "Film & Animation" });
            context.Categories.Add(new Category { Name = "Autos & Vehicles" });
            context.Categories.Add(new Category { Name = "Music" });
            context.Categories.Add(new Category { Name = "Pets & Animals" });
            context.Categories.Add(new Category { Name = "Sports" });
            context.Categories.Add(new Category { Name = "Short Movies" });
            context.Categories.Add(new Category { Name = "Travel & Events" });
            context.Categories.Add(new Category { Name = "Gaming" });
            context.Categories.Add(new Category { Name = "Videoblogging" });
            context.Categories.Add(new Category { Name = "People & Blogs" });
            context.Categories.Add(new Category { Name = "Comedy" });
            context.Categories.Add(new Category { Name = "Entertainment" });
            context.Categories.Add(new Category { Name = "News & Politics" });
            context.Categories.Add(new Category { Name = "Howto & Style" });
            context.Categories.Add(new Category { Name = "Education" });
            context.Categories.Add(new Category { Name = "Science & Technology" });
            context.Categories.Add(new Category { Name = "Nonprofits & Activism" });
            context.Categories.Add(new Category { Name = "Movies" });
            context.Categories.Add(new Category { Name = "Anime/Animation" });
            context.Categories.Add(new Category { Name = "Action/Adventure" });
            context.Categories.Add(new Category { Name = "Classics" });
            context.Categories.Add(new Category { Name = "Documentary" });
            context.Categories.Add(new Category { Name = "Drama" });
            context.Categories.Add(new Category { Name = "Family" });
            context.Categories.Add(new Category { Name = "Foreign" });
            context.Categories.Add(new Category { Name = "Horror" });
            context.Categories.Add(new Category { Name = "Sci-Fi/Fantasy" });
            context.Categories.Add(new Category { Name = "Thriller" });
            context.Categories.Add(new Category { Name = "Shorts" });
            context.Categories.Add(new Category { Name = "Shows" });
            context.Categories.Add(new Category { Name = "Trailers" });

            context.SaveChanges();
        }

        private void CreatePlaylists(YouTubePlaylistsDbContext context)
        {
            Random rnd = new Random();
            var users = context.Users.ToList();
            var categories = context.Categories.ToList();
            var videos = new string[]
            {
                "https://www.youtube.com/watch?v=qJ7-IvGhY38",
                "https://www.youtube.com/watch?v=NfpYNr7es0Y",
                "https://www.youtube.com/watch?v=ERKvFotJ7rM",
                "https://www.youtube.com/watch?v=eff1BMUSfjM",
                "https://www.youtube.com/watch?v=kKlhOqeVUNk",
                "https://www.youtube.com/watch?v=Oqwzgw-9rSc",
                "https://www.youtube.com/watch?v=n0aXcxAi8vE",
                "https://www.youtube.com/watch?v=iIkNXaSU7mc",
                "https://www.youtube.com/watch?v=BEG-ly9tQGk"
            };

            for (int i = 1; i <= 10; i++)
            {
                User playlistOwner = users[rnd.Next(0, users.Count())];
                Category playlistCategory = categories[rnd.Next(0, categories.Count())];

                Playlist newPlaylist = new Playlist
                {
                    Title = "Title" + i,
                    Description = "Description" + i,
                    CreatedAt = DateTime.UtcNow,
                    CategoryId = playlistCategory.Id,
                    CreatorId = playlistOwner.Id
                };

                context.Playlists.Add(newPlaylist);
                for (int j = 0; j < 3; j++)
                {
                    Video newVideo = new Video
                    {
                        Url = videos[rnd.Next(0, videos.Length)]
                    };

                    context.Videos.Add(newVideo);
                    newPlaylist.Videos.Add(newVideo);
                }

                for (int k = 0; k < 5; k++)
                {
                    User voter = users[rnd.Next(0, users.Count())];
                    if (voter.Id != newPlaylist.CreatorId)
                    {
                        Rating newRating = new Rating
                        {
                            PlaylistId = newPlaylist.Id,
                            Value = rnd.Next(1, 6),
                            VoterId = voter.Id
                        };

                        context.Ratings.Add(newRating);
                        newPlaylist.Ratings.Add(newRating);
                    }
                }

                context.SaveChanges();
            }
        }
    }
}