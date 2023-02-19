using System;
using System.Collections.Generic;

namespace SocialNetwork.Domain;

/// <summary>	
/// Роль.	
/// </summary>	
public class Role
{
	#region Свойства.	
	/// <summary>	
	/// Идентификатор.	
	/// </summary>	
	public int RoleId { get; set; }

	/// <summary>	
	/// Название.	
	/// </summary>	
	public string Name { get; set; }

	/// <summary>
	/// Пользователи, обладающие конкретной ролью.
	/// </summary>
	public List<User> Users { get; set; }

	/// <summary>
	/// Группы, в которых состоят пользователи, обладающие данной ролью.
	/// </summary>
	public List<Group> Groups { get; set; }
	#endregion
}