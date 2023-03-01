using System.Collections.Generic;

namespace MusicMarket;

/// <summary>
/// Покупатель.
/// </summary>
public class Сustomer
{
    // ФИО
    public string Name { get; set; } = string.Empty;
    // Страна проживания.
    public string Country { get; set; } = string.Empty;
    // Адрес
    public string Adress { get; set; } = string.Empty;
    // История заказов. 
    public List<Purchase> Purchases = new();
}   