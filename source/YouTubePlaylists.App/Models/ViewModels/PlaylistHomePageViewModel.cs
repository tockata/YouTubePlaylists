namespace YouTubePlaylists.App.Models.ViewModels
{
    public class PlaylistHomePageViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Creator { get; set; }

        public double Rating { get; set; }

        public int CategoryId { get; set; }

        public string Category { get; set; }

        public string FirstVideoId { get; set; }
    }
}