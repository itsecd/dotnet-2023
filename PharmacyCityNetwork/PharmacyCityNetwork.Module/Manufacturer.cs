﻿namespace PharmacyCityNetwork;

/// <summary>
/// Class describing a manufacturer
/// </summary>
public class Manufacturer
{
    /// <summary>
    /// Id of manufacturer
    /// </summary>
    public int ManufacturerId { get; set; } = 0;
    /// <summary>
    /// Manufacturer name
    /// </summary>
    public string ManufacturerName { get; set; } = string.Empty;
    /// <summary>
    /// Products of manufacturer
    /// </summary>
    public List<Product> Products = new();
    public Manufacturer() { }
    public Manufacturer(string manufacturerName, int manufacturerId)
    {
        ManufacturerName = manufacturerName;
        ManufacturerId = manufacturerId;
    }
}