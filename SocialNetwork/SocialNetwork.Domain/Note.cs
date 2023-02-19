using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text.RegularExpressions;

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
	public int Id { get; set; }

	/// <summary>	
	/// Название.	
	/// </summary>	
	public string Name { get; set; }

	/// <summary>	
	/// Описание.	
	/// </summary>	
	public string Description { get; set; }

	/// <summary>	
	/// Дата создания.	
	/// </summary>	
	public DateTime CreationDate { get; set; }

	/// <summary>
	/// Идентификатор автора.
	/// </summary>
	public int UserId { get; set; }

	/// <summary>
	/// Автор.
	/// </summary>
	public User User { get; set; }

	/// <summary>
	/// Идентификатор группы.
	/// </summary>
	public int  GroupId { get; set; }

	/// <summary>
	/// Группа.
	/// </summary>
	public Group group { get; set; }

	#endregion
}