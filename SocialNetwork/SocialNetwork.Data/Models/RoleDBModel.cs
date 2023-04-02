using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
