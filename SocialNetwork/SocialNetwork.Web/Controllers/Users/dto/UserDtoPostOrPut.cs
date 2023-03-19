namespace SocialNetwork.Web;

/// <summary>
/// Dto пользователя для POST и PUT операций.
/// </summary>
public class UserDtoPostOrPut
{
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
}
