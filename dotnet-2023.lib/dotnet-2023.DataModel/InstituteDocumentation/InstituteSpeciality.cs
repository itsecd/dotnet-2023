using dotnet_2023.DataModel.Organization;

namespace dotnet_2023.DataModel.InstituteDocumentation;
public class InstituteSpeciality
{

    public string? IdSpeciality { get; set; }
    public Speciality? Speciality { get; set; }

    public string? IdHigherEducationInstitution { get; set; }
    public HigherEducationInstitution? HigherEducationInstitution { get; set; }
}
