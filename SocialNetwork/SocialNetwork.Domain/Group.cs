namespace SocialNetwork.Domain;

/// <summary>	
/// Группа.	
/// </summary>	
public class Group
{
    /// <summary>	
    /// Идентификатор.	
    /// </summary>	
    public int Id { get; set; }

    /// <summary>	
    /// Название.	
    /// </summary>	  
    public string Name { get; set; } = string.Empty;

    /// <summary>	
    /// Описание.	
    /// </summary>	
    public string Description { get; set; } = string.Empty;

    /// <summary>	
    /// Дата создания.	
    /// </summary>	
    public DateTime? CreationDate { get; set; }

    /// <summary>
    /// Идентификатор создателя.
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Создатель.
    /// </summary>
    public User? User { get; set; }

    /// <summary>
    /// Записи группы.
    /// </summary>
    public List<Note>? Notes { get; set; }

	public Group(int groupId, string name, string description, DateTime? creationDate, int userId,
		User? user, List<Note>? notes)
	{
		Id = groupId;
		Name = name;
		Description = description;
		CreationDate = creationDate;
		UserId = userId;
		User = user;
		Notes = notes;
	}

	public Group()
	{
	}
}