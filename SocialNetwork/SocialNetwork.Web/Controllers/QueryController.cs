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

	/// <summary>
	/// Создает контроллер с помощью указанных данных.
	/// </summary>
	/// <param name="socialNetworkService">Сервис социальной сети.</param>
	public QueryController(ISocialNetworkService socialNetworkService)
	{
		_socialNetworkService = socialNetworkService;
	}

	/// <summary>
	/// Получение всех пользователей указанной группы.
	/// </summary>
	/// <param name="groupName">Название группы.</param>
	/// <returns>Результат запроса.</returns>
	[HttpGet("GetUsersByGroupName/{groupName}")]
	public List<User> GetUsersByGroupName(string groupName)
	{
		if (groupName == null || groupName.Length == 0)
		{
			throw new ValidationException("Некорректное значение названия группы!");
		}

		return (from user in _socialNetworkService.GetAllUsers()
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
	[HttpGet("GetNotesByGroupName/{groupName}")]
	public List<Note> GetNotesByGroupName(string groupName)
	{
		if (groupName == null || groupName.Length == 0)
		{
			throw new ValidationException("Некорректное значение названия группы!");
		}

		return (from note in _socialNetworkService.GetAllNotes()
				where note.Group!.Name == groupName
				orderby note.Group!.Name
				select note).ToList();
	}

	/// <summary>
	/// Расчитать суммарное число записей в каждой группе.
	/// </summary>
	/// <returns>Результат запроса.</returns>
	[HttpGet("GetNotesCountInGroup")]
	public List<int> GetNotesCountInGroup() =>
		(from gr in _socialNetworkService.GetAllGroups()
		 select gr.Notes!.Count).ToList();

	/// <summary>
	/// Получить пользователей в порядке убывания по созданным записям.
	/// </summary>
	/// <param name="usersCount">Количество пользователей, которое необходимо получить.</param>
	/// <returns>Результат запроса.</returns>
	[HttpGet("GetUsersByCreatedNotes/{usersCount}")]
	public List<User?> GetUsersByCreatedNotes(int usersCount)
	{
		if (usersCount <= 0)
		{
			throw new ValidationException("Количество пользователей должно быть положительным числом.");
		}

		return _socialNetworkService.GetAllNotes().GroupBy(element => new { element.User })
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
	public List<Domain.Group> GetGroupsWithMaxNotesCount() =>
		_socialNetworkService.GetAllGroups()
			.Where(group => group.Notes!.Count == _socialNetworkService.GetAllGroups()
			.Max(gr => gr.Notes!.Count)).ToList();
}
