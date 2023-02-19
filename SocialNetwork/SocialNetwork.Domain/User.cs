using System;
using System.Collections.Generic;
using System.Configuration;

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
	public int UserId { get; set; } 

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
	public List<Grops> Groups { get; set; }

	/// <summary>
	/// Роли пользователя.
	/// </summary>
	public List<Roles> Roles { get; set; }
	#endregion
}