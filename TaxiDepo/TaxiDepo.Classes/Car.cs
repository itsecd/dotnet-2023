namespace TaxiDepo.Domain;

public class Car
{
    /// <summary>
    /// Car government number
    /// </summary>
    public string CarNumber { get; set; } = string.Empty;
    /// <summary>
    /// Car model
    /// </summary>
    public string CarModel { get; } = string.Empty;
    /// <summary>
    /// Car color
    /// </summary>
    public string CarColor { get; set; } = string.Empty;
    /// <summary>
    /// Indicator that the driver is assigned to the car
    /// </summary>
    public bool CarAssigned { get; set; } = false;
    /// <summary>
    /// Constructor without parameters to instantiate the class Car
    /// </summary>
    public Car() {}
    /// <summary>
    /// Constructor with parameters to instantiate the class Car
    /// </summary>
    /// <param name="number">Car goverment number</param>
    /// <param name="model">Car model</param>
    /// <param name="color">Car color</param>
    public Car(string number, string model, string color)
    {
        CarNumber = number;
        CarModel = model;
        CarColor = color;
    }
    /// <summary>
    /// Overload Equals
    /// </summary>
    /// <param name="carObj">Car class object</param>
    /// <returns>True - equal or false - not equal</returns>
    public override bool Equals(object? carObj)
    {
        if (carObj is not Car param || GetType() != carObj.GetType())
            return false;
        
        return CarNumber == param.CarNumber &&
               CarModel == param.CarModel &&
               CarColor == param.CarColor;
    }
    /// <summary>
    /// Overload == through Equals
    /// </summary>
    /// <param name="carObj1">Car class object</param>
    /// <param name="carObj2">Car class object</param>
    /// <returns>True - equal or false - not equal</returns>
    public static bool operator ==(Car carObj1, Car carObj2)        
    {            
        return Object.Equals(carObj1, carObj2);        
    }
    /// <summary>
    /// Overload != through Equals
    /// </summary>
    /// <param name="carObj1">Car class object</param>
    /// <param name="carObj2">Car class object</param>
    /// <returns>True - not equal or false - equal</returns>
    public static bool operator !=(Car carObj1, Car carObj2)        
    {            
        return !Object.Equals(carObj1, carObj2);        
    }
    /// <summary>
    /// Print function
    /// </summary>
    /// <param name="obj">Car class object</param>
    public void PrintCarData(Car obj)
    {
        Console.WriteLine($"Car model: {obj.CarModel}, number - {obj.CarNumber}, color - {obj.CarColor}");
    }
    /// <summary>
    /// Get hash code func
    /// </summary>
    /// <returns>Integer hash code</returns>
    public override int GetHashCode()
    {
        return CarModel.GetHashCode();
    }
}   