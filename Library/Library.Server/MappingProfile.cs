using AutoMapper;
using Library.Domain;
using Library.Server.Dto;

namespace Library.Server;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Book, BookGetDto>();
        CreateMap<Book, BookPostDto>();
        CreateMap<Reader, ReaderPostDto>();

        CreateMap<BookPostDto, Book>();
        CreateMap<ReaderPostDto, Reader>();
    }
}
