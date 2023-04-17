using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Data.Models;

/// <summary>
/// Модель пользователя.
/// </summary>
[Table("user")]
public class UserDbModel 
{
	/// <summary>	
	/// Идентификатор.	
	/// </summary>	
	[Column("id")]
	[Key]
	public int Id { get; set; }

	/// <summary>	
	/// Имя.	
	/// </summary>	
	[Column("first_name")]
	[Required]
	public string FirstName { get; set; }

	/// <summary>	
	/// Фамилия.	
	/// </summary>	
	[Column("last_name")]
	[Required]
	public string LastName { get; set; }

	/// <summary>	
	/// Отчество.	
	/// </summary>	
	[Column("patronymic")]
	[Required]
	public string Patronymic { get; set; }

	/// <summary>	
	/// Пол.	
	/// </summary>	
	[Column("gender")]
	[Required]
	public string Gender { get; set; }

	/// <summary>	
	/// Дата рождения.	
	/// </summary>	
	[Column("birth_date")]
	[Required]
	public DateTime? BirthDate { get; set; }

	/// <summary>	
	/// Дата регистрации.	
	/// </summary>	
	[Column("registration_date")]
	[Required]
	public DateTime? RegistrationDate { get; set; }
}
