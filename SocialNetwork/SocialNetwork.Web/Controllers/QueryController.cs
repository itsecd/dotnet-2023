using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Core;
using SocialNetwork.Domain;

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
	/// Получение всех пользователей указанной группы.
	/// </summary>
	/// <param name="groupName">Название группы.</param>
	/// <returns>Результат запроса.</returns>
	/// <exception cref="ValidationException">Некорректное значение названия группы!</exception>
	[HttpGet("GetUsersByGroupName/{groupName}")]
	public async Task<List<User>> GetUsersByGroupName(string groupName)
	{
		if (groupName == null || groupName.Length == 0)
		{
			throw new ValidationException("Некорректное значение названия группы!");
		}

		return (from user in await _socialNetworkService.GetAllUsers()
				from gr in user.Groups!
				where gr.Name == groupName
				orderby user.LastName, user.FirstName, user.Patronymic
				select user).ToList();
	}

	/// <summary>
	/// Получение всех пользователей указанной группы.
	/// </summary>
	/// <param name="groupName">Название группы.</param>
	/// <returns>Результат запроса.</returns>
	/// <exception cref="ValidationException">Некорректное значение названия группы!</exception>
	[HttpGet("GetNotesByGroupName/{groupName}")]
	public async Task<List<Note>> GetNotesByGroupName(string groupName)
	{
		if (groupName == null || groupName.Length == 0)
		{
			throw new ValidationException("Некорректное значение названия группы!");
		}

		return (from note in await _socialNetworkService.GetAllNotes()
				where note.Group!.Name == groupName
				orderby note.Group!.Name
				select note).ToList();
	}

	/// <summary>
	/// Расчитать суммарное число записей в каждой группе.
	/// </summary>
	/// <returns>Результат запроса.</returns>
	[HttpGet("GetNotesCountInGroup")]
	public async Task<List<int>> GetNotesCountInGroup() =>
		(from gr in await _socialNetworkService.GetAllGroups()
		 select gr.Notes!.Count).ToList();

	/// <summary>
	/// Получить пользователей в порядке убывания по созданным записям.
	/// </summary>
	/// <param name="usersCount">Количество пользователей, которое необходимо получить.</param>
	/// <returns>Результат запроса.</returns>
	/// <exception cref="ValidationException">Количество пользователей должно быть положительным числом!</exception>
	[HttpGet("GetUsersByCreatedNotes/{usersCount}")]
	public async Task<List<User?>> GetUsersByCreatedNotes(int usersCount)
	{
		if (usersCount <= 0)
		{
			throw new ValidationException("Количество пользователей должно быть положительным числом!");
		}

		return (await _socialNetworkService.GetAllNotes()).GroupBy(element => new { element.User })
		.Select(newElement => new
		{
			newElement.Key.User,
			Count = newElement.Count(el => el.User == newElement.Key.User)
		})
		.OrderByDescending(item => item.Count)
		.Take(usersCount)
		.Select(element => element.User)
		.ToList();
	}

	/// <summary>
	/// Получение групп с максимальный количеством записей.
	/// </summary>
	/// <returns>Результат запроса.</returns>
	[HttpGet("GetGroupsWithMaxNotesCount")]
	public async Task<List<Group>> GetGroupsWithMaxNotesCount() =>
		(await _socialNetworkService.GetAllGroups())
			.Where(group => group.Notes!.Count == _socialNetworkService.GetAllGroups().Result
			.Max(gr => gr.Notes!.Count)).ToList();
}
