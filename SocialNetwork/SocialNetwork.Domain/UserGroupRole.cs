using System;

/// <summary>
/// Роли пользователя в различных группах.
/// </summary>
public class UserGroupRole
{
	#region Свойства.
	/// <summary>
	/// Идентификатор пользователя.
	/// </summary>
	public int UserId { get; set; }

	/// <summary>
	/// Идентификатор группы.
	/// </summary>
	public int GroupId { get; set; }

	/// <summary>
	/// Идентификатор роли.
	/// </summary>
	public int RoleId { get; set; }
	#endregion
}
