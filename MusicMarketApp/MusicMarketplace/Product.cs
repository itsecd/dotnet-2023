namespace MusicMarket;

/// <summary>
/// Товар.
/// </summary>
public class Product
{
    /// <summary>
    /// ID Товара.
    /// </summary>
    public int Id;

    /// <summary>
    /// Тип аудионосителя: диск|кассета|виниловая пластинка.
    /// </summary>
    public string TypeOfCarrier { get; set; } = string.Empty;

    /// <summary>
    /// Тип издания: альбом|сингл.
    /// </summary>
    public string PublicationType { get; set; } = string.Empty;

    /// <summary>
    /// Исполнитель
    /// </summary>
    public string Creator { get; set; } = string.Empty;

    /// <summary>
    /// Название 
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Страна издания.
    /// </summary>
    public string MadeIn { get; set; } = string.Empty;

    /// <summary>
    /// Cостояние аудионосителя: новое || отличное || хорошее || удовлетворительное || плохое.
    /// </summary>
    public string MediaStatus { get; set; } = string.Empty;

    /// <summary>
    /// Cостояние упаковки: новое || отличное || хорошее || удовлетворительное || плохое.
    /// </summary>
    public string PackagingCondition { get; set; } = string.Empty;

    /// <summary>
    /// Цена
    /// </summary>
    public double Price { get; set; }

    /// <summary>
    /// Cтатус: в продаже || продан. 
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// ID Продавца.
    /// </summary>
    public int SellerId { get; set; }

    /// <summary>
    /// Продавец
    /// </summary>
    public Seller? Seller { get; set; }

    /// <summary>
    /// Конструктор по умолчанию. 
    /// </summary>
    public Product() { }

    /// <summary>
    /// Конструктор с параметрами. 
    /// </summary>
    public Product(int id, string typeOfCarrier, string publicationType, string creator, string name, string madeIn,
        string mediaStatus, string packagingCondition, double price, string status, Seller seller)
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
        Seller = seller;
    }
}

