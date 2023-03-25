using SocialNetwork.Core;
using SocialNetwork.Domain;

namespace SocialNetwork.Data;

/// <summary>
/// Репозиторий социальной сети.
/// </summary>
public class SocialNetworkRepository : ISocialNetworkRepository
{
	/// <summary>
	/// Содержит данные о группах.
	/// </summary>
	private readonly List<Group> _groups;

	/// <summary>
	/// Содержит данные о записях.
	/// </summary>
	private readonly List<Note> _notes;

	/// <summary>
	/// Содержит данные о ролях.
	/// </summary>
	private readonly List<Role> _roles;

	/// <summary>
	/// Содержит данные о пользователях.
	/// </summary>
	private readonly List<User> _users;

	/// <summary>
	/// Создает репозиторий.
	/// </summary>
	public SocialNetworkRepository()
	{
		_groups = new List<Group>();
		_notes = new List<Note>();
		_roles = new List<Role>();
		_users = new List<User>();
	}

	/// <summary>
	/// Получение всех групп социальной сети.
	/// </summary>
	/// <returns>Последовательность групп.</returns>
	public IEnumerable<Group> GetAllGroups() => _groups;

	/// <summary>
	/// Получение группы по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор группы, которую необходимо получить.</param>
	/// <returns>Группу.</returns>
	public Group GetGroup(int id) => _groups.FirstOrDefault(group => group.Id == id);

	/// <summary>
	/// Создание группы.
	/// </summary>
	/// <param name="model">Модель, в которой содержатся данные для создания группы.</param>
	public void CreateGroup(Group model)
	{
		model.Notes = new List<Note>();

		_groups.Add(model);
	}

	/// <summary>
	/// Изменение данных группы.
	/// </summary>
	/// <param name="id">Идентификатор группы, данные которой необходимо изменить.</param>
	/// <param name="model">Содержит данные, которые будут присвоены необходимой группе.</param>
	public void UpdateGroup(int id, Group model)
	{
		var entity = _groups.First(group => group.Id == id);

		entity.Name = model.Name;
		entity.Description = model.Description;
		entity.CreationDate = model.CreationDate;
		entity.UserId = model.UserId;
		entity.User = model.User;
	}

	/// <summary>
	/// Удаление группы по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор группы, которую необходимо удалить.</param>
	public void DeleteGroup(int id)
	{
		_groups.Remove(_groups.First(group => group.Id == id));
	}

	/// <summary>
	/// Получение всех записей социальной сети.
	/// </summary>
	/// <returns>Последовательность записей.</returns>
	public IEnumerable<Note> GetAllNotes() => _notes;

	/// <summary>
	/// Получение записи по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор записи, которую необходимо получить.</param>
	/// <returns>Запись.</returns>
	public Note GetNote(int id) => _notes.First(note => note.Id == id);
	

	/// <summary>
	/// Создание записи.
	/// </summary>
	/// <param name="model">Модель, в которой содержатся данные для создания записи.</param>
	public void CreateNote(Note model)
	{
		_notes.Add(model);
	}

	/// <summary>
	/// Изменение данных записи.
	/// </summary>
	/// <param name="id">Идентификатор записи, данные которой необходимо изменить.</param>
	/// <param name="model">Содержит данные, которые будут присвоены необходимой записи.</param>
	public void UpdateNote(int id, Note model)
	{
		var entity = _notes.First(note => note.Id == id);

		entity.Name = model.Name;
		entity.Description = model.Description;
		entity.CreationDate = model.CreationDate;
		entity.UserId = model.UserId;
		entity.User = model.User;
		entity.GroupId = model.GroupId;
		entity.Group = model.Group;
	}

	/// <summary>
	/// Удаление записи по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор записи, которую необходимо удалить.</param>
	public void DeleteNote(int id)
	{
		_notes.Remove(_notes.First(note => note.Id == id));
	}

	/// <summary>
	/// Получение всех ролей социальной сети.
	/// </summary>
	/// <returns>Последовательность ролей.</returns>
	public IEnumerable<Role> GetAllRoles() => _roles;

	/// <summary>
	/// Получение роли по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор роли, которую необходимо получить.</param>
	/// <returns>Роль.</returns>
	public Role GetRole(int id) => _roles.FirstOrDefault(role => role.Id == id);

	/// <summary>
	/// Создание роли.
	/// </summary>
	/// <param name="model">Модель, в которой содержатся данные для создания роли.</param>
	public void CreateRole(Role model)
	{
		_roles.Add(model);
	}

	/// <summary>
	/// Изменение данных роли.
	/// </summary>
	/// <param name="id">Идентификатор роли, данные которой необходимо изменить.</param>
	/// <param name="model">Содержит данные, которые будут присвоены необходимой роли.</param>
	public void UpdateRole(int id, Role model)
	{
		var entity = _roles.First(role => role.Id == id);

		entity.Name = model.Name;
	}

	/// <summary>
	/// Удаление роли по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор роли, которую необходимо удалить.</param>
	public void DeleteRole(int id)
	{
		_roles.Remove(_roles.First(role => role.Id == id));
	}


	/// <summary>
	/// Получение всех пользователей социальной сети.
	/// </summary>
	/// <returns>Последовательность пользователей.</returns>
	public IEnumerable<User> GetAllUsers() => _users;

	/// <summary>
	/// Получение пользователя по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор пользователя, которого необходимо получить.</param>
	/// <returns>Пользователя.</returns>
	public User GetUser(int id) => _users.FirstOrDefault(user => user.Id == id);

	/// <summary>
	/// Создание пользователя.
	/// </summary>
	/// <param name="model">Модель, в которой содержатся данные для создания пользователя.</param>
	public void CreateUser(User model)
	{
		_users.Add(model);
	}

	/// <summary>
	/// Изменение данных пользователя.
	/// </summary>
	/// <param name="id">Идентификатор пользователя, данные которого необходимо изменить.</param>
	/// <param name="model">Содержит данные, которые будут присвоены необходимому пользователю.</param>
	public void UpdateUser(int id, User model)
	{
		var entity = _users.First(user => user.Id == id);

		entity.FirstName = model.FirstName;
		entity.LastName = model.LastName;
		entity.Patronymic = model.Patronymic;
		entity.Gender = model.Gender;
		entity.BirthDate = model.BirthDate;
		entity.RegistrationDate = model.RegistrationDate;
	}

	/// <summary>
	/// Удаление пользователя по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор пользователя, которого необходимо удалить.</param>
	public void DeleteUser(int id)
	{
		_users.Remove(_users.First(user => user.Id == id));	
	}
}
