namespace SocialNetwork.Web;

/// <summary>
/// Dto группы для POST и PUT операций.
/// </summary>
public class GroupDtoPostOrPut
{
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
}
