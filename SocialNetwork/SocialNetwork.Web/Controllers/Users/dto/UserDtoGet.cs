﻿namespace SocialNetwork.Web.Controllers.Users.Dto;

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
	public DateTime? BirthDate { get; set; }

	/// <summary>	
	/// Дата регистрации.	
	/// </summary>	
	public DateTime? RegistrationDate { get; set; }
}
