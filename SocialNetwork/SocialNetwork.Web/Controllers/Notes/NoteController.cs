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

	public NoteController(ISocialNetworkService socialNetworkService)
	{
		_socialNetworkService = socialNetworkService;
	}

	/// <summary>
	/// Получение всех записей социальной сети.
	/// </summary>
	/// <returns>Последовательность записей.</returns>
	[HttpGet(Name = "GetAllNotes")]
	public async Task<IEnumerable<NoteDtoGet>> GetAllNotes() =>
		(await _socialNetworkService.GetAllNotes()).Select(note => 
			new NoteDtoGet
			{
				Id = note.Id,
				Name = note.Name,
				Description = note.Description,
				CreationDate = note.CreationDate,
				UserId = note.UserId,
				GroupId = note.GroupId
			});

	/// <summary>
	/// Получение записи по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор записи, которую необходимо получить.</param>
	/// <returns>Запись.</returns>
	[HttpGet("{id}", Name = "GetNote")]
	public async Task<NoteDtoGet> GetNote(int id)
	{
		var entity = await _socialNetworkService.GetNote(id);

		return new NoteDtoGet
		{
			Id = entity.Id,
			Name = entity.Name,
			Description = entity.Description,
			CreationDate = entity.CreationDate,
			UserId = entity.UserId,
			GroupId = entity.GroupId
		};
	}

	/// <summary>
	/// Создание записи.
	/// </summary>
	/// <param name="model">Модель, в которой содержатся данные для создания записи.</param>
	[HttpPost(Name = "CreateNote")]
	public async Task CreateNote([FromBody] NoteDtoPostOrPut model)
	{
		await _socialNetworkService.CreateNote(new Note
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
	[HttpPut("{id}", Name = "UpdateNote")]
	public async Task UpdateNote(int id, [FromBody] NoteDtoPostOrPut model) 
	{
		await _socialNetworkService.UpdateNote(id, new Note
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
	[HttpDelete("{id}", Name = "DeleteNote")]
	public async Task DeleteNote(int id) 
	{
		await _socialNetworkService.DeleteNote(id);
	}
}
