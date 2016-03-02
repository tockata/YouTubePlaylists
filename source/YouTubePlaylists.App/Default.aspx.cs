namespace YouTubePlaylists.App
{
    using System;
    using System.Collections.Generic;
    using System.Web.UI;
    using AutoMapper;
    using Models.ViewModels;
    using Ninject;
    using Services.Contracts;

    public partial class _Default : Page
    {
        [Inject]
        public IPlaylistsServices PlaylistsServices { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IEnumerable<PlaylistHomePageViewModel> rpPopularPlaylists_GetData()
        {
            var topPlaylists = this.PlaylistsServices.GetTop(10);
            return Mapper.Map<IEnumerable<PlaylistHomePageViewModel>>(topPlaylists);
        }
    }
}