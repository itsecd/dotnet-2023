namespace Warehouse.Domain;
/// <summary>
///     Warehouse - a class that describes the company supply with goods
/// </summary>
public class WarehouseCells
{
    /// <summary>
    ///     CellNumber - cell number 
    /// </summary>  
    public int CellNumber { set; get; }
    public Goods Goods { set; get; }
    public WarehouseCells(int cell, Goods goods)
    {
        CellNumber = cell;
        Goods = goods;
    }
    public WarehouseCells() { }
}