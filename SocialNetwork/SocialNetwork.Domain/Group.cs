using System;
using System.Collections.Generic;

namespace SocialNetwork.Domain;
/// <summary>	
/// Группа.	
/// </summary>	
public class Group
{
	#region Свойства.	
	/// <summary>	
	/// Идентификатор.	
	/// </summary>	
	public int GroupId { get; set; }

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
	/// Идентификатор создателя.
	/// </summary>
	public int UserId { get; set; }

	/// <summary>
	/// Создатель.
	/// </summary>
	public User user { get; set; }

	/// <summary>
	/// Записи группы.
	/// </summary>
	public List<Note> Notes { get; set; }
	#endregion
}