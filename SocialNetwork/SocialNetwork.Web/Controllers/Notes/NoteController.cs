using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Core;
using SocialNetwork.Domain;
using SocialNetwork.Web.Controllers.Notes.Dto;

namespace SocialNetwork.Web.Controllers.Notes;

/// <summary>
/// Выполнение CRUD операций для записи.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class NoteController : ControllerBase 
{
	/// <summary>
	/// Сервис социальной сети.
	/// </summary>
	private readonly ISocialNetworkService _socialNetworkService;

	/// <summary>
	/// Создает контроллер с помощью указанных данных.
	/// </summary>
	/// <param name="socialNetworkService">Сервис социальной сети.</param>
	public NoteController(ISocialNetworkService socialNetworkService)
	{
		_socialNetworkService = socialNetworkService;
	}

	/// <summary>
	/// Получение всех записей социальной сети.
	/// </summary>
	/// <returns>Последовательность записей.</returns>
	[HttpGet]
	public IEnumerable<NoteDtoGet> GetAllNotes() =>
		_socialNetworkService.GetAllNotes().Select(note => 
			new NoteDtoGet
			{
				Id = note.Id,
				Name = note.Name,
				Description = note.Description,
				CreationDate = note.CreationDate,
				User = note.User,
				Group = note.Group
			});

	/// <summary>
	/// Получение записи по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор записи, которую необходимо получить.</param>
	/// <returns>Запись.</returns>
	[HttpGet("{id}")]
	public NoteDtoGet GetNote(int id)
	{
		var entity = _socialNetworkService.GetNote(id);

		return new NoteDtoGet
		{
			Id = entity.Id,
			Name = entity.Name,
			Description = entity.Description,
			CreationDate = entity.CreationDate,
			User = entity.User,
			Group = entity.Group
		};
	}

	/// <summary>
	/// Создание записи.
	/// </summary>
	/// <param name="model">Модель, в которой содержатся данные для создания записи.</param>
	[HttpPost]
	public void CreateNote([FromBody] NoteDtoPostOrPut model)
	{
		_socialNetworkService.CreateNote(new Note
		{
			Name = model.Name,
			Description = model.Description,
			CreationDate = model.CreationDate,
			UserId = model.UserId,
			GroupId  = model.GroupId
		});
	}

	/// <summary>
	/// Изменение данных записи.
	/// </summary>
	/// <param name="id">Идентификатор записи, данные которой необходимо изменить.</param>
	/// <param name="model">Содержит данные, которые будут присвоены необходимой записи.</param>
	[HttpPut("{id}")]
	public void UpdateNote(int id, [FromBody] NoteDtoPostOrPut model) 
	{
		_socialNetworkService.UpdateNote(id, new Note
		{
			Name = model.Name,
			Description = model.Description,
			CreationDate = model.CreationDate,
			UserId = model.UserId,
			GroupId = model.GroupId
		});
	}

	/// <summary>
	/// Удаление записи по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор записи, которую необходимо удалить.</param>
	[HttpDelete("{id}")]
	public void DeleteNote(int id) 
	{
		_socialNetworkService.DeleteNote(id);
	}
}
