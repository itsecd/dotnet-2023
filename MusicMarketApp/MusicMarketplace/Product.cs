using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicMarketplace;

/// <summary>
/// Товар.
/// </summary>
public class Product
{
    /// <summary>
    /// ID Товара.
    /// </summary>
    [Key]
    public int Id { get; set; } = 0;

    /// <summary>
    /// Тип аудионосителя: диск|кассета|виниловая пластинка.
    /// </summary>
    [Required]
    public string TypeOfCarrier { get; set; } = string.Empty;

    /// <summary>
    /// Тип издания: альбом|сингл.
    /// </summary>
    [Required]
    public string PublicationType { get; set; } = string.Empty;

    /// <summary>
    /// Исполнитель
    /// </summary>
    [Required]
    public string Creator { get; set; } = string.Empty;

    /// <summary>
    /// Название 
    /// </summary>
    [Required]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Страна издания.
    /// </summary>
    [Required]
    public string MadeIn { get; set; } = string.Empty;

    /// <summary>
    /// Cостояние аудионосителя: новое || отличное || хорошее || удовлетворительное || плохое.
    /// </summary>
    [Required]
    public string MediaStatus { get; set; } = string.Empty;

    /// <summary>
    /// Cостояние упаковки: новое || отличное || хорошее || удовлетворительное || плохое.
    /// </summary>
    [Required]
    public string PackagingCondition { get; set; } = string.Empty;

    /// <summary>
    /// Цена
    /// </summary>
    [Required]
    public double Price { get; set; } = 0;

    /// <summary>
    /// Cтатус: в продаже || продан. 
    /// </summary>
    [Required]
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// ID Продавца.
    /// </summary>
    [ForeignKey("IdSeller")]
    public int IdSeller { get; set; } = 0;


    /// <summary>
    /// Конструктор по умолчанию. 
    /// </summary>
    public Product() { }

    /// <summary>
    /// Конструктор с параметрами. 
    /// </summary>
    public Product(int id, string typeOfCarrier, string publicationType, string creator, string name, string madeIn,
        string mediaStatus, string packagingCondition, double price, string status, int seller)
    {
        Id = id;
        TypeOfCarrier = typeOfCarrier;
        PublicationType = publicationType;
        Creator = creator;
        Name = name;
        MadeIn = madeIn;
        MediaStatus = mediaStatus;
        PackagingCondition = packagingCondition;
        Price = price;
        Status = status;
        IdSeller = seller;
    }
}

