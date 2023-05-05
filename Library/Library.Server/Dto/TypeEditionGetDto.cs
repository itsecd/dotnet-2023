namespace Library.Server.Dto;
/// <summary>
/// Class TypeEditionGetDto is used to store info about types of books
/// </summary>
public class TypeEditionGetDto
{
    /// <summary>
    /// Id stores type's id
    /// </summary>
    public int Id { set; get; }
    /// <summary>
    /// Name stores name of the type
    /// </summary>
    public string Name { set; get; } = string.Empty;
}
