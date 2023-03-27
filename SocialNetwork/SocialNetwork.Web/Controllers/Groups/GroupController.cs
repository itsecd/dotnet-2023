using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Core;
using SocialNetwork.Web.Controllers.Groups.Dto;

namespace SocialNetwork.Web.Controllers.Groups; 

/// <summary>
/// Выполнение CRUD операций для группы.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class GroupController : ControllerBase
{
    /// <summary>
    /// Сервис социальной сети.
    /// </summary>
    private readonly ISocialNetworkService _socialNetworkService; 

	/// <summary>
	/// Создает контроллер с помощью указанных данных.
	/// </summary>
	/// <param name="socialNetworkService">Сервис социальной сети.</param>
	public GroupController(ISocialNetworkService socialNetworkService)
    {
        _socialNetworkService = socialNetworkService;
    }

    /// <summary>
    /// Получение всех групп социальной сети.
    /// </summary>
    /// <returns>Последовательность групп.</returns>
    [HttpGet]
    public IEnumerable<GroupDtoGet> GetAllGroups() =>
        _socialNetworkService.GetAllGroups().Select(group =>
            new GroupDtoGet
            {
                Id = group.Id,
                Name = group.Name,
                Description = group.Description,
                CreationDate = group.CreationDate,
                User = group.User,
                Notes = group.Notes
            });
    
    /// <summary>
    /// Получение группы по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор группы, которую необходимо получить.</param>
    /// <returns>Группу.</returns>
    [HttpGet("{id}")]
    public GroupDtoGet GetGroup(int id)
    {
        var model = _socialNetworkService.GetGroup(id);

        return new GroupDtoGet
		{
			Id = model.Id,
			Name = model.Name,
			Description = model.Description,
			CreationDate = model.CreationDate,
			User = model.User,
			Notes = model.Notes
		};
	}

    /// <summary>
    /// Создание группы.
    /// </summary>
    /// <param name="model">Модель, в которой содержатся данные для создания группы.</param>
    [HttpPost]
    public void CreateGroup([FromBody] GroupDtoPostOrPut model)
    {
        _socialNetworkService.CreateGroup(new Domain.Group
        {
			Name = model.Name,
			Description = model.Description,
			CreationDate = model.CreationDate,
			UserId = model.UserId
		});
    }

    /// <summary>
    /// Изменение данных группы.
    /// </summary>
    /// <param name="id">Идентификатор группы, данные которой необходимо изменить.</param>
    /// <param name="model">Содержит данные, которые будут присвоены необходимой группе.</param>
    [HttpPut("{id}")]
    public void UpdateGroup(int id, [FromBody] GroupDtoPostOrPut model)
    {
		_socialNetworkService.UpdateGroup(id, new Domain.Group
		{
			Name = model.Name,
			Description = model.Description,
			CreationDate = model.CreationDate,
			UserId = model.UserId
		});
	}

    /// <summary>
    /// Удаление группы по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор группы, которую необходимо удалить.</param>
    [HttpDelete("{id}")]
    public void DeleteGroup(int id)
    {
        _socialNetworkService.DeleteGroup(id);
    }
}
