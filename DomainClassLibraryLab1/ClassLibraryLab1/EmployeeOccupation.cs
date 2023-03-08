namespace EmployeeDomain;
public class EmployeeOccupation
{
    //id или int, или GUID
    // Guid - это объект, его можно представлять как строчкой. Он уникален! Он генерируется из сетевой карты,
    //текущего времени и т.д. Его можно сгенерить в любой момент времени, но "гарантируется" уникальность (в пределах малой БД)
    //минус автоинкремента - их генерация ложится на БД (!)
    //в случае GUID - их можно генерить и на клиентской, и на серверной части.
    public uint Id { get; set; }
    public DateOnly HireDate { get; set; }
    public DateOnly? DismissalDate { get; set; }
    public Occupation? Occupation { get; set; }
    public Employee? Employee { get; set; }
}
