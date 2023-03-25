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

	/// <summary>
	/// Создание сервиса с помощью указанных данных.
	/// </summary>
	/// <param name="socialNetworkRepository">Репозиторий.</param>
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
	public IEnumerable<Group> GetAllGroups() => _socialNetworkRepository.GetAllGroups();

	/// <summary>
	/// Получение группы по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор группы, которую необходимо получить.</param>
	/// <returns>Группу.</returns>
	/// <exception cref="ValidationException">Группа с указанным идентификатором не найдена.</exception>
	public Group GetGroup(int id)
	{
		var entity = _socialNetworkRepository.GetGroup(id);

		if (entity == null)
		{
			throw new ValidationException("Группа с указанным идентификатором не найден!");
		}

		return entity; 
	}

	/// <summary>
	/// Создание группы.
	/// </summary>
	/// <param name="model">Модель, в которой содержатся данные для создания группы.</param>
	/// <exception cref="ValidationException">Невалидный объект.</exception>
	public void CreateGroup(Group model)
	{
		_groupValidator.Validate(model);

		var user = GetUser(model.UserId);
		user.Groups!.Add(model);
		model.User = user;

		_socialNetworkRepository.CreateGroup(model);
	}

	/// <summary>
	/// Изменение данных группы.
	/// </summary>
	/// <param name="id">Идентификатор группы, данные которой необходимо изменить.</param>
	/// <param name="model">Содержит данные, которые будут присвоены необходимой группе.</param>
	/// <exception cref="ValidationException">Группа с указанным идентификатором не найдена.</exception>
	public void UpdateGroup(int id, Group model)
	{
		_groupValidator.Validate(model);
		GetGroup(id);

		var user = GetUser(model.UserId);
		user.Groups!.Add(model);
		model.User = user;

		_socialNetworkRepository.UpdateGroup(id, model);
	}

	/// <summary>
	/// Удаление группы по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор группы, которую необходимо удалить.</param>
	/// <exception cref="ValidationException">Группа с указанным идентификатором не найдена.</exception>
	public void DeleteGroup(int id)
	{
		GetGroup(id);

		_socialNetworkRepository.DeleteGroup(id);

		foreach (var element in _socialNetworkRepository.GetAllNotes().Where(note => note.GroupId == id))
		{
			_socialNetworkRepository.DeleteNote(element.Id);
		}
	}

	/// <summary>
	/// Получение всех записей социальной сети.
	/// </summary>
	/// <returns>Последовательность записей.</returns>
	public IEnumerable<Note> GetAllNotes() => _socialNetworkRepository.GetAllNotes();

	/// <summary>
	/// Получение записи по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор записи, которую необходимо получить.</param>
	/// <returns>Запись.</returns>
	/// <exception cref="ValidationException">Запись с указанным идентификатором не найдена.</exception>
	public Note GetNote(int id)
	{
		var entity = _socialNetworkRepository.GetNote(id);

		if (entity == null)
		{
			throw new ValidationException("Запись с указанным идентификатором не найдена!");
		}

		return entity;
	}

	/// <summary>
	/// Создание записи.
	/// </summary>
	/// <param name="model">Модель, в которой содержатся данные для создания записи.</param>
	public void CreateNote(Note model)
	{
		_noteValidator.Validate(model);

		var group = GetGroup(model.GroupId);
		var user = GetUser(model.UserId);

		group.Notes!.Add(model);
		user.Notes!.Add(model);

		model.Group = group;
		model.User = user;

		_socialNetworkRepository.CreateNote(model);
	}

	/// <summary>
	/// Изменение данных записи.
	/// </summary>
	/// <param name="id">Идентификатор записи, данные которой необходимо изменить.</param>
	/// <param name="model">Содержит данные, которые будут присвоены необходимой записи.</param>
	/// <exception cref="ValidationException">Запись с указанным идентификатором не найдена.</exception>
	public void UpdateNote(int id, Note model)
	{
		_noteValidator.Validate(model);

		var group = GetGroup(model.GroupId);
		var user = GetUser(model.UserId);

		group.Notes!.Add(model);
		user.Notes!.Add(model);

		model.Group = group;
		model.User = user;

		_socialNetworkRepository.UpdateNote(id, model);
	}

	/// <summary>
	/// Удаление записи по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор записи, которую необходимо удалить.</param>
	/// <exception cref="ValidationException">Запись с указанным идентификатором не найдена.</exception>
	public void DeleteNote(int id)
	{
		GetNote(id);

		_socialNetworkRepository.DeleteNote(id);
	}

	/// <summary>
	/// Получение всех ролей социальной сети.
	/// </summary>
	/// <returns>Последовательность ролей.</returns>
	public IEnumerable<Role> GetAllRoles() => _socialNetworkRepository.GetAllRoles();

	/// <summary>
	/// Получение роли по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор роли, которую необходимо получить.</param>
	/// <returns>Роль.</returns>
	/// <exception cref="ValidationException">Роль с указанным идентификатором не найдена.</exception>
	public Role GetRole(int id)
	{
		var entity = _socialNetworkRepository.GetRole(id);

		if (entity == null)
		{
			throw new ValidationException("Роль с указанным идентификатором не найдена!");
		}

		return entity;
	}

	/// <summary>
	/// Создание роли.
	/// </summary>
	/// <param name="model">Модель, в которой содержатся данные для создания роли.</param>
	public void CreateRole(Role model)
	{
		_roleValidator.Validate(model);

		_socialNetworkRepository.CreateRole(model);
	}

	/// <summary>
	/// Изменение данных роли.
	/// </summary>
	/// <param name="id">Идентификатор роли, данные которой необходимо изменить.</param>
	/// <param name="model">Содержит данные, которые будут присвоены необходимой роли.</param>
	/// <exception cref="ValidationException">Роль с указанным идентификатором не найдена.</exception>
	public void UpdateRole(int id, Role model)
	{
		GetRole(id);
		_roleValidator.Validate(model);

		_socialNetworkRepository.UpdateRole(id, model);
	}

	/// <summary>
	/// Удаление роли по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор роли, которую необходимо удалить.</param>
	/// <exception cref="ValidationException">Роль с указанным идентификатором не найдена.</exception>
	public void DeleteRole(int id)
	{
		GetRole(id);

		_socialNetworkRepository.DeleteRole(id);
	}


	/// <summary>
	/// Получение всех пользователей социальной сети.
	/// </summary>
	/// <returns>Последовательность пользователей.</returns>
	public IEnumerable<User> GetAllUsers() => _socialNetworkRepository.GetAllUsers();

	/// <summary>
	/// Получение пользователя по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор пользователя, которого необходимо получить.</param>
	/// <returns>Пользователя.</returns>
	/// <exception cref="ValidationException">Пользователь с указанным идентификатором не найден.</exception>
	public User GetUser(int id)
	{
		var entity = _socialNetworkRepository.GetUser(id);

		if (entity == null)
		{
			throw new ValidationException("Пользователь с указанным идентификатором не найден!");
		}

		return entity;
	}

	/// <summary>
	/// Создание пользователя.
	/// </summary>
	/// <param name="model">Модель, в которой содержатся данные для создания пользователя.</param>
	public void CreateUser(User model)
	{
		_userValidator.Validate(model); 

		_socialNetworkRepository.CreateUser(model);
	}

	/// <summary>
	/// Изменение данных пользователя.
	/// </summary>
	/// <param name="id">Идентификатор пользователя, данные которого необходимо изменить.</param>
	/// <param name="model">Содержит данные, которые будут присвоены необходимому пользователю.</param>
	/// <exception cref="ValidationException">Пользователь с указанным идентификатором не найден.</exception>
	public void UpdateUser(int id, User model)
	{
		GetUser(id);
		_userValidator.Validate(model);

		_socialNetworkRepository.UpdateUser(id, model);
	}

	/// <summary>
	/// Удаление пользователя по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор пользователя, которого необходимо удалить.</param>
	/// <exception cref="ValidationException">Пользователь с указанным идентификатором не найден.</exception>
	public void DeleteUser(int id)
	{
		GetUser(id);

		_socialNetworkRepository.DeleteUser(id);

		foreach (var element in _socialNetworkRepository.GetAllGroups().Where(group => group.UserId == id))
		{
			_socialNetworkRepository.DeleteGroup(element.Id);
		}

		foreach (var element in _socialNetworkRepository.GetAllNotes().Where(note => note.UserId == id))
		{
			_socialNetworkRepository.DeleteNote(element.Id);
		}
	}
}