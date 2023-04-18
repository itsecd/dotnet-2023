using SocialNetwork.Domain;

namespace SocialNetwork.Web.Controllers.Notes.Dto;

/// <summary>
/// Dto записи для GET операций.
/// </summary>
public class NoteDtoGet
{
	/// <summary>	
	/// Идентификатор.	
	/// </summary>	
	public int Id { get; set; }

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
	public DateTime? CreationDate { get; set; }

	/// <summary>
	/// Идентификатор автора.
	/// </summary>
	public int UserId { get; set; }

	/// <summary>
	/// Идентификатор группы.
	/// </summary>
	public int GroupId { get; set; }
}
