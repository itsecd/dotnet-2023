using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Domain;

namespace SocialNetwork.Web;

/// <summary>
/// Выполнение CRUD операций для записи.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class NoteController : ControllerBase 
{
	/// <summary>
	/// Получение всех записей социальной сети.
	/// </summary>
	/// <returns>Последовательность записей.</returns>
	[HttpGet]
	public IEnumerable<NoteDtoGet> GetAllNotes()
	{
		return null;
	}

	/// <summary>
	/// Получение записи по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор записи, которую необходимо получить.</param>
	/// <returns>Запись.</returns>
	[HttpGet("{id}")]
	public NoteDtoGet GetNote(int id)
	{
		return new NoteDtoGet();
	}

	/// <summary>
	/// Создание записи.
	/// </summary>
	/// <param name="model">Модель, в которой содержатся данные для создания записи.</param>
	[HttpPost]
	public void CreateNote(NoteDtoPostOrPut model)
	{

	}

	/// <summary>
	/// Изменение данных записи.
	/// </summary>
	/// <param name="id">Идентификатор записи, данные которой необходимо изменить.</param>
	/// <param name="model">Содержит данные, которые будут присвоены необходимой записи.</param>
	[HttpPut("{id}")]
	public void UpdateNote(int id, NoteDtoPostOrPut model) 
	{

	}

	/// <summary>
	/// Удаление записи по идентификатору.
	/// </summary>
	/// <param name="id">Идентификатор записи, которую необходимо удалить.</param>
	[HttpDelete("{id}")]
	public void DeleteGroup(int id)
	{

	}
}
