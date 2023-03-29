namespace Factory.Domain;

/// <summary>
/// Class describing type of industry
/// </summary>
internal class Type
{
    /// <summary>
    /// Type's ID
    /// </summary>
    public int TypeID { get; set; } = 0;

    /// <summary>
    /// Type name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    public Type() { }

    public Type(int typeID, string name)
    {
        TypeID = typeID;
        Name = name;
    }
}
