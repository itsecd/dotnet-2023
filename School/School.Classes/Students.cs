namespace School.Classes;
{
    public class Students
{
    /// <summary>	
    /// Имя
    /// </summary>	
    public string FirstName { get; set; } = string.Empty;

    /// <summary>	
    /// Фамилия	
    /// </summary>	
    public string LastName { get; set; } = string.Empty;

    /// <summary>	
    /// Отчество
    /// </summary>	
    public string Patronymic { get; set; } = string.Empty;

    /// <summary>
    /// Паспортные данные
    /// </summary>
    public string Passport { get; set; } = string.Empty;

    /// <summary>
    /// Класс студента
    /// </summary>
    public Class? Class { get; set; }

    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime BirthDate { get; set; }

    public Students() { }

    public Students(string firstName, string lastName, string patronymic, string passport, Class @class, DateTime birthDate)
    {
        FirstName = firstName;
        LastName = lastName;
        Patronymic = patronymic;
        Passport = passport;
        Class = @class;
        BirthDate = birthDate;
    }
}
}