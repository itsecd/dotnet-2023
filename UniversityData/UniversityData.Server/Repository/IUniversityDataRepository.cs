using UniversityData.Domain;

namespace UniversityData.Server.Repository;
public interface IUniversityDataRepository
{
    List<Department> Departments { get; }
    List<Faculty> Faculties { get; }
    List<Rector> Rectors { get; }
    List<Specialty> Specialties { get; }
    List<SpecialtyTableNode> SpecialtyTableNodes { get; }
    List<University> Universities { get; }
    List<UniversityProperty> UniversityProperties { get; }
    List<ConstructionProperty> ConstructionProperties { get; }
}