using SocialNetwork.Domain;

namespace SocialNetwork.Core;

public interface ISocialNetworkRepository
{
	/// <summary>
	/// Получение всех групп социальной сети.
	/// </summary>
	/// <returns>Последовательность групп.</returns>
	Task<IEnumerable<Group>> GetAllGroups();

	/// <summary>
	/// Получение группы по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор группы, которую необходимо получить.</param>
	/// <returns>Группу.</returns>
	Task<Group?> GetGroup(int id);

	/// <summary>
	/// Создание группы.
	/// </summary>
	/// <param name="model">Модель, в которой содержатся данные для создания группы.</param>
	Task CreateGroup(Group model);

	/// <summary>
	/// Изменение данных группы.
	/// </summary>
	/// <param name="id">Идентификатор группы, данные которой необходимо изменить.</param>
	/// <param name="model">Содержит данные, которые будут присвоены необходимой группе.</param>
	Task UpdateGroup(int id, Group model);

	/// <summary>
	/// Удаление группы по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор группы, которую необходимо удалить.</param>
	Task DeleteGroup(int id);

	/// <summary>
	/// Получение всех записей социальной сети.
	/// </summary>
	/// <returns>Последовательность записей.</returns>
	Task<IEnumerable<Note>> GetAllNotes();

	/// <summary>
	/// Получение записи по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор записи, которую необходимо получить.</param>
	/// <returns>Запись.</returns>
	Task<Note?> GetNote(int id);

	/// <summary>
	/// Создание записи.
	/// </summary>
	/// <param name="model">Модель, в которой содержатся данные для создания записи.</param>
	Task CreateNote(Note model);

	/// <summary>
	/// Изменение данных записи.
	/// </summary>
	/// <param name="id">Идентификатор записи, данные которой необходимо изменить.</param>
	/// <param name="model">Содержит данные, которые будут присвоены необходимой записи.</param>
	Task UpdateNote(int id, Note model);

	/// <summary>
	/// Удаление записи по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор записи, которую необходимо удалить.</param>
	Task DeleteNote(int id);

	/// <summary>
	/// Получение всех ролей социальной сети.
	/// </summary>
	/// <returns>Последовательность ролей.</returns>
	Task<IEnumerable<Role>> GetAllRoles(); 

	/// <summary>
	/// Получение роли по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор роли, которую необходимо получить.</param>
	/// <returns>Роль.</returns>
	Task<Role?> GetRole(int id);

	/// <summary>
	/// Создание роли.
	/// </summary>
	/// <param name="model">Модель, в которой содержатся данные для создания роли.</param>
	Task CreateRole(Role model);

	/// <summary>
	/// Изменение данных роли.
	/// </summary>
	/// <param name="id">Идентификатор роли, данные которой необходимо изменить.</param>
	/// <param name="model">Содержит данные, которые будут присвоены необходимой роли.</param>
	Task UpdateRole(int id, Role model);

	/// <summary>
	/// Удаление роли по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор роли, которую необходимо удалить.</param>
	Task DeleteRole(int id);

	/// <summary>
	/// Получение всех пользователей социальной сети.
	/// </summary>
	/// <returns>Последовательность пользователей.</returns>
	Task<IEnumerable<User>> GetAllUsers();

	/// <summary>
	/// Получение пользователя по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор пользователя, которого необходимо получить.</param>
	/// <returns>Пользователя.</returns>
	Task<User?> GetUser(int id); 

	/// <summary>
	/// Создание пользователя.
	/// </summary>
	/// <param name="model">Модель, в которой содержатся данные для создания пользователя.</param>
	Task CreateUser(User model);

	/// <summary>
	/// Изменение данных пользователя.
	/// </summary>
	/// <param name="id">Идентификатор пользователя, данные которого необходимо изменить.</param>
	/// <param name="model">Содержит данные, которые будут присвоены необходимому пользователю.</param>
	Task UpdateUser(int id, User model);

	/// <summary>
	/// Удаление пользователя по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор пользователя, которого необходимо удалить.</param>
	Task DeleteUser(int id);
}

