namespace Warehouse.Domain;

/// <summary>
///     Class WarehouseCells is used to store info about the warehouse cells
/// </summary>
public class WarehouseCells
{
    /// <summary>
    ///     CellNumber - cell number 
    /// </summary>  
    public int CellNumber { set; get; }
    /// <summary>
    ///     Goods - product, what contain in cell 
    /// </summary>
    public Goods Goods { set; get; }
    public WarehouseCells(int cell, Goods goods)
    {
        CellNumber = cell;
        Goods = goods;
    }
    public WarehouseCells() { }
}