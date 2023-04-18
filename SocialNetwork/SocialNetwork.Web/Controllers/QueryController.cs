using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Core;
using SocialNetwork.Web.Controllers.Groups.Dto;
using SocialNetwork.Web.Controllers.Notes.Dto;
using SocialNetwork.Web.Controllers.Users.Dto;

namespace SocialNetwork.Web;

/// <summary>
/// Выполнение CRUD операций для группы.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class QueryController : ControllerBase
{
	/// <summary>
	/// Сервис социальной сети.
	/// </summary>
	private readonly ISocialNetworkService _socialNetworkService;

	public QueryController(ISocialNetworkService socialNetworkService)
	{
		_socialNetworkService = socialNetworkService;
	}

	/// <summary>
	/// Получение всех пользователей указанной группы, упорядочить по ФИО.
	/// </summary>
	/// <param name="groupName">Название группы.</param>
	/// <returns>Результат запроса.</returns>
	/// <exception cref="ValidationException">Некорректное значение названия группы!</exception>
	[HttpGet("GetUsersByGroupName/{groupName}")]
	public async Task<List<UserDtoGet>> GetUsersByGroupName(string groupName)
	{
		if (string.IsNullOrEmpty(groupName))
		{
			throw new ValidationException("Некорректное значение названия группы!");
		}

		var group = (await _socialNetworkService.GetAllGroups())
			.FirstOrDefault(group => group.Name == groupName);

		if (group == null) 
		{
			throw new NotFoundException("Группа с указанным названием не найдена!");
		}

		var notes = (await _socialNetworkService.GetAllNotes()).Where(note => note.GroupId == group.Id);

		return (await _socialNetworkService.GetAllUsers())
			.Where(user => user.Id == group.UserId
				|| notes.FirstOrDefault(note => note.UserId == user.Id) != null)
			.OrderBy(user => user.LastName)
			.ThenBy(user => user.FirstName)
			.ThenBy(user => user.Patronymic)
			.Select(user => new UserDtoGet
			{
				Id = user.Id,
				FirstName = user.FirstName,
				LastName = user.LastName,
				Patronymic = user.Patronymic,
				Gender = user.Gender,
				BirthDate = user.BirthDate,
				RegistrationDate = user.RegistrationDate
			})
			.ToList();
	}

	/// <summary>
	/// Получение всех записей указанной группы.
	/// </summary>
	/// <param name="groupName">Название группы.</param>
	/// <returns>Результат запроса.</returns>
	/// <exception cref="ValidationException">Некорректное значение названия группы!</exception>
	[HttpGet("GetNotesByGroupName/{groupName}")]
	public async Task<List<NoteDtoGet>> GetNotesByGroupName(string groupName)
	{
		if (string.IsNullOrEmpty(groupName))
		{
			throw new ValidationException("Некорректное значение названия группы!");
		}

		var group = (await _socialNetworkService.GetAllGroups())
			.FirstOrDefault(group => group.Name == groupName);

		if (group == null)
		{
			throw new NotFoundException("Группа с указанным названием не найдена!");
		}

		return (await _socialNetworkService.GetAllNotes())
			.Where(note => note.GroupId == group.Id)
			.Select(note => new NoteDtoGet
			{ 
				Id = note.Id,
				Name = note.Name,
				Description = note.Description,
				CreationDate = note.CreationDate,
				UserId = note.UserId,
				GroupId = note.GroupId
			})
			.ToList();
	}

	/// <summary>
	/// Расчитать суммарное число записей в каждой группе.
	/// </summary>
	/// <returns>Результат запроса.</returns>
	[HttpGet("GetNotesCountInGroup")]
	public async Task<List<int>> GetNotesCountInGroup()
	{
		var notes = await _socialNetworkService.GetAllNotes();

		return (await _socialNetworkService.GetAllGroups()).GroupBy(group => new { group.Name, group.Id })
		.Select(groupObject => new
		{
			groupObject.Key.Name,
			NotesCount = notes.Count(note => note.GroupId == groupObject.Key.Id)
		})
		.Select(groupObj => groupObj.NotesCount)
		.ToList();
	}

	/// <summary>
	/// Получить пользователей в порядке убывания по созданным записям.
	/// </summary>
	/// <param name="usersCount">Количество пользователей, которое необходимо получить.</param>
	/// <returns>Результат запроса.</returns>
	/// <exception cref="ValidationException">Количество пользователей должно быть положительным числом!</exception>
	[HttpGet("GetUsersByCreatedNotes/{usersCount}")]
	public async Task<List<UserDtoGet>> GetUsersByCreatedNotes(int usersCount)
	{
		if (usersCount <= 0)
		{
			throw new ValidationException("Количество пользователей должно быть положительным числом!");
		}

		var notes = await _socialNetworkService.GetAllNotes();

		return notes.GroupBy(note => new { note.UserId })
		.Select(async userObject => new
		{
			User = await _socialNetworkService.GetUser(userObject.Key.UserId),
			NotesCount = notes.Count(note => note.UserId == userObject.Key.UserId) 
		})
		.OrderByDescending(item => item.Result.NotesCount)
		.Take(usersCount)
		.Select(user => new UserDtoGet
		{
			Id = user.Result.User.Id,
			FirstName = user.Result.User.FirstName,
			LastName = user.Result.User.LastName,
			Patronymic = user.Result.User.Patronymic,
			Gender = user.Result.User.Gender,
			BirthDate = user.Result.User.BirthDate,
			RegistrationDate = user.Result.User.RegistrationDate
		})
		.ToList();
	}

	/// <summary>
	/// Получение групп с максимальный количеством записей.
	/// </summary>
	/// <returns>Результат запроса.</returns>
	[HttpGet("GetGroupsWithMaxNotesCount")]
	public async Task<List<GroupDtoGet>> GetGroupsWithMaxNotesCount()
	{
		var notes = await _socialNetworkService.GetAllNotes();
		var groups = await _socialNetworkService.GetAllGroups();

		return groups.Select(groupObject => new 
		{
			Group = _socialNetworkService.GetGroup(groupObject.Id).Result,
			NotesCount = notes.Count(note => note.GroupId == groupObject.Id)
		})
		.Where(group => group.NotesCount == groups.Select(groupObject => new
		{
			groupObject.Id,
			NotesCount = notes.Count(note => note.GroupId == groupObject.Id)
		}).Max(group => group.NotesCount))
		.Select(group => new GroupDtoGet
		{
			Id = group.Group.Id,
			Name = group.Group.Name,
			Description = group.Group.Description,
			CreationDate = group.Group.CreationDate,
			UserId = group.Group.UserId
		})
		.ToList();
	}
}
