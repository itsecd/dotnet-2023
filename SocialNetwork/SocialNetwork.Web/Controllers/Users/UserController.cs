using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Domain;

namespace SocialNetwork.Web;

/// <summary>
/// Выполнение CRUD операций для пользователя.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
	/// <summary>
	/// Получение всех пользователей социальной сети.
	/// </summary>
	/// <returns>Последовательность пользователей.</returns>
	[HttpGet]
	public IEnumerable<UserDtoGet> GetAllUsers() 
	{
		return null;
	}

	/// <summary>
	/// Получение пользователя по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор пользователя, которую необходимо получить.</param>
	/// <returns>Пользователя.</returns>
	[HttpGet("{id}")]
	public UserDtoGet GetUser(int id)
	{
		return new UserDtoGet();
	}

	/// <summary>
	/// Создание пользователя.
	/// </summary>
	/// <param name="model">Модель, в которой содержатся данные для создания пользователя.</param>
	[HttpPost]
	public void CreateUser(UserDtoPostOrPut model)
	{

	}

	/// <summary>
	/// Изменение данных пользователя.
	/// </summary>
	/// <param name="id">Идентификатор пользователя, данные которого необходимо изменить.</param>
	/// <param name="model">Содержит данные, которые будут присвоены необходимому пользователю.</param>
	[HttpPut("{id}")]
	public void UpdateUser(int id, UserDtoPostOrPut model) 
	{

	}

	/// <summary>
	/// Удаление пользователя по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор пользователя, которого необходимо удалить.</param>
	[HttpDelete("{id}")]
	public void DeleteUser(int id) 
	{

	}
}
