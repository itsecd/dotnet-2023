﻿namespace TransportManagment.Server.Dto;
/// <summary>
/// Class of transports for method Get
/// </summary>
public class TransportGetDto
{
    /// <summary>
    /// type of transport
    /// </summary>
    public string Type { get; set; } = string.Empty;
    /// <summary>
    /// Model of transport
    /// </summary>
    public string Model { get; set; } = string.Empty;
    /// <summary>
    /// Date when make transport
    /// </summary>
    public DateTime DateMake { get; set; } = new DateTime();
}