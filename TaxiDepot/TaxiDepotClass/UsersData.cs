namespace TaxiDepotClass;

public class User
{
    /// <summary>
    /// User surname - field
    /// </summary>
    public string UserSurname { get; set; } = string.Empty;
    
    /// <summary>
    /// User name - field
    /// </summary>
    public string UserName { get; set; } = string.Empty;
    
    /// <summary>
    /// User patronymic - field
    /// </summary>
    public string UserPatronymic { get; set; } = string.Empty;
    
    /// <summary>
    /// User phone number  - field
    /// </summary>
    public string UserPhoneNumber { get; set; } = string.Empty;

    /// <summary>
    /// Constructor without parameters to instantiate the class - User
    /// </summary>
    public User() {}
    
    /// <summary>
    /// Constructor with parameters to instantiate the class - User
    /// </summary>
    /// <param name="surname"></param>
    /// <param name="name"></param>
    /// <param name="patronymic"></param>
    /// <param name="phoneNumber"></param>
    public User(string surname, string name, string patronymic, string phoneNumber)
    {
        UserSurname = surname;
        UserName = name;
        UserPatronymic = patronymic;
        UserPhoneNumber = phoneNumber;
    }
    
    /// <summary>
    /// Overload Equals
    /// </summary>
    /// <param name="userObj"></param>
    /// <returns></returns>
    public override bool Equals(object? userObj)
    {
        if (userObj is not User param || GetType() != userObj.GetType())
            return false;
        
        return UserSurname == param.UserSurname &&
               UserName == param.UserName &&
               UserPatronymic == param.UserPatronymic &&
               UserPhoneNumber == param.UserPhoneNumber;
    }
    
    /// <summary>
    /// Overload == through Equals
    /// </summary>
    /// <param name="userObj1"></param>
    /// <param name="userObj2"></param>
    /// <returns></returns>
    public static bool operator ==(User userObj1, User userObj2)        
    {            
        return Object.Equals(userObj1, userObj2);        
    }

    /// <summary>
    /// Overload != through Equals
    /// </summary>
    /// <param name="userObj1"></param>
    /// <param name="userObj2"></param>
    /// <returns></returns>
    public static bool operator !=(User userObj1, User userObj2)        
    {            
        return !Object.Equals(userObj1, userObj2);        
    }
    
    /// <summary>
    /// Print function
    /// </summary>
    /// <param name="obj"></param>
    public void PrintCarData(User obj)
    {
        Console.WriteLine(
            $"User: {obj.UserSurname} {obj.UserName} {obj.UserPatronymic}, phone number - {obj.UserPhoneNumber}");
    }
    
    /// <summary>
    /// Get hash code func
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        return UserName.GetHashCode();
    }
}