using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Data.Models;

/// <summary>
/// Модель роли.
/// </summary>
[Table("user_group_role")]
public class UserGroupRoleDBModel 
{
	/// <summary>
	/// Идентификатор записи.
	/// </summary>
	[Column("id")]
	public int Id { get; set; }

	/// <summary>
	/// Идентификатор пользователя.
	/// </summary>
	[Column("user_id")]
	public int UserId { get; set; }

	/// <summary>
	/// Идентификатор группы.
	/// </summary>
	[Column("group_id")]
	public int GroupId { get; set; }

	/// <summary>
	/// Идентификатор роли.
	/// </summary>
	[Column("role_id")]
	public int RoleId { get; set; }
}
