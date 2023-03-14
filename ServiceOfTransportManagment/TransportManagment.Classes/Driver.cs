namespace TransManagment.Domain;

public class Driver
{
    /// <summary>
    /// driver_id - unique key of driver
    /// </summary>
    public int Driver_id { get; set; } = 0;
    /// <summary>
    /// first_name - first name of driver
    /// </summary>
    public string First_name { get; set; } = string.Empty;
    /// <summary>
    /// last_name - last name of driver
    /// </summary>
    public string Last_name { get; set; } = string.Empty;
    /// <summary>
    /// Patronymic - patronymic of driver
    /// </summary>
    public string Patronymic { get; set; } = string.Empty;
    /// <summary>
    /// passport - number of passport driver
    /// </summary>
    public int Passport { get; set; } = 0;
    /// <summary>
    /// driver_card - number of driver's card
    /// </summary>
    public int Driver_card { get; set; } = 0;
    /// <summary>
    /// number - telephon number of driver
    /// </summary>
    public int Number { get; set; } = 0;
    public Driver() { }
    public Driver(int _driver_id, string _first_name, string _last_name, string _patronymic, int _passport, int _driver_card, int _number)
    {
        Driver_id = _driver_id;
        First_name = _first_name;
        Last_name = _last_name;
        Patronymic = _patronymic;
        Passport = _passport;
        Driver_card = _driver_card;
        Number = _number;
    }
}
