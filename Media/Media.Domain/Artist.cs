namespace Media.Domain;

/// <summary>
/// Класс Артист
/// </summary>
public class Artist
{
    /// <summary>
    /// Имя
    /// </summary>
    /// 
    public int ArtistId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty; //{ get; init; }

    /// <summary>   
    /// Метод
    /// </summary>
    /// <param name="r"> параметр </param>
    /// <returns> Возвращает </returns>
}
