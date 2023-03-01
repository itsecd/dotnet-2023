using SocialNetwork.Domain;

namespace SocialNetwork.Tests;

/// <summary>
/// Тестирование выполнения Linq запросов к сущностям социальной сети.
/// </summary>
public class LinqTests
{
	#region Методы.
	/// <summary>
	/// Поиск всех пользователей заданной группы, упорядочивание по ФИО.
	/// </summary>
	[Fact]
	public void LinqTestQueryFirst()
	{
		var size = 10;
		var user = new User(20, "Артем", "Стаценко", "Николаевич", "Мужской", DateTime.Now,
			DateTime.Now, new List<Note>(), new List<Group>(), new List<Role>());
		var usersList = new List<User>();
		var group = new Group(1, "IT", "IT", DateTime.Now, 1, user, new List<Note>());
		var result = from c in usersList
					 from a in c.Groups!
					 where a.Name == "IT"
					 orderby c.LastName, c.FirstName, c.Patronymic
					 select c;

		for (var i = 0; i < size; i++)
		{
			usersList.Add(new User(i + 1, $"Артем{i}", $"Стаценко{i}", $"Николаевич{i}", "Мужской", DateTime.Now,
			DateTime.Now, new List<Note>(), new List<Group>() { group }, new List<Role>()));
			Assert.Equal(result.ElementAt(i), usersList[i]);
		}
	}

	/// <summary>
	/// Поиск всех записей, опубликованных в указанной группе, в порядке возрастания.
	/// </summary>
	[Fact]
	public void LinqTestQuerySecond()
	{
		var size = 10;
		var group = new Group(1, "IT", "IT", DateTime.Now, 1, 
			new User(), new List<Note>());
		var notes = new List<Note>();

		for (var i = 0; i < size; i++) 
		{
			group.Notes!.Add(new Note(1, $"Запись{i}", $"Описание записи", DateTime.Now, 1,
				new User(), 1, group));
			notes.Add(new Note(1, $"Запись{i}", $"Описание записи", DateTime.Now, 1,
				new User(), 1, group));
		}

		var result = from c in notes
					 where c.Group!.Name == "IT"
					 orderby c.Group!.Name
					 select c;

		for (var i = 0; i < size; i++)
		{
			Assert.Equal(result.ElementAt(i), notes[i]);
		}
	}

	/// <summary>
	/// Рассчитать количество записей в каждой группе.
	/// </summary>
	[Fact]
	public void LinqTestQueryThird()
	{
		var group = new Group(1, "IT", "IT", DateTime.Now, 1,
			new User(), new List<Note>());

		Assert.True(group.Notes.Count == 0);

		group.Notes.Add(new Note(1, $"Запись1", $"Описание записи", DateTime.Now, 1,
				new User(), 1, group));

		Assert.True(group.Notes.Count == 1);
	}

	/// <summary>
	/// Вывести топ 5 пользователей по созданным записям за указанный период.
	/// </summary>
	[Fact]
	public void LinqTestQueryFourth()
	{
		var notes = new List<Note>();
		var size = 10;
		var group = new Group(1, "IT", "IT", DateTime.Now, 1,
			new User(), new List<Note>());
		var userSecond = new User(2, "Имя", "Фамилия", "Отчество", "Мужской", DateTime.Now,
			DateTime.Now, new List<Note>(), new List<Group>(), new List<Role>());
		var userFirst = new User();

		for (var i = 0; i < size; i++)
		{
			notes.Add(new Note(1, $"Запись1", $"Описание записи", DateTime.Now, 1,
				i >= 7 
				? userSecond 
				: userFirst, 1, group));
		}

		var result = notes.GroupBy(e => new { e.User })
			.Select(a => new
			{
				a.Key.User,
				Count = a.Count(x => x.User == a.Key.User)
			})
			.OrderByDescending(x => x.Count)
			.Take(5);

		Assert.True(result.ElementAt(0).User!.Equals(userFirst) && result
			.ElementAt(1).User!.Equals(userSecond));
	}

	/// <summary>
	/// Поиск групп, в которых опубликовано максимальное число записей.
	/// </summary>
	[Fact]
	public void LinqTestQueryFifth()
	{
		var size = 5;
		var groups = new List<Group>();
		var notesCountInGroups = new List<int> { 1, 2, 3, 3, 2 };

		for (var i = 0; i < size; i++)
		{
			groups.Add(new Group(1, "IT", "IT", DateTime.Now, 1,
				new User(), new List<Note>()));

			for (var j = 0; j < notesCountInGroups[i]; j++)
			{
				groups[i].Notes!.Add(new Note());
			}
		}

		var result = groups.Where(a => a.Notes!.Count == groups.Max(a => a.Notes!.Count)).ToList();

		Assert.True(result.Count == 2 && result[0].Notes!.Count == 3 
			&& result[1].Notes!.Count == 3);
	}
	#endregion
}

