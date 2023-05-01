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

	public UserController(ISocialNetworkService socialNetworkService)
	{
		_socialNetworkService = socialNetworkService;
	}

	/// <summary>
	/// Получение всех пользователей социальной сети.
	/// </summary>
	/// <returns>Последовательность пользователей.</returns>
	[HttpGet(Name = "GetAllUsers")]
	public async Task<IEnumerable<UserDtoGet>> GetAllUsers() => 
		(await _socialNetworkService.GetAllUsers()).Select(user => 
			new UserDtoGet
			{
				Id = user.Id,
				FirstName = user.FirstName,
				LastName = user.LastName,
				Patronymic = user.Patronymic,
				Gender = user.Gender,
				BirthDate = user.BirthDate,
				RegistrationDate = user.RegistrationDate,
			});

	/// <summary>
	/// Получение пользователя по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор пользователя, которую необходимо получить.</param>
	/// <returns>Пользователя.</returns>
	[HttpGet("{id}", Name = "GetUser")]
	public async Task<UserDtoGet> GetUser(int id)
	{
		var entity = await _socialNetworkService.GetUser(id);

		return new UserDtoGet
		{
			Id = entity.Id,
			FirstName = entity.FirstName,
			LastName = entity.LastName,
			Patronymic = entity.Patronymic,
			Gender = entity.Gender,
			BirthDate = entity.BirthDate,
			RegistrationDate = entity.RegistrationDate,
		};
	}

	/// <summary>
	/// Создание пользователя.
	/// </summary>
	/// <param name="model">Модель, в которой содержатся данные для создания пользователя.</param>
	[HttpPost(Name = "CreateUser")]
	public async Task<int> CreateUser([FromBody] UserDtoPostOrPut model)
		=> await _socialNetworkService.CreateUser(new User
		{
			FirstName = model.FirstName,
			LastName = model.LastName,
			Patronymic = model.Patronymic,
			Gender = model.Gender,
			BirthDate = model.BirthDate,
			RegistrationDate = model.RegistrationDate
		});

	/// <summary>
	/// Изменение данных пользователя.
	/// </summary>
	/// <param name="id">Идентификатор пользователя, данные которого необходимо изменить.</param>
	/// <param name="model">Содержит данные, которые будут присвоены необходимому пользователю.</param>
	[HttpPut("{id}", Name = "UpdateUser")]
	public async Task UpdateUser(int id, [FromBody] UserDtoPostOrPut model) 
	{
		await _socialNetworkService.UpdateUser(id, new User
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
	[HttpDelete("{id}", Name = "DeleteUser")]
	public async Task DeleteUser(int id) 
	{
		await _socialNetworkService.DeleteUser(id);
	}
}
