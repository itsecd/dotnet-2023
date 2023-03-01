using System.Collections.Generic;

namespace MusicMarket;

/// <summary>
/// Покупка.
/// </summary>
public class Purchase 
{
    // Список товаров.
    public List <Product> Products = new();
    // Дата совершения покупки.
    public double Data { get; set; }
    // Покупатель.
    public string СustomerName { get; set; } = string.Empty;
}
