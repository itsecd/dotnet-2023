namespace Library.Domain;

/// <summary>
/// Информация о читателях
/// </summary>
public class Reader
{
    /// <summary>
    /// Идентификатор записи
    /// </summary>
    public int Id { set; get; }

    /// <summary>
    /// ФИО
    /// </summary>
    public string FullName { set; get; } = string.Empty;
    
    /// <summary>
    /// Адресс проживания
    /// </summary>
    public string Address { set; get; } = string.Empty;

    /// <summary>
    /// Номер телефона
    /// </summary>
    public string Phone { set; get; } = string.Empty;
    
    /// <summary>
    /// дата регистрации
    /// </summary>
    public DateTime? RegistrationDate { set; get; }
    
    /// <summary>
    /// Список карточек у читателя
    /// </summary>
    public List<Card> Cards { set; get; } = new List<Card>();
}
