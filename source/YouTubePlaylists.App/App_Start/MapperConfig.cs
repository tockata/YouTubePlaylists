namespace YouTubePlaylists.App.App_Start
{
    using System.Linq;
    using AutoMapper;
    using Models.ViewModels;
    using YouTubePlaylists.Models;

    public class MapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<Playlist, PlaylistHomePageViewModel>()
                .ForMember(p => p.Creator, opt => opt.MapFrom(p => p.Creator.UserName))
                .ForMember(p => p.Rating, opt => opt.MapFrom(p => p.Ratings.Any() ? p.Ratings.Average(r => r.Value) : 0))
                .ForMember(p => p.Category, opt => opt.MapFrom(p => p.Category.Name))
                .ForMember(
                    p => p.FirstVideoId, opt => opt.MapFrom(
                        p => p.Videos.FirstOrDefault()
                            .Url
                            .Substring(p.Videos.FirstOrDefault().Url.IndexOf("=") + 1)));

            Mapper.CreateMap<Playlist, PlaylistDetailsViewModel>()
                .ForMember(p => p.CreatorUsername, opt => opt.MapFrom(p => p.Creator.UserName))
                .ForMember(p => p.CreatorName, opt => opt.MapFrom(p => p.Creator.FirstName + " " + p.Creator.LastName))
                .ForMember(p => p.Rating, opt => opt.MapFrom(p => p.Ratings.Any() ? p.Ratings.Average(r => r.Value) : 0))
                .ForMember(p => p.Category, opt => opt.MapFrom(p => p.Category.Name))
                .ForMember(
                    p => p.VideoUrls, opt => opt.MapFrom(
                        p => p.Videos.Select(v => v.Url.Substring(v.Url.IndexOf("=") + 1))));
        }
    }
}