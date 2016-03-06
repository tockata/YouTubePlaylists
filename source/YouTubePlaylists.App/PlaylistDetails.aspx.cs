namespace YouTubePlaylists.App
{
    using System;
    using System.Linq;
    using System.Web.ModelBinding;
    using System.Web.UI;
    using AutoMapper;
    using Ninject;
    using Services.Contracts;
    using YouTubePlaylists.App.Models.ViewModels;
    using YouTubePlaylists.Models;

    public partial class PlaylistDetails : Page
    {
        [Inject]
        public IPlaylistsServices PlaylistsServices { get; set; }

        private Playlist playlist;

        protected void Page_PreLoad(object sender, EventArgs e)
        {
            if (this.Request.QueryString["id"] == null)
            {
                this.Response.Redirect("~\\");
            }

            int playlistId = int.Parse(this.Request.QueryString["id"]);
            this.playlist = this.PlaylistsServices.GetById(playlistId);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public PlaylistDetailsViewModel fvPlaylistDetails_GetItem([QueryString]string id)
        {
            return Mapper.Map<PlaylistDetailsViewModel>(this.playlist);
        }

        public IQueryable<string> lvVideos_GetData()
        {
            IQueryable<string> videosUrls = Mapper.Map<PlaylistDetailsViewModel>(this.playlist).VideoUrls.AsQueryable();

            return videosUrls;
        }

        public IQueryable<Rating> lvRatings_GetData()
        {
            IQueryable<Rating> ratings = this.playlist.Ratings.AsQueryable();

            return ratings;
        }
    }
}