namespace TaxiDepotClass;

public class Car
{
    /// <summary>
    /// Car government number - field
    /// </summary>
    public string CarNumber { get; set; } = string.Empty;
    /// <summary>
    /// Car model - field
    /// </summary>
    public string CarModel { get; } = string.Empty;
    /// <summary>
    /// Car color - field
    /// </summary>
    public string CarColor { get; set; } = string.Empty;
    /// <summary>
    /// Indicator that the driver is assigned to the car - field
    /// </summary>
    public bool CarAssigned { get; set; } = false;
    /// <summary>
    /// Constructor without parameters to instantiate the class - Car
    /// </summary>
    public Car() {}
    /// <summary>
    /// Constructor with parameters to instantiate the class - Car
    /// </summary>
    /// <param name="number"></param>
    /// <param name="model"></param>
    /// <param name="color"></param>
    public Car(string number, string model, string color)
    {
        CarNumber = number;
        CarModel = model;
        CarColor = color;
    }
    /// <summary>
    /// Overload Equals
    /// </summary>
    /// <param name="carObj"></param>
    /// <returns></returns>
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
    /// <param name="carObj1"></param>
    /// <param name="carObj2"></param>
    /// <returns></returns>
    public static bool operator ==(Car carObj1, Car carObj2)        
    {            
        return Object.Equals(carObj1, carObj2);        
    }
    /// <summary>
    /// Overload != through Equals
    /// </summary>
    /// <param name="carObj1"></param>
    /// <param name="carObj2"></param>
    /// <returns></returns>
    public static bool operator !=(Car carObj1, Car carObj2)        
    {            
        return !Object.Equals(carObj1, carObj2);        
    }
    /// <summary>
    /// Print function
    /// </summary>
    /// <param name="obj"></param>
    public void PrintCarData(Car obj)
    {
        Console.WriteLine($"Car model: {obj.CarModel}, number - {obj.CarNumber}, color - {obj.CarColor}");
    }
    /// <summary>
    /// Get hash code func
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        return CarModel.GetHashCode();
    }
}   