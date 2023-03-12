namespace Library.Domain;

/// <summary>
/// Class Reader is used to store info about readers
/// </summary>
public class Reader
{
    /// <summary>
    /// Id stores reader's id
    /// </summary>
    public int Id { set; get; }
    /// <summary>
    /// FullName stores reader's fullname
    /// </summary>
    public string FullName { set; get; } = string.Empty;
    /// <summary>
    /// Address stores reader's address
    /// </summary>
    public string Address { set; get; } = string.Empty;
    /// <summary>
    /// Phone stores reader's phone number
    /// </summary>
    public string Phone { set; get; } = string.Empty;
    /// <summary>
    /// RegistrationDate stores reader's registration date
    /// </summary>
    public DateOnly RegistrationDate { set; get; }
}
