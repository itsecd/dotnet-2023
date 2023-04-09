using Library.Domain;

namespace Library.Server.Repository;
public interface ILibraryRepository
{
    List<Book> Books { get; }
    List<TypeEdition> BookTypes { get; }
}