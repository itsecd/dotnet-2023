using AutoMapper;
using Media.Domain;
using Media.Server.Dto;

namespace Media.Server;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<GenrePostDto, Genre>();
        CreateMap<ArtistPostDto, Artist>();
        CreateMap<Artist, ArtistGetDto>();
        CreateMap<AlbumPostDto, Album>();
        CreateMap<Album, AlbumGetDto>();
        CreateMap<TrackPostDto, Track>();
    }
}
