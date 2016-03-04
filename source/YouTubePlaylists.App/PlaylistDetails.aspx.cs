namespace YouTubePlaylists.App
{
    using System;
    using System.Web.ModelBinding;
    using System.Web.UI;
    using AutoMapper;
    using Ninject;
    using Services.Contracts;
    using YouTubePlaylists.App.Models.ViewModels;

    public partial class PlaylistDetails : Page
    {
        [Inject]
        public IPlaylistsServices PlaylistsServices { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public PlaylistDetailsViewModel dvPlaylistDetails_GetItem([QueryString]string id)
        {
            if (id == null)
            {
                this.Response.Redirect("~\\");
            }

            int playlistId = int.Parse(id);
            var playlist = this.PlaylistsServices.GetById(playlistId);

            return Mapper.Map<PlaylistDetailsViewModel>(playlist);
        }
    }
}