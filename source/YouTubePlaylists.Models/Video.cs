namespace YouTubePlaylists.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Video
    {
        public int Id { get; set; }

        [Required]
        public string Url { get; set; }
    }
}