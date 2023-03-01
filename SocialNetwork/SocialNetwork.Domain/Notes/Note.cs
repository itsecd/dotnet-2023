namespace SocialNetwork.Domain;

/// <summary>	
/// Запись.	
/// </summary>	
public class Note
{
    #region Свойства.	
    /// <summary>	
    /// Идентификатор.	
    /// </summary>	
    public int Id { get; private set; }

    /// <summary>	
    /// Название.	
    /// </summary>	
    public string Name { get; private set; }

    /// <summary>	
    /// Описание.	
    /// </summary>	
    public string Description { get; private set; }

    /// <summary>	
    /// Дата создания.	
    /// </summary>	
    public DateTime CreationDate { get; private set; }

    /// <summary>
    /// Идентификатор автора.
    /// </summary>
    public int UserId { get; private set; }

    /// <summary>
    /// Автор.
    /// </summary>
    public User User { get; private set; }

    /// <summary>
    /// Идентификатор группы.
    /// </summary>
    public int GroupId { get; private set; }

    /// <summary>
    /// Группа.
    /// </summary>
    public Group Group { get; private set; }
    #endregion

    #region Конструкторы.
    /// <summary>
    /// Создает запись с помощью указанных данных.
    /// </summary>
    /// <param name="id">Идентификатор записи.</param>
    /// <param name="name">Название записи.</param>
    /// <param name="description">Описание записи.</param>
    /// <param name="creationDate">Дата создания записи.</param>
    /// <param name="userId">Идентификатор создателя записи.</param>
    /// <param name="user">Создатель записи.</param>
    /// <param name="groupId">Идентификатор группы.</param>
    /// <param name="group">Группа.</param>
    /// <exception cref="ArgumentOutOfRangeException">Числовое значение вышло за границы!</exception>
    /// <exception cref="ArgumentNullException">Объект равен null!</exception>
    public Note(int id, string name, string description, DateTime creationDate, int userId,
        User? user, int groupId, Group? group)
    {
        #region Валидация входных параметров.
        Validator.RangeNumberValidate(0, int.MaxValue, id);
        Validator.StringTextValidate(name);
        Validator.StringTextValidate(description);
        Validator.DateTimeValidate(creationDate);
        Validator.RangeNumberValidate(0, int.MaxValue, userId);
        Validator.UserValidate(user);
        Validator.RangeNumberValidate(0, int.MaxValue, groupId);
        Validator.GroupValidate(group);
        #endregion

        Id = id;
        Name = name;
        Description = description;
        CreationDate = creationDate;
        UserId = userId;
        User = user;
        GroupId = groupId;
        Group = group;
    }

    /// <summary>
    /// Создает запись с помощью параметров по умолчанию.
    /// </summary>
    public Note()
        : this(1, "Название записи", "Описание записи", DateTime.Now, 1, new User(), 1, new Group())
    {
    }
    #endregion
}