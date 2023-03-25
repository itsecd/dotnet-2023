using SocialNetwork.Domain;

namespace SocialNetwork.Web;

/// <summary>
/// Dto роли для GET операций.
/// </summary>
public class RoleDtoGet
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
	/// Пользователи, обладающие конкретной ролью.
	/// </summary>
	public List<User>? Users { get; set; }

	/// <summary>
	/// Группы, в которых состоят пользователи, обладающие данной ролью.
	/// </summary>
	public List<Group>? Groups { get; set; }
}
