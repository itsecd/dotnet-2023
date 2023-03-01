namespace SocialNetwork.Domain;

/// <summary>
/// Проверяет корректность данных.
/// </summary>
public static class Validator
{
	#region Методы.
	/// <summary>
	/// Пытается преобразовать строку в числовое значение типа int.
	/// </summary>
	/// <param name="inputData">Строка, которую необходимо преобразовать в число.</param>
	/// <exception cref="FormatException">Некорректный форма введенных данных!</exception>
	public static void IntNumberValidate(string inputData)
	{
		if (!int.TryParse(inputData, out var _))
		{
			throw new FormatException("Некорректный формат введенных данных!");
		}
	}

	/// <summary>
	/// Пытается преобразовать строку в числовое значение типа double.
	/// </summary>
	/// <param name="inputData">Строка, которую необходимо преобразовать в число.</param>
	/// <exception cref="FormatException">Некорректный формат введенных данных!</exception>

	public static void DoubleNumberValidate(string inputData)
	{
		if (!double.TryParse(inputData, out var _))
		{
			throw new FormatException("Некорректный формат введенных данных!");
		}
	}

	/// <summary>
	/// Проверяет принадлежность значения диапазону значений.
	/// </summary>
	/// <param name="min">Минимальное значение диапазона.</param>
	/// <param name="max">Максимальное значение диапазона.</param>
	/// <param name="number">Значение для проверки.</param>
	/// <exception cref="ArgumentOutOfRangeException">Числовое значение вышло за границы!
	/// </exception>
	public static void RangeNumberValidate<T>(T min, T max, T number) where T : IComparable<T>
	{
		if (number.CompareTo(min) < 0 || number.CompareTo(max) > 0)
		{
			throw new ArgumentOutOfRangeException("Числовое значение вышло за границы! " +
				"Допустимый диапазон: [" + min + "; " + max + "]");
		}
	}

	/// <summary>
	/// Проверяет строку на пустоту или null.
	/// </summary>
	/// <param name="inputData">Значение типа string.</param>
	/// <exception cref="ArgumentNullException">Текст не содержит символов 
	/// или равен null.</exception>
	public static void StringTextValidate(string inputData)
	{
		if (string.IsNullOrEmpty(inputData))
		{
			throw new ArgumentNullException("Текст не содержит символов " +
				"или равен null!");
		}
	}

	/// <summary>
	/// Проверяет список на пустоту или null.
	/// </summary>
	/// <typeparam name="T">Тип элементов списка.</typeparam>
	/// <param name="list">Список.</param>
	/// <exception cref="ArgumentNullException">Список пустой или равен null!</exception>
	public static void ListValidate<T>(List<T>? list)
	{
		if (list == null)
		{
			throw new ArgumentNullException("Список пустой или равен null!");
		}
	}

	/// <summary>
	/// Проверка корректности даты.
	/// </summary>
	/// <param name="dateTime">Дата для проверки.</param>
	/// <exception cref="ArgumentNullException">Последовательность равна null!</exception>
	public static void DateTimeValidate(DateTime? dateTime)
	{
		if (dateTime == null)
		{
			throw new ArgumentNullException("Дата равна null!");
		}
	}

	/// <summary>
	/// Проверка корректности пользователя.
	/// </summary>
	/// <param name="user">Пользователь, которого необходимо проверить.</param>
	/// <exception cref="ArgumentNullException">Пользователь равен null!</exception>
	public static void UserValidate(User? user)
	{
		if (user == null)
		{
			throw new ArgumentNullException("Пользователь равен null!");
		}
	}

	/// <summary>
	/// Проверка корректности группы.
	/// </summary>
	/// <param name="group">Группа, которую необходимо проверить.</param>
	/// <exception cref="ArgumentNullException">Группа равна null.</exception>
	public static void GroupValidate(Group? group)
	{
		if (group == null)
		{
			throw new ArgumentNullException("Группа равна null!");
		}
	}
	#endregion
}