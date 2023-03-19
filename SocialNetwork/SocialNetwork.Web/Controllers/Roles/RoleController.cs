using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Domain;

namespace SocialNetwork.Web;

/// <summary>
/// Выполнение CRUD операций для роли.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RoleController : ControllerBase
{
	/// <summary>
	/// Получение всех ролей социальной сети.
	/// </summary>
	/// <returns>Последовательность ролей.</returns>
	[HttpGet]
	public IEnumerable<RoleDtoGet> GetAllRoles() 
	{
		return null;
	}

	/// <summary>
	/// Получение роли по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор роли, которую необходимо получить.</param>
	/// <returns>Роль.</returns>
	[HttpGet("{id}")]
	public RoleDtoGet GetRole(int id) 
	{
		return new RoleDtoGet();
	}

	/// <summary>
	/// Создание роли.
	/// </summary>
	/// <param name="model">Модель, в которой содержатся данные для создания роли.</param>
	[HttpPost]
	public void CreateRole(RoleDtoPostOrPut model)
	{

	}

	/// <summary>
	/// Изменение данных роли.
	/// </summary>
	/// <param name="id">Идентификатор роли, данные которой необходимо изменить.</param>
	/// <param name="model">Содержит данные, которые будут присвоены необходимой роли.</param>
	[HttpPut("{id}")]
	public void UpdateRole(int id, RoleDtoPostOrPut model)
	{

	}

	/// <summary>
	/// Удаление роли по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор роли, которую необходимо удалить.</param>
	[HttpDelete("{id}")]
	public void DeleteRole(int id) 
	{

	}
}
