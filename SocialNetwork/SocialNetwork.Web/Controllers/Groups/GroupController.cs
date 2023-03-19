using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Domain;

namespace SocialNetwork.Web; 

/// <summary>
/// Выполнение CRUD операций для группы.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class GroupController : ControllerBase
{
    /// <summary>
    /// Получение всех групп социальной сети.
    /// </summary>
    /// <returns>Последовательность групп.</returns>
    [HttpGet]
    public IEnumerable<GroupDtoGet> GetAllGroups()
    {
        return null;
    }

    /// <summary>
    /// Получение группы по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор группы, которую необходимо получить.</param>
    /// <returns>Группу.</returns>
    [HttpGet("{id}")]
    public GroupDtoGet GetGroup(int id)
    {
        return new GroupDtoGet();
    }

    /// <summary>
    /// Создание группы.
    /// </summary>
    /// <param name="model">Модель, в которой содержатся данные для создания группы.</param>
    [HttpPost]
    public void CreateGroup(GroupDtoPostOrPut model)
    {

    }

    /// <summary>
    /// Изменение данных группы.
    /// </summary>
    /// <param name="id">Идентификатор группы, данные которой необходимо изменить.</param>
    /// <param name="model">Содержит данные, которые будут присвоены необходимой группе.</param>
    [HttpPut("{id}")]
    public void UpdateGroup(int id, GroupDtoPostOrPut model)
    {

    }

    /// <summary>
    /// Удаление группы по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор группы, которую необходимо удалить.</param>
    [HttpDelete("{id}")]
    public void DeleteGroup(int id)
    {

    }
}
