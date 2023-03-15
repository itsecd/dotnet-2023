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

    /// <summary>
    /// Создает группу с помощью указанных данных.
    /// </summary>
    /// <param name="groupId">Идентификатор группы.</param>
    /// <param name="name">Название.</param>
    /// <param name="description">Описание.</param>
    /// <param name="creationDate">Дата создания.</param>
    /// <param name="userId">Идентификатор создателя группы.</param>
    /// <param name="user">Создатель группы.</param>
    /// <param name="notes">Список записей группы.</param>
    /// <exception cref="ArgumentNullException">Объект равен null!</exception>
    /// <exception cref="ArgumentOutOfRangeException">Числовое значение вышло за границы!</exception>
    public Group(int groupId, string name, string description, DateTime? creationDate, int userId,
        User? user, List<Note>? notes)
    {
        Validator.RangeNumberValidate(0, int.MaxValue, groupId);
        Validator.StringTextValidate(name);
        Validator.StringTextValidate(description);
        Validator.DateTimeValidate(creationDate);
        Validator.RangeNumberValidate(0, int.MaxValue, userId);
        Validator.UserValidate(user);
        Validator.ListValidate(notes);

        Id = groupId;
        Name = name;
        Description = description;
        CreationDate = creationDate;
        UserId = userId;
        User = user;
        Notes = notes;
    }

    /// <summary>
    /// Создает группу без параметров.
    /// </summary>
    public Group() 
    {
    }
    #endregion

}