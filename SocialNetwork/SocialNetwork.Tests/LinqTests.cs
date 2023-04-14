using SocialNetwork.Domain;

namespace SocialNetwork.Tests;

/// <summary>
/// Тестирование выполнения Linq запросов к сущностям социальной сети.
/// </summary>
public class LinqTests
{
	/// <summary>
	/// Поиск всех пользователей заданной группы, упорядочивание по ФИО.
	/// </summary>
	[Fact]
	public void LinqTestQueryFirst()
	{
		var size = 10;
		var userForTest = new User(20, "Артем", "Стаценко", "Николаевич", "Мужской", DateTime.Now,
			DateTime.Now, new List<Note>(), new List<Group>(), new List<Role>());
		var usersList = new List<User>();
		var group = new Group(1, "IT", "IT", DateTime.Now, 1, userForTest, new List<Note>());

		for (var i = 0; i < size; i++)
		{
			usersList.Add(new User(i + 1, $"Артем{i}", $"Стаценко{i}", $"Николаевич{i}", "Мужской", DateTime.Now,
				DateTime.Now, new List<Note>(), new List<Group>() { group }, new List<Role>()));
		}

		var result = (from user in usersList
					  from gr in user.Groups!
					  where gr.Name == "IT"
					  orderby user.LastName, user.FirstName, user.Patronymic
					  select user).ToList();

		for (var i = 0; i < size; i++)
		{
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
			group.Notes!.Add(new Note(1, $"Запись{i}", "Описание записи", DateTime.Now, 1,
				new User(), 1, group));
			notes.Add(new Note(1, $"Запись{i}", "Описание записи", DateTime.Now, 1,
				new User(), 1, group));
		}

		var result = (from note in notes
					 where note.Group!.Name == "IT"
					 orderby note.Group!.Name
					 select note).ToList();

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

		Assert.True(group.Notes!.Count == 0);

		group.Notes.Add(new Note(1, "Запись1", "Описание записи", DateTime.Now, 1,
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
			notes.Add(new Note(1, "Запись", "Описание записи", DateTime.Now, 1,
				i >= 7 
				? userSecond 
				: userFirst, 1, group));
		}

		var result = notes.GroupBy(note => new { note.User })
			.Select(newUser => new
			{
				newUser.Key.User,
				Count = newUser.Count(el => el.User == newUser.Key.User)
			})
			.OrderByDescending(item => item.Count)
			.Take(5).ToList();

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

		var result = groups.Where(group => group.Notes!.Count == groups.Max(gr => gr.Notes!.Count)).ToList();

		Assert.True(result.Count == 2 && result[0].Notes!.Count == 3 
			&& result[1].Notes!.Count == 3);
	}
}

