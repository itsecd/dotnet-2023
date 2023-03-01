namespace SocialNetwork.Domain;

/// <summary>	
/// Роль.	
/// </summary>	
public class Role
{
    #region Свойства.	
    /// <summary>	
    /// Идентификатор.	
    /// </summary>	
    public int RoleId { get; private set; }

    /// <summary>	
    /// Название.	
    /// </summary>	
    public string Name { get; private set; }

    /// <summary>
    /// Пользователи, обладающие конкретной ролью.
    /// </summary>
    public List<User>? Users { get; private set; }

    /// <summary>
    /// Группы, в которых состоят пользователи, обладающие данной ролью.
    /// </summary>
    public List<Group>? Groups { get; private set; }
    #endregion

    #region Конструкторы.
    /// <summary>
    /// Создает роль с помощью указанных данных.
    /// </summary>
    /// <param name="roleId">Идентификатор роли.</param>
    /// <param name="name">Название роли.</param>
    /// <param name="users">Список пользователей, имеющих данную роль.</param>
    /// <param name="groups">Список групп, в которых состоят пользователи, имеющие данную роль.</param>
    /// <exception cref="ArgumentOutOfRangeException">Числовое значение вышло за границы.</exception>
    /// <exception cref="ArgumentNullException">Объект равен null.</exception>
    public Role(int roleId, string name, List<User>? users, List<Group>? groups)
    {
        #region Валидация входных параметров.
        Validator.RangeNumberValidate(0, int.MaxValue, roleId);
        Validator.StringTextValidate(name);
        Validator.ListValidate(users);
        Validator.ListValidate(groups);
        #endregion

        RoleId = roleId;
        Name = name;
        Users = users;
        Groups = groups;
    }
    #endregion
}