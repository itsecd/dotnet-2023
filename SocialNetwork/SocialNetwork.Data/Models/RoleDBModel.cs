using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Data.Models;

/// <summary>
/// Модель роли.
/// </summary>
[Table("role")]
public class RoleDbModel 
{
	/// <summary>
	/// Идентификатор.
	/// </summary>
	[Column("id")]
	[Key]
	public int Id { get; set; }

	/// <summary>
	/// Название.
	/// </summary>
	[Column("name")]
	[Required]
	public string Name { get; set; }
}
