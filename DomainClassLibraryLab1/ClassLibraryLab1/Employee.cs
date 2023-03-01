namespace ClassLibraryLab1;
public class Employee
{
    public int regNumber;
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PatronymicName { get; set; }
    public DateOnly BirthDate { get; set; }
    public int Age { get; set; }
    // WorkshopId ??
    public string HomeAddress { get; set; }
    public string HomeTelephone { get; set; }
    public string WorkTelephone { get; set; }
    public string FamilyStatus { get; set; }
    public int FamilyMembersCount { get; set; }
    public int ChildrenCount { get; set; }
}