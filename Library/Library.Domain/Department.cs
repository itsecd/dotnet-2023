namespace Library.Domain;
public class Department
{
    public int Id { set; get; }

    public int Count { set; get; }

    public List<Book> IdBooks { set; get; } = new List<Book>();

    public List<TypeDepartment> IdDepartments { set; get; } = new List<TypeDepartment>();
}
