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

	public User(int userId, string firstName, string lastName, string patronymic, string gender,
		DateTime? birthDate, DateTime? registrationDate, List<Note>? notes, List<Group>? groups,
		List<Role>? roles)
	{
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

	public User()
	{
	}
}