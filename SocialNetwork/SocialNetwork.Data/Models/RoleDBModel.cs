using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Data.Models;

/// <summary>
/// Модель роли.
/// </summary>
[Table("role")]
public class RoleDBModel
{
	/// <summary>
	/// Идентификатор.
	/// </summary>
	[Column("id")]
	public int Id { get; set; }

	/// <summary>
	/// Название.
	/// </summary>
	[Column("name")]
	public string Name { get; set; }
}
