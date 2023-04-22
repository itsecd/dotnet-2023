using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Core;
using SocialNetwork.Domain;
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

	public GroupController(ISocialNetworkService socialNetworkService)
    {
        _socialNetworkService = socialNetworkService;
    }

    /// <summary>
    /// Получение всех групп социальной сети.
    /// </summary>
    /// <returns>Последовательность групп.</returns>
    [HttpGet(Name = "GetAllGroups")]
    public async Task<IEnumerable<GroupDtoGet>> GetAllGroups() =>
        (await _socialNetworkService.GetAllGroups()).Select(group =>
            new GroupDtoGet
            {
                Id = group.Id,
                Name = group.Name,
                Description = group.Description,
                CreationDate = group.CreationDate,
                UserId = group.UserId,
            });

    /// <summary>
    /// Получение группы по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор группы, которую необходимо получить.</param>
    /// <returns>Группу.</returns>
    [HttpGet("{id}", Name = "GetGroup")]
    public async Task<GroupDtoGet> GetGroup(int id)
    {
        var model = await _socialNetworkService.GetGroup(id);

        return new GroupDtoGet
		{
			Id = model.Id,
			Name = model.Name,
			Description = model.Description,
			CreationDate = model.CreationDate,
			UserId = model.UserId,
		};
	}

    /// <summary>
    /// Создание группы.
    /// </summary>
    /// <param name="model">Модель, в которой содержатся данные для создания группы.</param>
    [HttpPost(Name = "CreateGroup")]
    public async Task CreateGroup([FromBody] GroupDtoPostOrPut model)
    {
        await _socialNetworkService.CreateGroup(new Group
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
    [HttpPut("{id}", Name = "UpdateGroup")]
    public async Task UpdateGroup(int id, [FromBody] GroupDtoPostOrPut model)
    {
		await _socialNetworkService.UpdateGroup(id, new Group
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
    [HttpDelete("{id}", Name = "DeleteGroup")]
    public async Task DeleteGroup(int id)
    {
        await _socialNetworkService.DeleteGroup(id);
    }
}
