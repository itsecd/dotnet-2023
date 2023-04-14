using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Data.Models;

/// <summary>
/// Модель пользователя.
/// </summary>
[Table("user")]
public class UserDBModel
{
	/// <summary>	
	/// Идентификатор.	
	/// </summary>	
	[Column("id")]
	public int Id { get; set; }

	/// <summary>	
	/// Имя.	
	/// </summary>	
	[Column("first_name")]
	public string FirstName { get; set; }

	/// <summary>	
	/// Фамилия.	
	/// </summary>	
	[Column("last_name")]
	public string LastName { get; set; }

	/// <summary>	
	/// Отчество.	
	/// </summary>	
	[Column("patronymic")]
	public string Patronymic { get; set; }

	/// <summary>	
	/// Пол.	
	/// </summary>	
	[Column("gender")]
	public string Gender { get; set; }

	/// <summary>	
	/// Дата рождения.	
	/// </summary>	
	[Column("birth_date")]
	public DateTime? BirthDate { get; set; }

	/// <summary>	
	/// Дата регистрации.	
	/// </summary>	
	[Column("registration_date")]
	public DateTime? RegistrationDate { get; set; }
}
