using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Core;
using SocialNetwork.Domain;
using SocialNetwork.Web.Controllers.Users.Dto;

namespace SocialNetwork.Web.Controllers.Users;

/// <summary>
/// Выполнение CRUD операций для пользователя.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
	/// <summary>
	/// Сервис социальной сети.
	/// </summary>
	private readonly ISocialNetworkService _socialNetworkService;

	/// <summary>
	/// Создает контроллер с помощью указанных данных.
	/// </summary>
	/// <param name="socialNetworkService">Сервис социальной сети.</param>
	public UserController(ISocialNetworkService socialNetworkService)
	{
		_socialNetworkService = socialNetworkService;
	}

	/// <summary>
	/// Получение всех пользователей социальной сети.
	/// </summary>
	/// <returns>Последовательность пользователей.</returns>
	[HttpGet]
	public IEnumerable<UserDtoGet> GetAllUsers() => 
		_socialNetworkService.GetAllUsers().Select(user => 
			new UserDtoGet
			{
				Id = user.Id,
				FirstName = user.FirstName,
				LastName = user.LastName,
				Patronymic = user.Patronymic,
				Gender = user.Gender,
				BirthDate = user.BirthDate,
				RegistrationDate = user.RegistrationDate,
				Notes = user.Notes,
				Groups = user.Groups,
				Roles = user.Roles
			});

	/// <summary>
	/// Получение пользователя по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор пользователя, которую необходимо получить.</param>
	/// <returns>Пользователя.</returns>
	[HttpGet("{id}")]
	public UserDtoGet GetUser(int id)
	{
		var entity = _socialNetworkService.GetUser(id);

		return new UserDtoGet
		{
			Id = entity.Id,
			FirstName = entity.FirstName,
			LastName = entity.LastName,
			Patronymic = entity.Patronymic,
			Gender = entity.Gender,
			BirthDate = entity.BirthDate,
			RegistrationDate = entity.RegistrationDate,
			Notes = entity.Notes,
			Groups = entity.Groups,
			Roles = entity.Roles
		};
	}

	/// <summary>
	/// Создание пользователя.
	/// </summary>
	/// <param name="model">Модель, в которой содержатся данные для создания пользователя.</param>
	[HttpPost]
	public void CreateUser([FromBody] UserDtoPostOrPut model)
	{
		_socialNetworkService.CreateUser(new User
		{
			FirstName = model.FirstName,
			LastName = model.LastName,
			Patronymic = model.Patronymic,
			Gender = model.Gender,
			BirthDate = model.BirthDate,
			RegistrationDate = model.RegistrationDate
		});
	}

	/// <summary>
	/// Изменение данных пользователя.
	/// </summary>
	/// <param name="id">Идентификатор пользователя, данные которого необходимо изменить.</param>
	/// <param name="model">Содержит данные, которые будут присвоены необходимому пользователю.</param>
	[HttpPut("{id}")]
	public void UpdateUser(int id, [FromBody] UserDtoPostOrPut model) 
	{
		_socialNetworkService.UpdateUser(id, new User
		{
			FirstName = model.FirstName,
			LastName = model.LastName,
			Patronymic = model.Patronymic,
			Gender = model.Gender,
			BirthDate = model.BirthDate,
			RegistrationDate = model.RegistrationDate
		});
	}

	/// <summary>
	/// Удаление пользователя по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор пользователя, которого необходимо удалить.</param>
	[HttpDelete("{id}")]
	public void DeleteUser(int id) 
	{
		_socialNetworkService.DeleteUser(id);
	}
}
