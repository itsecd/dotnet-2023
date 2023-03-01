namespace SocialNetwork.Domain;

/// <summary>	
/// Пользователь.	
/// </summary>	
public class User
{
    #region Свойства.	
    /// <summary>	
    /// Идентификатор.	
    /// </summary>	
    public int UserId { get; private set; }

    /// <summary>	
    /// Имя.	
    /// </summary>	
    public string FirstName { get; private set; }
    /// <summary>	
    /// Фамилия.	
    /// </summary>	
    public string LastName { get; private set; }

    /// <summary>	
    /// Отчество.	
    /// </summary>	
    public string Patronymic { get; private set; }

    /// <summary>	
    /// Пол.	
    /// </summary>	
    public string Gender { get; private set; }

    /// <summary>	
    /// Дата рождения.	
    /// </summary>	
    public DateTime BirthDate { get; private set; }

    /// <summary>	
    /// Дата регистрации.	
    /// </summary>	
    public DateTime RegistrationDate { get; private set; }

    /// <summary>
    /// Записи пользователя.
    /// </summary>
    public List<Note> Notes { get; private set; }

    /// <summary>
    /// Группы пользователя.
    /// </summary>
    public List<Group> Groups { get; private set; }

    /// <summary>
    /// Роли пользователя.
    /// </summary>
    public List<Role> Roles { get; private set; }
    #endregion

    #region Конструкторы.
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
        DateTime birthDate, DateTime registrationDate, List<Note> notes, List<Group> groups,
        List<Role> roles)
    {
        #region Валидация входных параметров.
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
        #endregion

        UserId = userId;
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
    /// Создает пользователя с параметрами по умолчанию.
    /// </summary>
    public User()
        : this(1, "Артем", "Стаценко", "Николаевич", "Мужской", new DateTime(2002,7,4), 
              new DateTime(2012,1,1), new List<Note>(), new List<Group>(), new List<Role>())
    {
    }
    #endregion
}