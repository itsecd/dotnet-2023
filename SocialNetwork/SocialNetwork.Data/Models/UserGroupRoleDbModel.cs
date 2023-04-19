using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Data.Models;

/// <summary>
/// Модель роли.
/// </summary>
[Table("user_group_role")]
public class UserGroupRoleDbModel  
{
	/// <summary>
	/// Идентификатор записи.
	/// </summary>
	[Column("id")]
	[Key]
	public int Id { get; set; }

	/// <summary>
	/// Идентификатор пользователя.
	/// </summary>
	[Column("user_id")]
	[Required]
	public int UserId { get; set; }

	/// <summary>
	/// Пользователь.
	/// </summary>
	public UserDbModel User { get; set; }

	/// <summary>
	/// Идентификатор группы.
	/// </summary>
	[Column("group_id")]
	[Required]
	public int GroupId { get; set; }

	/// <summary>
	/// Группа.
	/// </summary>
	public GroupDbModel Group { get; set; }

	/// <summary>
	/// Идентификатор роли.
	/// </summary>
	[Column("role_id")]
	[Required]
	public int RoleId { get; set; }

	/// <summary>
	/// Роль.
	/// </summary>
	public RoleDbModel Role { get; set; }
}
