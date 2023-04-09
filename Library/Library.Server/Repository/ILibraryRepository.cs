using Library.Domain;

namespace Library.Server.Repository;
public interface ILibraryRepository
{
    List<Book> Books { get; }
    List<TypeEdition> BookTypes { get; }
    List<Department> Departments { get; }
    List<TypeDepartment> DepartmentTypes { get; }
    List<Reader> Readers { get; }
    List<Card> Cards { get; }
}