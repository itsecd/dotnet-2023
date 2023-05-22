﻿namespace EnterpriseWarehouseServer.Dto;

/// <summary>
///     ProductGetDto - used to represent the Product object in the get-request
/// </summary>
public class ProductGetDto
{
    /// <summary>
    ///     ItemNumber - unique identifier of the product
    /// </summary>
    public uint ItemNumber { get; set; }

    /// <summary>
    ///     Title - product name
    /// </summary>
	public string Title { get; set; } = string.Empty;

    /// <summary>
    ///     Quantity - quantity of goods stored in the warehouse
    /// </summary>
	public uint Quantity { get; set; }
}