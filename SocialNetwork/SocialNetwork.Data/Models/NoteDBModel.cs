using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Data.Models;

/// <summary>
/// Модель записи.
/// </summary>
[Table("note")]
public class NoteDBModel
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

	/// <summary>
	/// Описание.
	/// </summary>
	[Column("description")]
	public string Description { get; set; }

	/// <summary>
	/// Дата создания.
	/// </summary>
	[Column("creation_date")]
	public DateTime? CreationDate { get; set; }

	/// <summary>
	/// Идентификатор создателя.
	/// </summary>
	[Column("user_id")]
	public int UserId { get; set; }

	/// <summary>
	/// Идентификатор группы.
	/// </summary>
	[Column("group_id")]
	public int GroupId { get; set; }
}
