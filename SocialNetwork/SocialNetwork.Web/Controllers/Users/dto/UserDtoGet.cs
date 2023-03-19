using SocialNetwork.Domain;

namespace SocialNetwork.Web;

/// <summary>
/// Dto пользователя для GET операций.
/// </summary>
public class UserDtoGet
{
	/// <summary>	
	/// Идентификатор.	
	/// </summary>	
	public int Id { get; set; }

	/// <summary>	
	/// Имя.	
	/// </summary>	
	public string FirstName { get; set; }
	/// <summary>	
	/// Фамилия.	
	/// </summary>	
	public string LastName { get; set; }

	/// <summary>	
	/// Отчество.	
	/// </summary>	
	public string Patronymic { get; set; }

	/// <summary>	
	/// Пол.	
	/// </summary>	
	public string Gender { get; set; }

	/// <summary>	
	/// Дата рождения.	
	/// </summary>	
	public DateTime BirthDate { get; set; }

	/// <summary>	
	/// Дата регистрации.	
	/// </summary>	
	public DateTime RegistrationDate { get; set; }

	/// <summary>
	/// Записи пользователя.
	/// </summary>
	public List<Note> Notes { get; set; }

	/// <summary>
	/// Группы пользователя.
	/// </summary>
	public List<Group> Groups { get; set; }

	/// <summary>
	/// Роли пользователя.
	/// </summary>
	public List<Role> Roles { get; set; }
}
