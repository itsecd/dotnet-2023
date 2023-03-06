namespace Fabric.Domain;
/// <summary>
/// Class Fabric is used to store information of the fabric.
/// </summary>
public class Fabric
{
    /// <summary>
    /// Id is used to store the ID.
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Type is used to store information about the Fabric category.
    /// </summary>
    public string Type { get; set; } = string.Empty;
    /// <summary>
    /// Name is used to store name of Fabric.
    /// </summary>
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// Address is used to store address of Fabric.
    /// </summary>
    public string Address { get; set; } = string.Empty;
    /// <summary>
    /// PhoneNumber is used to store phone number of Fabric.
    /// </summary>
    public string PhoneNumber { get; set; } = string.Empty;
    /// <summary>
    /// FormOfOwnership is used to store information about ownership form.
    /// </summary>
    public string FormOfOwnership { get; set; } = string.Empty;
    /// <summary>
    /// NumberOfWorkers is used to store information about quantity of workers.
    /// </summary>
    public int NumberOfWorkers { get; set; }
    /// <summary>
    /// TotalSquare is used to store information about the area of the Fabric.
    /// </summary>
    public int TotalSquare { get; set; }

    public Fabric() { }
    public Fabric(int id, string type, string name, string address, string phoneNumber, string formOfOwnership, int numberOfWorkers, int totalSquare)
    {
        Id = id;
        Type = type;
        Name = name;
        Address = address;
        PhoneNumber = phoneNumber;
        FormOfOwnership = formOfOwnership;
        NumberOfWorkers = numberOfWorkers;
        TotalSquare = totalSquare;
    }
}

