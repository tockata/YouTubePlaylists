using System.Collections.Generic;
using YouTubePlaylists.Models;

namespace YouTubePlaylists.App.Models.ViewModels
{
    public class PlaylistDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string CreatorName { get; set; }

        public double Rating { get; set; }

        public IEnumerable<Rating> Ratings { get; set; }

        public int CategoryId { get; set; }

        public string Category { get; set; }

        public IEnumerable<string> VideoUrls { get; set; }
    }
}