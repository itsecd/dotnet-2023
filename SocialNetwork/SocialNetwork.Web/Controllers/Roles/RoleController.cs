using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Core;
using SocialNetwork.Domain;
using SocialNetwork.Web.Controllers.Roles.Dto;

namespace SocialNetwork.Web.Controllers.Roles;

/// <summary>
/// Выполнение CRUD операций для роли.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RoleController : ControllerBase
{
	/// <summary>
	/// Сервис социальной сети.
	/// </summary>
	private readonly ISocialNetworkService _socialNetworkService;

	public RoleController(ISocialNetworkService socialNetworkService) 
	{
		_socialNetworkService = socialNetworkService;
	}

	/// <summary>
	/// Получение всех ролей социальной сети.
	/// </summary>
	/// <returns>Последовательность ролей.</returns>
	[HttpGet]
	public async Task<IEnumerable<RoleDtoGet>> GetAllRoles() => 
		(await _socialNetworkService.GetAllRoles()).Select(role =>
			new RoleDtoGet
			{
				Id = role.Id,
				Name = role.Name
			});

	/// <summary>
	/// Получение роли по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор роли, которую необходимо получить.</param>
	/// <returns>Роль.</returns>
	[HttpGet("{id}")]
	public async Task<RoleDtoGet> GetRole(int id) 
	{
		var entity = await _socialNetworkService.GetRole(id);

		return new RoleDtoGet
		{
			Id = entity.Id,
			Name = entity.Name
		};
	}

	/// <summary>
	/// Создание роли.
	/// </summary>
	/// <param name="model">Модель, в которой содержатся данные для создания роли.</param>
	[HttpPost]
	public async Task CreateRole([FromBody] RoleDtoPostOrPut model)
	{
		await _socialNetworkService.CreateRole(new Role
		{
			Name = model.Name
		});
	}

	/// <summary>
	/// Изменение данных роли.
	/// </summary>
	/// <param name="id">Идентификатор роли, данные которой необходимо изменить.</param>
	/// <param name="model">Содержит данные, которые будут присвоены необходимой роли.</param>
	[HttpPut("{id}")]
	public async Task UpdateRole(int id, [FromBody] RoleDtoPostOrPut model)
	{
		await _socialNetworkService.UpdateRole(id, new Role
		{
			Name = model.Name
		});
	}

	/// <summary>
	/// Удаление роли по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор роли, которую необходимо удалить.</param>
	[HttpDelete("{id}")]
	public async Task DeleteRole(int id) 
	{
		await _socialNetworkService.DeleteRole(id);
	}
}
