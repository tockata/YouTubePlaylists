namespace YouTubePlaylists.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class Playlist
    {
        private ICollection<Video> videos;
        private ICollection<Rating> ratings;

        public Playlist()
        {
            this.videos = new HashSet<Video>();
            this.ratings = new HashSet<Rating>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Title { get; set; }

        [Required]
        [MinLength(3)]
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [Required]
        public string CreatorId { get; set; }

        [ForeignKey("CreatorId")]
        public virtual User Creator { get; set; }

        public double Rating
        {
            get
            {
                if (this.ratings.Count() == 0)
                {
                    return 0;
                }
                return this.ratings
                    .Average(r => r.Value);
            }
        }

        public virtual ICollection<Video> Videos
        {
            get { return this.videos; }
            set { this.videos = value; }
        }

        public virtual ICollection<Rating> Ratings
        {
            get { return this.ratings; }
            set { this.ratings = value; }
        }
    }
}