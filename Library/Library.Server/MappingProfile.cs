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
        CreateMap<Card, CardGetDto>();
        CreateMap<Card, CardPostDto>();
        CreateMap<Department, DepartmentGetDto>();
        CreateMap<Department, DepartmentPostDto>();
        CreateMap<Reader, ReaderGetDto>();
        CreateMap<Reader, ReaderPostDto>();
        CreateMap<TypeDepartment, TypeDepartmentGetDto>();
        CreateMap<TypeEdition, TypeEditionGetDto>();

        CreateMap<BookPostDto, Book>();
        CreateMap<CardPostDto, Card>();
        CreateMap<DepartmentPostDto, Department>();
        CreateMap<ReaderPostDto, Reader>();
    }
}