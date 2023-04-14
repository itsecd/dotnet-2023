using FluentValidation;
using SocialNetwork.Core.Validators;
using SocialNetwork.Domain;

namespace SocialNetwork.Core;

/// <summary>
/// Сервис социальной сети.
/// </summary>
public class SocialNetworkService : ISocialNetworkService
{
	/// <summary>
	/// Репозиторий.
	/// </summary>
	private readonly ISocialNetworkRepository _socialNetworkRepository;

	/// <summary>
	/// Валидатор группы.
	/// </summary>
	private readonly IValidator<Group> _groupValidator;

	/// <summary>
	/// Валидатор записи.
	/// </summary>
	private readonly IValidator<Note> _noteValidator;

	/// <summary>
	/// Валидатор роли.
	/// </summary>
	private readonly IValidator<Role> _roleValidator;

	/// <summary>
	/// Валидатор пользователя.
	/// </summary>
	private readonly IValidator<User> _userValidator;

	public SocialNetworkService(ISocialNetworkRepository socialNetworkRepository)
	{
		_socialNetworkRepository = socialNetworkRepository;
		_groupValidator = new GroupValidator();
		_noteValidator = new NoteValidator();
		_roleValidator = new RoleValidator();
		_userValidator = new UserValidator();
	}

	/// <summary>
	/// Получение всех групп социальной сети.
	/// </summary>
	/// <returns>Последовательность групп.</returns>
	public async Task<IEnumerable<Group>> GetAllGroups() => await _socialNetworkRepository.GetAllGroups();

	/// <summary>
	/// Получение группы по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор группы, которую необходимо получить.</param>
	/// <returns>Группу.</returns>
	/// <exception cref="NotFoundException">Группа с указанным идентификатором не найдена.</exception>
	public async Task<Group> GetGroup(int id)
	{
		var group = await _socialNetworkRepository.GetGroup(id);

		if (group == null)
		{
			throw new NotFoundException("Группа с указанным идентификатором не найдена!");
		}

		return group;
	}

	/// <summary>
	/// Создание группы.
	/// </summary>
	/// <param name="model">Модель, в которой содержатся данные для создания группы.</param>
	/// <exception cref="ValidationException">Невалидный объект.</exception>
	public async Task CreateGroup(Group model)
	{
		_groupValidator.Validate(model);

		if (await _socialNetworkRepository.GetUser(model.UserId) == null)
		{
			throw new ValidationException("Попытка присвоить группе несуществующий идентификатор создателя!");
		}

		await _socialNetworkRepository.CreateGroup(model);
	}

	/// <summary>
	/// Изменение данных группы.
	/// </summary>
	/// <param name="id">Идентификатор группы, данные которой необходимо изменить.</param>
	/// <param name="model">Содержит данные, которые будут присвоены необходимой группе.</param>
	/// <exception cref="NotFoundException">Группа с указанным идентификатором не найдена.</exception>
	/// <exception cref="ValidationException">Попытка присвоить группе несуществующий идентификатор создателя!</exception>
	public async Task UpdateGroup(int id, Group model)
	{
		_groupValidator.Validate(model);

		if (await _socialNetworkRepository.GetGroup(id) == null)
		{
			throw new NotFoundException("Группа с указанным идентификатором не найдена!");
		}

		if (await _socialNetworkRepository.GetUser(model.UserId) == null)
		{
			throw new ValidationException("Попытка присвоить группе несуществующий идентификатор создателя!");
		}

		await _socialNetworkRepository.UpdateGroup(id, model);
	}

	/// <summary>
	/// Удаление группы по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор группы, которую необходимо удалить.</param>
	/// <exception cref="NotFoundException">Группа с указанным идентификатором не найдена.</exception>
	public async Task DeleteGroup(int id)
	{
		if (await _socialNetworkRepository.GetGroup(id) == null)
		{
			throw new NotFoundException("Группа с указанным идентификатором не найдена!");
		}

		await _socialNetworkRepository.DeleteGroup(id);

		foreach (var note in (await _socialNetworkRepository.GetAllNotes()).
			Where(note => note.GroupId == id))
		{
			await _socialNetworkRepository.DeleteNote(note.Id);
		}
	}

	/// <summary>
	/// Получение всех записей социальной сети.
	/// </summary>
	/// <returns>Последовательность записей.</returns>
	public async Task<IEnumerable<Note>> GetAllNotes() => await _socialNetworkRepository.GetAllNotes();

	/// <summary>
	/// Получение записи по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор записи, которую необходимо получить.</param>
	/// <returns>Запись.</returns>
	/// <exception cref="NotFoundException">Запись с указанным идентификатором не найдена.</exception>
	public async Task<Note> GetNote(int id)
	{
		var note = await _socialNetworkRepository.GetNote(id);

		if (note == null)
		{
			throw new NotFoundException("Запись с указанным идентификатором не найдена!");
		}

		return note;
	}

	/// <summary>
	/// Создание записи.
	/// </summary>
	/// <param name="model">Модель, в которой содержатся данные для создания записи.</param>
	/// <exception cref="ValidationException">Попытка создать запись с несуществующим идентификатором автора
	/// или несуществующим идентификатором группы!</exception>
	public async Task CreateNote(Note model)
	{
		_noteValidator.Validate(model);

		if (await _socialNetworkRepository.GetUser(model.UserId) == null)
		{
			throw new ValidationException("Попытка создать запись с несуществующим идентификатором автора!");
		}

		if (await _socialNetworkRepository.GetGroup(model.GroupId) == null)
		{
			throw new ValidationException("Попытка создать запись с несуществующим идентификатором группы!");
		}

		await _socialNetworkRepository.CreateNote(model);
	}

	/// <summary>
	/// Изменение данных записи.
	/// </summary>
	/// <param name="id">Идентификатор записи, данные которой необходимо изменить.</param>
	/// <param name="model">Содержит данные, которые будут присвоены необходимой записи.</param>
	/// <exception cref="NotFoundException">Запись с указанным идентификатором не найдена.</exception>
	/// <exception cref="ValidationException">Попытка создать запись с несуществующим идентификатором автора
	/// или несуществующим идентификатором группы!</exception>
	public async Task UpdateNote(int id, Note model)
	{
		_noteValidator.Validate(model);

		if (await _socialNetworkRepository.GetNote(id) == null)
		{
			throw new NotFoundException("Запись с указанным идентификатором не найдена!");
		}

		if (await _socialNetworkRepository.GetUser(model.UserId) == null)
		{
			throw new ValidationException("Попытка создать запись с несуществующим идентификатором автора!");
		}

		if (await _socialNetworkRepository.GetGroup(model.GroupId) == null)
		{
			throw new ValidationException("Попытка создать запись с несуществующим идентификатором группы!");
		}

		await _socialNetworkRepository.UpdateNote(id, model);
	}

	/// <summary>
	/// Удаление записи по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор записи, которую необходимо удалить.</param>
	/// <exception cref="NotFoundException">Запись с указанным идентификатором не найдена.</exception>
	public async Task DeleteNote(int id)
	{
		if (await _socialNetworkRepository.GetNote(id) == null)
		{
			throw new NotFoundException("Запись с указанным идентификатором не найдена!");
		}

		await _socialNetworkRepository.DeleteNote(id);
	}

	/// <summary>
	/// Получение всех ролей социальной сети.
	/// </summary>
	/// <returns>Последовательность ролей.</returns>
	public async Task<IEnumerable<Role>> GetAllRoles() => await _socialNetworkRepository.GetAllRoles();

	/// <summary>
	/// Получение роли по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор роли, которую необходимо получить.</param>
	/// <returns>Роль.</returns>
	/// <exception cref="NotFoundException">Роль с указанным идентификатором не найдена.</exception>
	public async Task<Role> GetRole(int id)
	{
		var entity = await _socialNetworkRepository.GetRole(id);

		if (entity == null)
		{
			throw new NotFoundException("Роль с указанным идентификатором не найдена!");
		}

		return entity;
	}

	/// <summary>
	/// Создание роли.
	/// </summary>
	/// <param name="model">Модель, в которой содержатся данные для создания роли.</param>
	/// <exception cref="ValidationException">Роль с указанным названием уже присутствует!</exception>
	public async Task CreateRole(Role model)
	{
		_roleValidator.Validate(model);

		if ((await _socialNetworkRepository.GetAllRoles())
			.Where(role => role.Name == model.Name).ToList().Count != 0)
		{
			throw new ValidationException("Роль с указанным названием уже присутствует!");
		}

		await _socialNetworkRepository.CreateRole(model);
	}

	/// <summary>
	/// Изменение данных роли.
	/// </summary>
	/// <param name="id">Идентификатор роли, данные которой необходимо изменить.</param>
	/// <param name="model">Содержит данные, которые будут присвоены необходимой роли.</param>
	/// <exception cref="NotFoundException">Роль с указанным идентификатором не найдена.</exception>
	public async Task UpdateRole(int id, Role model)
	{
		_roleValidator.Validate(model);

		if (_socialNetworkRepository.GetRole(id) == null)
		{
			throw new NotFoundException("Роль с указанным идентификатором не найдена!");
		}

		await _socialNetworkRepository.UpdateRole(id, model);
	}

	/// <summary>
	/// Удаление роли по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор роли, которую необходимо удалить.</param>
	/// <exception cref="NotFoundException">Роль с указанным идентификатором не найдена.</exception>
	public async Task DeleteRole(int id)
	{
		if (await _socialNetworkRepository.GetRole(id) == null)
		{
			throw new NotFoundException("Роль с указанным идентификатором не найдена!");
		}

		await _socialNetworkRepository.DeleteRole(id);
	}


	/// <summary>
	/// Получение всех пользователей социальной сети.
	/// </summary>
	/// <returns>Последовательность пользователей.</returns>
	public async Task<IEnumerable<User>> GetAllUsers() => await _socialNetworkRepository.GetAllUsers();

	/// <summary>
	/// Получение пользователя по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор пользователя, которого необходимо получить.</param>
	/// <returns>Пользователя.</returns>
	/// <exception cref="NotFoundException">Пользователь с указанным идентификатором не найден.</exception>
	public async Task<User> GetUser(int id)
	{
		var entity = await _socialNetworkRepository.GetUser(id);

		if (entity == null)
		{
			throw new NotFoundException("Пользователь с указанным идентификатором не найден!");
		}

		return entity;
	}

	/// <summary>
	/// Создание пользователя.
	/// </summary>
	/// <param name="model">Модель, в которой содержатся данные для создания пользователя.</param>
	public async Task CreateUser(User model)
	{
		_userValidator.Validate(model); 

		await _socialNetworkRepository.CreateUser(model);
	}

	/// <summary>
	/// Изменение данных пользователя.
	/// </summary>
	/// <param name="id">Идентификатор пользователя, данные которого необходимо изменить.</param>
	/// <param name="model">Содержит данные, которые будут присвоены необходимому пользователю.</param>
	/// <exception cref="NotFoundException">Пользователь с указанным идентификатором не найден.</exception>
	public async Task UpdateUser(int id, User model)
	{
		_userValidator.Validate(model);

		if (await _socialNetworkRepository.GetUser(id) == null)
		{
			throw new NotFoundException("Пользователь с указанным идентификатором не найден!");
		}

		await _socialNetworkRepository.UpdateUser(id, model);
	}

	/// <summary>
	/// Удаление пользователя по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор пользователя, которого необходимо удалить.</param>
	/// <exception cref="NotFoundException">Пользователь с указанным идентификатором не найден.</exception>
	public async Task DeleteUser(int id)
	{
		if (await _socialNetworkRepository.GetUser(id) == null)
		{
			throw new NotFoundException("Пользователь с указанным идентификатором не найден!");
		}

		await _socialNetworkRepository.DeleteUser(id);

		foreach (var group in (await _socialNetworkRepository.GetAllGroups())
			.Where(group => group.UserId == id))
		{
			await _socialNetworkRepository.DeleteGroup(group.Id);
		}

		foreach (var note in (await _socialNetworkRepository.GetAllNotes())
			.Where(note => note.UserId == id))
		{
			await _socialNetworkRepository.DeleteNote(note.Id);
		}
	}
}