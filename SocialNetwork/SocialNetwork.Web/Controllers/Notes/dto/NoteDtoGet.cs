using SocialNetwork.Domain;

namespace SocialNetwork.Web;

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
	/// Автор.
	/// </summary>
	public User? User { get; set; }

	/// <summary>
	/// Группа.
	/// </summary>
	public Group? Group { get; set; }
}
