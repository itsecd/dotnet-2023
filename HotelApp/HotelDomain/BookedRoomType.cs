﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelDomain;

namespace HotelDomain;
/// <summary>
/// BookedRoomType describes booked room in hotel
/// </summary>
public class BookedRoomType
{
    /// <summary>
    /// Room value represents a type of the booked room
    /// </summary>
    public RoomType Room { get; set; } = new();
    /// <summary>
    /// Client value represents a person who booked the room
    /// </summary>
    public ClientType Client { get; set; } = new();
    /// <summary>
    /// CheckInDate - DateTime typed value for storing a date of checking-in
    /// </summary>
    public DateTime CheckInDate { get; set; } = DateTime.MinValue;
    /// <summary>
    /// DepartureDate - DateTime typed value representing a departure date
    /// </summary>
    public DateTime DepartureDate { get; set; } = DateTime.MaxValue;
    /// <summary>
    /// BookingPeriodInDays double typed value representing an amount of days between check-in and departure
    /// </summary>
    public double BookingPeriodInDays 
    { 
        get => DepartureDate.Subtract(CheckInDate).Days; 

        set
        {
            if (CheckInDate.AddDays(value).Month != DepartureDate.Year  &&
                CheckInDate.AddDays(value).Month != DepartureDate.Month &&
                CheckInDate.AddDays(value).Day   != DepartureDate.Day)
                throw new ArgumentException("Departure date can not be less than check-in date");
        }
    }
    
    public BookedRoomType() { }
    public BookedRoomType(RoomType room, ClientType client, DateTime checkInDate, DateTime departureDate, double bookingPeriodInDays)
    {
        if (checkInDate > departureDate)
            throw new ArgumentException("Departure date can not be less than check-in date");

        Room = room;
        Client = client;
        CheckInDate = checkInDate;
        DepartureDate = departureDate;

        if (CheckInDate.AddDays(bookingPeriodInDays).Month != DepartureDate.Year &&
                CheckInDate.AddDays(bookingPeriodInDays).Month != DepartureDate.Month &&
                CheckInDate.AddDays(bookingPeriodInDays).Day != DepartureDate.Day)
            throw new ArgumentException("Departure date can not be less than check-in date");

        BookingPeriodInDays = bookingPeriodInDays;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not BookedRoomType param)
            return false;

        return Room.Equals(param.Room) && Client.Equals(param.Client) && 
               CheckInDate == param.CheckInDate && 
               DepartureDate == param.DepartureDate &&
               BookingPeriodInDays == param.BookingPeriodInDays;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Room, Client, CheckInDate, DepartureDate, BookingPeriodInDays);
    }
}
