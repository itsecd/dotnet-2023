using SocialNetwork.Domain;

namespace SocialNetwork.Tests;

/// <summary>
/// Тестирование библиотеки классов сущностей социальной сети.
/// </summary>
public class SocialNetworkClassesTests 
{
	#region Методы.
	/// <summary>
	/// Создание группы с некорректными параметрами в конструкторе.
	/// </summary>
	/// <param name="groupId">Идентификатор группы.</param>
	/// <param name="name">Название группы.</param>
	/// <param name="description">Описание группы.</param>
	/// <param name="userId">Идентификатор создателя группы.</param>
	/// <param name="isCorrectUser">Корректный ли пользователь будет указан в конструкторе.</param>
	/// <param name="isCorrectNotesList">Корректный ли список записей будет указан в конструкторе.</param>
	/// <param name="exceptionType">Тип исключения, которое должно быть вызвано.</param>
	[Theory]
	[InlineData(-1, "Группа", "Описание группы", 1, true, true, typeof(ArgumentOutOfRangeException))]
	[InlineData(1, null, "Описание группы", 1, true, true, typeof(ArgumentNullException))]
	[InlineData(1, "Группа", null, 1, true, true, typeof(ArgumentNullException))]
	[InlineData(1, "Группа", "Описание группы", -1, true, true, typeof(ArgumentOutOfRangeException))]
	[InlineData(1, "Группа", "Описание группы", 1, false, true, typeof(ArgumentNullException))]
	[InlineData(1, "Группа", "Описание группы", 1, true, false, typeof(ArgumentNullException))]
	public void InitGroupWithIncorrectValueShouldThrowException(int groupId, string name, string description, 
		int userId, bool isCorrectUser, bool isCorrectNotesList, Type exceptionType) 
	{
		try
		{
			new Domain.Group(groupId, name, description, DateTime.Now, userId,
				isCorrectUser ? new User() : null, isCorrectNotesList ? new List<Note>() : null);
			Assert.Fail("Exception wasn't thrown!");
		}
		catch (ArgumentOutOfRangeException ex) 
		{
			Assert.True(ex.GetType() == exceptionType);
		}
		catch (ArgumentNullException ex)
		{
			Assert.True(ex.GetType() == exceptionType);
		}

	}

	/// <summary>
	/// Создание записи с некорректными параметрами в конструкторе.
	/// </summary>
	/// <param name="id">Идентификатор записи.</param>
	/// <param name="name">Название записи.</param>
	/// <param name="description">Описание записи.</param>
	/// <param name="userId">Идентификатор создателя записи.</param>
	/// <param name="isCorrectUser">Корректный ли пользователя будет указан в конструкторе.</param>
	/// <param name="groupId">Идентификатор группы.</param>
	/// <param name="isCorrectGroup">Корректная ли группа будет указана в конструкторе.</param>
	/// <param name="exceptionType">Тип исключения, которое должно быть вызвано.</param>
	[Theory]
	[InlineData(-1, "Название записи", "Описание записи", 1, true, 1, true, typeof(ArgumentOutOfRangeException))]
	[InlineData(1, null, "Описание записи", 1, true, 1, true, typeof(ArgumentNullException))]
	[InlineData(1, "Название записи", null, 1, true, 1, true, typeof(ArgumentNullException))]
	[InlineData(1, "Название записи", "Описание записи", -1, true, 1, true, typeof(ArgumentOutOfRangeException))]
	[InlineData(1, "Название записи", "Описание записи", 1,false, 1, true, typeof(ArgumentNullException))]
	[InlineData(1, "Название записи", "Описание записи", 1, true, -1, true, typeof(ArgumentOutOfRangeException))]
	[InlineData(1, "Название записи", "Описание записи", 1, true, 1, false, typeof(ArgumentNullException))]
	public void InitNoteWithIncorrectValueShouldThrowException(int id, string name, string description, int userId,
		bool isCorrectUser, int groupId, bool isCorrectGroup, Type exceptionType)
	{
		try
		{
			new Note(id, name, description, DateTime.Now, userId, isCorrectUser ?
				new User() : null, groupId, isCorrectGroup ? new Domain.Group() : null);
			Assert.Fail("Exception wasn't thrown!");
		}
		catch (ArgumentOutOfRangeException ex)
		{
			Assert.True(ex.GetType() == exceptionType);
		}
		catch (ArgumentNullException ex)
		{
			Assert.True(ex.GetType() == exceptionType);
		}
	}

	/// <summary>
	/// Создание роли с некорректными параметрами в конструкторе.
	/// </summary>
	/// <param name="roleId">Идентификатор роли.</param>
	/// <param name="name">Название роли.</param>
	/// <param name="isCorrectUsersList">Корректный ли список пользователей будет передаваться в конструктор.</param>
	/// <param name="isCorrectGroupsList">Корректный ли список групп будет передаваться в конструктор.</param>
	/// <param name="exceptionType">Тип исключения, которое должно быть вызвано.</param>
	[Theory]
	[InlineData(-1, "Название роли", true, true, typeof(ArgumentOutOfRangeException))]
	[InlineData(1, null, true, true, typeof(ArgumentNullException))]
	[InlineData(1, "Название роли", false, true, typeof(ArgumentNullException))]
	[InlineData(1, "Название роли", true, false, typeof(ArgumentNullException))]
	public void InitRoleWithIncorrectValueShouldThrowException(int roleId, string name,  
		bool isCorrectUsersList, bool isCorrectGroupsList, Type exceptionType)
	{
		try
		{
			new Role(roleId, name, isCorrectUsersList ? new List<User>() : null, 
				isCorrectGroupsList ? new List<Domain.Group>() : null);
			Assert.Fail("Exception wasn't thrown!");
		}
		catch (ArgumentOutOfRangeException ex)
		{
			Assert.True(ex.GetType() == exceptionType);
		}
		catch (ArgumentNullException ex)
		{
			Assert.True(ex.GetType() == exceptionType);
		}
	}

	/// <summary>
	/// Создание пользователя с некорректными параметрами в конструкторе.
	/// </summary>
	/// <param name="userId">Идентификатор пользователя.</param>
	/// <param name="firstName">Имя пользователя.</param>
	/// <param name="lastName">Фамилия пользователя.</param>
	/// <param name="patronymic">Отчество пользователя.</param>
	/// <param name="gender">Пол.</param>
	/// <param name="isCorrectNotesList">Корректный ли список записей будет передаваться в конструктор.</param>
	/// <param name="isCorrectGroupsList">Корректный ли список групп будет передаваться в конструктор.</param>
	/// <param name="isCorrectRolesList">Корректный ли список ролей будет передаваться в конструктор.</param>
	/// <param name="exceptionType">Тип исключения, которое должно быть вызвано.</param>
	[Theory]
	[InlineData(-1, "Имя", "Фамилия", "Отчество", "Пол", true, true, true, typeof(ArgumentOutOfRangeException))]
	[InlineData(1, null, "Фамилия", "Отчество", "Пол", true, true, true, typeof(ArgumentNullException))]
	[InlineData(1, "Имя", null, "Отчество", "Пол", true, true, true, typeof(ArgumentNullException))]
	[InlineData(1, "Имя", "Фамилия", null, "Пол", true, true, true, typeof(ArgumentNullException))]
	[InlineData(1, "Имя", "Фамилия", "Отчество", null, true, true, true, typeof(ArgumentNullException))]
	[InlineData(1, "Имя", "Фамилия", "Отчество", "Пол", false, true, true, typeof(ArgumentNullException))]
	[InlineData(1, "Имя", "Фамилия", "Отчество", "Пол", true, false, true, typeof(ArgumentNullException))]
	[InlineData(1, "Имя", "Фамилия", "Отчество", "Пол", true, true, false, typeof(ArgumentNullException))]
	public void InitUserWithIncorrectValueShouldThrowException(int userId, string firstName, 
		string lastName, string patronymic, string gender, bool isCorrectNotesList, 
		bool isCorrectGroupsList, bool isCorrectRolesList, Type exceptionType)  
	{
		try
		{
			new User(userId, firstName, lastName, patronymic, gender, DateTime.Now, DateTime.Now, isCorrectNotesList
				? new List<Note>() : null, isCorrectGroupsList ?
				new List<Domain.Group>() : null, isCorrectRolesList ?
				new List<Role>() : null);
			Assert.Fail("Exception wasn't thrown!");
		}
		catch (ArgumentOutOfRangeException ex)
		{
			Assert.True(ex.GetType() == exceptionType);
		}
		catch (ArgumentNullException ex)
		{
			Assert.True(ex.GetType() == exceptionType);
		}
	}
	#endregion
}