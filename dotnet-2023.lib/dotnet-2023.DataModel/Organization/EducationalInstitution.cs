namespace dotnet_2023.DataModel.Organization;
public enum TypeOfOwnership
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

public class EducationalInstitution : Organization
{
    public InstitutionalProperty? InstitutionalProperty { get; set; }
    public TypeOfOwnership? BuildingProperty { get; set; }
}
