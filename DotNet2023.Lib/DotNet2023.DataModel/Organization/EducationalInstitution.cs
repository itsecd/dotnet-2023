namespace DotNet2023.DataModel.Organization;

public enum BuildingProperty
{
    Municipal = 0,
    Private = 1,
    Federal = 2,
}
public enum InstitutionalProperty
{
    Municipal = 0,
    Private = 1,
};

/// <summary>
/// The class describes the institution 
/// <param name="InstitutionalProperty">0 - municipal, 1 - private, 2 - federal</param>
/// <param name="BuildingProperty">0 - municipal, 1 - private</param>
/// </summary>
public class EducationalInstitution : Organization
{
    public InstitutionalProperty? InstitutionalProperty { get; set; }
    public BuildingProperty? BuildingProperty { get; set; }
}
