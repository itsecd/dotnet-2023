namespace Taxi.Server.Dto;

public class VehicleAndDriverGetDto
{
    /// <summary>
    ///     RegistrationCarPlate - a sequence of letters and numbers used to identify the vehicle in real life
    /// </summary>
    public string RegistrationCarPlate { get; set; } = string.Empty;

    /// <summary>
    ///     Colour - property that stores the colour of the vehicle
    /// </summary>
    public string Colour { get; set; } = string.Empty;
    
    /// <summary>
    ///     Brand - a name of the company that makes the vehicle
    /// </summary>
    public string Brand { get; set; } = string.Empty;

    /// <summary>
    ///     Model - a name that manufacturers use to identify and sell cars
    /// </summary>
    public string Model { get; set; } = string.Empty;

    /// <summary>
    ///     Class - a vehicle belonging to a certain type of vehicle.
    /// </summary>
    public string Class { get; set; } = string.Empty;

    // <summary>
    ///     FirstName - first name of the driver
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    ///     LastName - last name of the driver
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    ///     Patronymic - patronymic of the driver
    /// </summary>
    public string? Patronymic { get; set; }

    /// <summary>
    ///     Passport - a unique sequence of digits that are the series and number of the passport
    /// </summary>
    public string Passport { get; set; } = string.Empty;

    /// <summary>
    ///     PhoneNumber - mobile phone number registered to the driver
    /// </summary>
    public string PhoneNumber { get; set; } = string.Empty;
}