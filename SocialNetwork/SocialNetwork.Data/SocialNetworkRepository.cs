using Microsoft.EntityFrameworkCore;
using SocialNetwork.Core;
using SocialNetwork.Data.Models;
using SocialNetwork.Domain;

namespace SocialNetwork.Data;

/// <summary>
/// Репозиторий социальной сети.
/// </summary>
public class SocialNetworkRepository : ISocialNetworkRepository
{
	/// <summary>
	/// Контекст социальной сети.
	/// </summary>
	private readonly SocialNetworkContext _context;

	public SocialNetworkRepository(SocialNetworkContext context)
	{
		_context = context;
	}

	/// <summary>
	/// Получение всех групп социальной сети.
	/// </summary>
	/// <returns>Последовательность групп.</returns>
	public async Task<IEnumerable<Group>> GetAllGroups()
	{
		var groups = await _context.Groups.ToListAsync();
		var result = new List<Group>();

		foreach (var group in groups)
		{
			result.Add(new Group
			{
				Id = group.Id,
				Name = group.Name,
				Description = group.Description,
				CreationDate = group.CreationDate,
				UserId = group.UserId,
			});
		}

		return result;
	}

	/// <summary>
	/// Получение группы по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор группы, которую необходимо получить.</param>
	/// <returns>Группу.</returns>
	public async Task<Group?> GetGroup(int id)
	{
		var group = await _context.Groups.FirstOrDefaultAsync(group => group.Id == id);

		return group == null 
			? null 
			: new Group
			{
				Id = group.Id,
				Name = group.Name,
				Description = group.Description,
				CreationDate = group.CreationDate,
				UserId = group.UserId,
			};
	}
		
	/// <summary>
	/// Создание группы.
	/// </summary>
	/// <param name="model">Модель, в которой содержатся данные для создания группы.</param>
	public async Task<int> CreateGroup(Group model)
	{
		var groupDbModel = new GroupDbModel
		{
			Name = model.Name,
			Description = model.Description,
			CreationDate = model.CreationDate,
			UserId = model.UserId,
		};

		await _context.Groups.AddAsync(groupDbModel);

		var adminRole = await _context.Roles.FirstOrDefaultAsync(role =>  
			role.Name == "Админ");

		if (adminRole == null) 
		{
			await CreateRole(new Role
			{
				Name = "Админ"
			});

			adminRole = await _context.Roles.FirstOrDefaultAsync(role =>
				role.Name == "Админ");

			if (adminRole == null) 
			{
				throw new Exception("Внутренняя ошибка сервера!");
			}
		}

		await _context.SaveChangesAsync();

		await _context.UsersGroupsRoles.AddAsync(new UserGroupRoleDbModel
		{
			UserId = model.UserId,
			GroupId = groupDbModel.Id,
			RoleId = adminRole.Id
		});

		await _context.SaveChangesAsync();

		return groupDbModel.Id;
	}

	/// <summary>
	/// Изменение данных группы.
	/// </summary>
	/// <param name="id">Идентификатор группы, данные которой необходимо изменить.</param>
	/// <param name="model">Содержит данные, которые будут присвоены необходимой группе.</param>
	public async Task UpdateGroup(int id, Group model)
	{
		var entity = await _context.Groups.FirstAsync(group => group.Id == id);

		entity.Name = model.Name;
		entity.Description = model.Description;
		entity.CreationDate = model.CreationDate;
		entity.UserId = model.UserId;

		await _context.SaveChangesAsync();
	}

	/// <summary>
	/// Удаление группы по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор группы, которую необходимо удалить.</param>
	public async Task DeleteGroup(int id)
	{
		_context.Groups.Remove(await _context.Groups.FirstAsync(group => group.Id == id));

		_context.UsersGroupsRoles.RemoveRange((await _context
			.UsersGroupsRoles.ToListAsync()).Where(userRoleGroup => userRoleGroup.GroupId == id));

		await _context.SaveChangesAsync();
	}

	/// <summary>
	/// Получение всех записей социальной сети.
	/// </summary>
	/// <returns>Последовательность записей.</returns>
	public async Task<IEnumerable<Note>> GetAllNotes()
	{
		var notes = await _context.Notes.ToListAsync(); 
		var result = new List<Note>();

		foreach (var note in notes)
		{
			result.Add(new Note
			{
				Id = note.Id,
				Name = note.Name,
				Description = note.Description,
				CreationDate = note.CreationDate,
				UserId = note.UserId,
				GroupId = note.GroupId,
			});
		}

		return result;
	}

	/// <summary>
	/// Получение записи по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор записи, которую необходимо получить.</param>
	/// <returns>Запись.</returns>
	public async Task<Note?> GetNote(int id)
	{
		var note = await _context.Notes.FirstOrDefaultAsync(note => note.Id == id);

		return note == null
			? null
			: new Note
			{
				Id = note.Id,
				Name = note.Name,
				Description = note.Description,
				CreationDate = note.CreationDate,
				UserId = note.UserId,
				GroupId = note.GroupId
			};
	}
	
	/// <summary>
	/// Создание записи.
	/// </summary>
	/// <param name="model">Модель, в которой содержатся данные для создания записи.</param>
	public async Task<int> CreateNote(Note model)
	{
		var noteDbModel = new NoteDbModel
		{
			Name = model.Name,
			Description = model.Description,
			CreationDate = model.CreationDate,
			UserId = model.UserId,
			GroupId = model.GroupId
		};

		await _context.Notes.AddAsync(noteDbModel);

		await _context.SaveChangesAsync();

		return noteDbModel.Id;
	}

	/// <summary>
	/// Изменение данных записи.
	/// </summary>
	/// <param name="id">Идентификатор записи, данные которой необходимо изменить.</param>
	/// <param name="model">Содержит данные, которые будут присвоены необходимой записи.</param>
	public async Task UpdateNote(int id, Note model)
	{
		var entity = await _context.Notes.FirstAsync(note => note.Id == id);

		entity.Name = model.Name;
		entity.Description = model.Description;
		entity.CreationDate = model.CreationDate;
		entity.UserId = model.UserId;
		entity.GroupId = model.GroupId;

		await _context.SaveChangesAsync();
	}

	/// <summary>
	/// Удаление записи по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор записи, которую необходимо удалить.</param>
	public async Task DeleteNote(int id)
	{
		_context.Notes.Remove(await _context.Notes.FirstAsync(note => note.Id == id));

		await _context.SaveChangesAsync();
	}

	/// <summary>
	/// Получение всех ролей социальной сети.
	/// </summary>
	/// <returns>Последовательность ролей.</returns>
	public async Task<IEnumerable<Role>> GetAllRoles()
	{
		var roles = await _context.Roles.ToListAsync();
		var result = new List<Role>();

		foreach (var role in roles)
		{
			result.Add(new Role
			{
				Id = role.Id,
				Name = role.Name,
			});
		}

		return result;
	}

	/// <summary>
	/// Получение роли по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор роли, которую необходимо получить.</param>
	/// <returns>Роль.</returns>
	public async Task<Role?> GetRole(int id)
	{
		var role = await _context.Roles.FirstOrDefaultAsync(role => role.Id == id);

		return role == null
			? null
			: new Role
			{
				Id = role.Id,
				Name = role.Name,
			};
	}

	/// <summary>
	/// Создание роли.
	/// </summary>
	/// <param name="model">Модель, в которой содержатся данные для создания роли.</param>
	public async Task<int> CreateRole(Role model)
	{
		var roleDbModel = new RoleDbModel
		{
			Name = model.Name
		};

		await _context.Roles.AddAsync(roleDbModel);

		await _context.SaveChangesAsync();

		return roleDbModel.Id;
	}

	/// <summary>
	/// Изменение данных роли.
	/// </summary>
	/// <param name="id">Идентификатор роли, данные которой необходимо изменить.</param>
	/// <param name="model">Содержит данные, которые будут присвоены необходимой роли.</param>
	public async Task UpdateRole(int id, Role model)
	{
		var entity = await _context.Roles.FirstAsync(role => role.Id == id);

		entity.Name = model.Name;

		await _context.SaveChangesAsync();
	}

	/// <summary>
	/// Удаление роли по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор роли, которую необходимо удалить.</param>
	public async Task DeleteRole(int id)
	{
		_context.Roles.Remove(await _context.Roles.FirstAsync(role => role.Id == id));

		_context.UsersGroupsRoles.RemoveRange((await _context
			.UsersGroupsRoles.ToListAsync()).Where(userRoleGroup => userRoleGroup.RoleId == id));

		await _context.SaveChangesAsync();
	}

	/// <summary>
	/// Получение всех пользователей социальной сети.
	/// </summary>
	/// <returns>Последовательность пользователей.</returns>
	public async Task<IEnumerable<User>> GetAllUsers()
	{
		var users = await _context.Users.ToListAsync(); 
		var result = new List<User>();

		foreach (var user in users)
		{
			result.Add(new User
			{
				Id = user.Id,
				FirstName = user.FirstName,
				LastName = user.LastName,
				Patronymic = user.Patronymic,
				Gender = user.Gender,
				BirthDate = user.BirthDate,
				RegistrationDate = user.RegistrationDate,
			});
		}

		return result;
	}

	/// <summary>
	/// Получение пользователя по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор пользователя, которого необходимо получить.</param>
	/// <returns>Пользователя.</returns>
	public async Task<User?> GetUser(int id)
	{
		var user = await _context.Users.FirstOrDefaultAsync(user => user.Id == id);

		return user == null
			? null
			: new User
			{
				Id = user.Id,
				FirstName = user.FirstName,
				LastName = user.LastName,
				Patronymic = user.Patronymic,
				Gender = user.Gender,
				BirthDate = user.BirthDate,
				RegistrationDate = user.RegistrationDate,
			};
	}

	/// <summary>
	/// Создание пользователя.
	/// </summary>
	/// <param name="model">Модель, в которой содержатся данные для создания пользователя.</param>
	public async Task<int> CreateUser(User model)
	{
		var userDbModel = new UserDbModel
		{
			FirstName = model.FirstName,
			LastName = model.LastName,
			Patronymic = model.Patronymic,
			Gender = model.Gender,
			BirthDate = model.BirthDate,
			RegistrationDate = model.RegistrationDate
		};

		await _context.Users.AddAsync(userDbModel);

		await _context.SaveChangesAsync();

		return userDbModel.Id;
	}

	/// <summary>
	/// Изменение данных пользователя.
	/// </summary>
	/// <param name="id">Идентификатор пользователя, данные которого необходимо изменить.</param>
	/// <param name="model">Содержит данные, которые будут присвоены необходимому пользователю.</param>
	public async Task UpdateUser(int id, User model)
	{
		var entity = await _context.Users.FirstAsync(user => user.Id == id);

		entity.FirstName = model.FirstName;
		entity.LastName = model.LastName;
		entity.Patronymic = model.Patronymic;
		entity.Gender = model.Gender;
		entity.BirthDate = model.BirthDate;
		entity.RegistrationDate = model.RegistrationDate;

		await _context.SaveChangesAsync();
	}

	/// <summary>
	/// Удаление пользователя по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор пользователя, которого необходимо удалить.</param>
	public async Task DeleteUser(int id)
	{
		_context.Users.Remove(await _context.Users.FirstAsync(user => user.Id == id));

		_context.UsersGroupsRoles.RemoveRange((await _context
			.UsersGroupsRoles.ToListAsync()).Where(userRoleGroup => userRoleGroup.UserId == id));

		await _context.SaveChangesAsync();
	}
}
