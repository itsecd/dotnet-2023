namespace SocialNetwork.Domain;

/// <summary>	
/// Роль.	
/// </summary>	
public class Role
{	
    /// <summary>	
    /// Идентификатор.	
    /// </summary>	
    public int Id { get; set; }

    /// <summary>	
    /// Название.	
    /// </summary>	
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Пользователи, обладающие конкретной ролью.
    /// </summary>
    public List<User>? Users { get; set; }

    /// <summary>
    /// Группы, в которых состоят пользователи, обладающие данной ролью.
    /// </summary>
    public List<Group>? Groups { get; set; }

	public Role(int roleId, string name, List<User>? users, List<Group>? groups)
	{
		Id = roleId;
		Name = name;
		Users = users;
		Groups = groups;
	}

	public Role()
	{
	}
}