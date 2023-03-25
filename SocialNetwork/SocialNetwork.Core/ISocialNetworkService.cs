using SocialNetwork.Domain;

namespace SocialNetwork.Core;

/// <summary>
/// Содержит методы для сервиса социальной сети.
/// </summary>
public interface ISocialNetworkService
{
	/// <summary>
	/// Получение всех групп социальной сети.
	/// </summary>
	/// <returns>Последовательность групп.</returns>
	IEnumerable<Group> GetAllGroups();

	/// <summary>
	/// Получение группы по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор группы, которую необходимо получить.</param>
	/// <returns>Группу.</returns>
	Group GetGroup(int id);

	/// <summary>
	/// Создание группы.
	/// </summary>
	/// <param name="model">Модель, в которой содержатся данные для создания группы.</param>
	void CreateGroup(Group model);

	/// <summary>
	/// Изменение данных группы.
	/// </summary>
	/// <param name="id">Идентификатор группы, данные которой необходимо изменить.</param>
	/// <param name="model">Содержит данные, которые будут присвоены необходимой группе.</param>
	void UpdateGroup(int id, Group model);

	/// <summary>
	/// Удаление группы по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор группы, которую необходимо удалить.</param>
	void DeleteGroup(int id);

	/// <summary>
	/// Получение всех записей социальной сети.
	/// </summary>
	/// <returns>Последовательность записей.</returns>
	IEnumerable<Note> GetAllNotes();

	/// <summary>
	/// Получение записи по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор записи, которую необходимо получить.</param>
	/// <returns>Запись.</returns>
	Note GetNote(int id);

	/// <summary>
	/// Создание записи.
	/// </summary>
	/// <param name="model">Модель, в которой содержатся данные для создания записи.</param>
	void CreateNote(Note model);

	/// <summary>
	/// Изменение данных записи.
	/// </summary>
	/// <param name="id">Идентификатор записи, данные которой необходимо изменить.</param>
	/// <param name="model">Содержит данные, которые будут присвоены необходимой записи.</param>
	void UpdateNote(int id, Note model);

	/// <summary>
	/// Удаление записи по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор записи, которую необходимо удалить.</param>
	void DeleteNote(int id);

	/// <summary>
	/// Получение всех ролей социальной сети.
	/// </summary>
	/// <returns>Последовательность ролей.</returns>
	IEnumerable<Role> GetAllRoles();

	/// <summary>
	/// Получение роли по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор роли, которую необходимо получить.</param>
	/// <returns>Роль.</returns>
	Role GetRole(int id);

	/// <summary>
	/// Создание роли.
	/// </summary>
	/// <param name="model">Модель, в которой содержатся данные для создания роли.</param>
	void CreateRole(Role model);

	/// <summary>
	/// Изменение данных роли.
	/// </summary>
	/// <param name="id">Идентификатор роли, данные которой необходимо изменить.</param>
	/// <param name="model">Содержит данные, которые будут присвоены необходимой роли.</param>
	void UpdateRole(int id, Role model);

	/// <summary>
	/// Удаление роли по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор роли, которую необходимо удалить.</param>
	void DeleteRole(int id);


	/// <summary>
	/// Получение всех пользователей социальной сети.
	/// </summary>
	/// <returns>Последовательность пользователей.</returns>
	IEnumerable<User> GetAllUsers();

	/// <summary>
	/// Получение пользователя по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор пользователя, которого необходимо получить.</param>
	/// <returns>Пользователя.</returns>
	User GetUser(int id);

	/// <summary>
	/// Создание пользователя.
	/// </summary>
	/// <param name="model">Модель, в которой содержатся данные для создания пользователя.</param>
	void CreateUser(User model);

	/// <summary>
	/// Изменение данных пользователя.
	/// </summary>
	/// <param name="id">Идентификатор пользователя, данные которого необходимо изменить.</param>
	/// <param name="model">Содержит данные, которые будут присвоены необходимому пользователю.</param>
	void UpdateUser(int id, User model);

	/// <summary>
	/// Удаление пользователя по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор пользователя, которого необходимо удалить.</param>
	void DeleteUser(int id);
}
