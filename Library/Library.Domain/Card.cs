namespace Library.Domain;
public class Card
{
    public int Id { set; get; }

    public DateTime DateOfIssue { set; get; }

    public DateTime DateOfReturn { set; get; }

    public int DayCount { set; get; }

    public List<Book> IdBooks { set; get; } = new List<Book>();

    public List<Reader> IdReader {  set; get; } = new List<Reader>();
}
