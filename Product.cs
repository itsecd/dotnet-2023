using System.Collections.Generic;

namespace MusicMarket;

/// <summary>
/// Товар.
/// </summary>
public class Product
{
    // Тип аудионосителя: диск|кассета|виниловая пластинка.
    public string TypeOfCarrier { get; set; } = string.Empty;
    // Тип издания: альбом|сингл.
    public string PublicationType { get; set; } = string.Empty;
    // Исполнитель
    public string Creator { get; set; } = string.Empty;
    // Название 
    public string Name { get; set; } = string.Empty;
    // Страна издания.
    public string MadeIn { get; set; } = string.Empty;
    // Cостояние аудионосителя: новое || отличное || хорошее || удовлетворительное || плохое.
    public string MediaStatus { get; set; } = string.Empty;
    // Cостояние упаковки: новое || отличное || хорошее || удовлетворительное || плохое.
    public string PackagingCondition { get; set; } = string.Empty;
    // Цена
    public double Price { get; set; }
    // Cтатус: в продаже || продан. 
    public string Status { get; set; } = string.Empty;
    // Продавец
    public Seller Seller = new(); 

    
    //public string NAME
    //{ get { return name; } set { name = value; } }
    //public double CENA
    //{ get { return cena; } set { cena = value; } }
    //public int AMT
    //{ get { return amt; } set { amt = value; } }
    //public double DATA
    //{ get { return data; } set { data = value; } }
    //public string MADE
    //{ get { return made; } set { made = value; } }

    //public Product(string name, double cena, int amt, string made, double data)
    //{
    //    this.name = name;
    //    this.cena = cena;
    //    this.amt = amt;
    //    this.made = made;
    //    this.data = data;
    //}

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        var MyStack = new Stack<my>();
    //    }

    //}
}

