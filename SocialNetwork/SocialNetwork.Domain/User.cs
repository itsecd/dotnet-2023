namespace SocialNetwork.Domain;

/// <summary>	
/// Пользователь.	
/// </summary>	
public class User
{	
    /// <summary>	
    /// Идентификатор.	
    /// </summary>	
    public int Id { get; set; }

    /// <summary>	
    /// Имя.	
    /// </summary>	
    public string FirstName { get; set; } = string.Empty;
    /// <summary>	
    /// Фамилия.	
    /// </summary>	
    public string LastName { get; set; } = string.Empty;

    /// <summary>	
    /// Отчество.	
    /// </summary>	
    public string Patronymic { get; set; } = string.Empty;

    /// <summary>	
    /// Пол.	
    /// </summary>	
    public string Gender { get; set; } = string.Empty;

    /// <summary>	
    /// Дата рождения.	
    /// </summary>	
    public DateTime? BirthDate { get; set; }

    /// <summary>	
    /// Дата регистрации.	
    /// </summary>	
    public DateTime? RegistrationDate { get; set; }

    /// <summary>
    /// Записи пользователя.
    /// </summary>
    public List<Note>? Notes { get; set; }

    /// <summary>
    /// Группы пользователя.
    /// </summary>
    public List<Group>? Groups { get; set; }

    /// <summary>
    /// Роли пользователя.
    /// </summary>
    public List<Role>? Roles { get; set; }

    /// <summary>
    /// Создает пользователя с помощью указанных параметров.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <param name="firstName">Имя.</param>
    /// <param name="lastName">Фамилия.</param>
    /// <param name="patronymic">Отчество.</param>
    /// <param name="gender">Пол.</param>
    /// <param name="birthDate">Дата рождения.</param>
    /// <param name="registrationDate">Дата регистрации.</param>
    /// <param name="notes">Записи пользователя.</param>
    /// <param name="groups">Группы, в которых состоит пользователь.</param>
    /// <param name="roles">Роли пользователя.</param>
    /// <exception cref="ArgumentOutOfRangeException">Числовое значение вышло за границы!</exception>
    /// <exception cref="ArgumentNullException">Объект равен null.</exception>
    public User(int userId, string firstName, string lastName, string patronymic, string gender,
        DateTime? birthDate, DateTime? registrationDate, List<Note>? notes, List<Group>? groups,
        List<Role>? roles)  
    {
        Validator.RangeNumberValidate(0, int.MaxValue, userId);
        Validator.StringTextValidate(firstName);
        Validator.StringTextValidate(lastName);
        Validator.StringTextValidate(patronymic);
        Validator.StringTextValidate(gender);
        Validator.DateTimeValidate(birthDate);
        Validator.DateTimeValidate(registrationDate);
        Validator.ListValidate(notes);
        Validator.ListValidate(groups);
        Validator.ListValidate(roles);

        Id = userId;
        FirstName = firstName;
        LastName = lastName;
        Patronymic = patronymic;
        Gender = gender;
        BirthDate = birthDate;
        RegistrationDate = registrationDate;
        Notes = notes;
        Groups = groups;
        Roles = roles;
    }

    /// <summary>
    /// Создает пользователя без параметров.
    /// </summary>
    public User()
    {
    }
    #endregion
}