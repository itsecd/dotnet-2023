using UniversityData.Domain;

namespace UniversityData.Server.Repository;

public class UniversityDataRepository : IUniversityDataRepository
{
    private readonly List<University> _universities;
    private readonly List<Faculty> _faculties;
    private readonly List<Department> _departments;
    private readonly List<Rector> _rectors;
    private readonly List<Specialty> _specialties;
    private readonly List<SpecialtyTableNode> _specialtyTableNodes;

    public UniversityDataRepository()
    {
        _specialties = new List<Specialty>();
        for (var i = 0; i < 5; ++i)
        {
            _specialties.Add(new Specialty());
            _specialties[i].Id = i;
        }
        _specialties[0].Name = "Прикладная информатика";
        _specialties[0].Code = "09.03.03";
        _specialties[1].Name = "Информационные системы и технологии";
        _specialties[1].Code = "09.03.02";
        _specialties[2].Name = "Информатика и вычислительная техника";
        _specialties[2].Code = "09.03.01";
        _specialties[3].Name = "Прикладная математика и информатика";
        _specialties[3].Code = "01.03.02";
        _specialties[4].Name = "Информационная безопасность автоматизированных систем";
        _specialties[4].Code = "10.05.03";

        _departments = new List<Department>();
        for (var i = 0; i < 4; ++i)
        {
            _departments.Add(new Department());
            _departments[i].Id = i;
        }
        _departments[0].Name = "ГИиБ";
        _departments[0].SupervisorNumber = "890918734";
        _departments[0].UniversityId = 0;
        _departments[1].Name = "Кафедры алгебры и геометрии";
        _departments[1].SupervisorNumber = "890918735";
        _departments[1].UniversityId = 0;
        _departments[2].Name = "Кафедра высшей математики";
        _departments[2].SupervisorNumber = "890918736";
        _departments[2].UniversityId = 1;
        _departments[3].Name = "Кафедра информационных технологий";
        _departments[3].SupervisorNumber = "890918737";
        _departments[3].UniversityId = 2;

        _rectors = new List<Rector>();
        for (var i = 0; i < 3; ++i)
        {
            _rectors.Add(new Rector());
            _rectors[i].Id = i;
        }
        _rectors[0].Name = "Владимир";
        _rectors[0].Surname = "Богатырев";
        _rectors[0].Patronymic = "Дмитриевич";
        _rectors[0].Degree = "Доктор экономических наук";
        _rectors[0].Title = "Профессор";
        _rectors[0].Position = "Ректор";
        _rectors[0].UniversityiId = 0;
        _rectors[1].Name = "Дмитрий";
        _rectors[1].Surname = "Быков";
        _rectors[1].Patronymic = "Евгеньевич";
        _rectors[1].Degree = "Доктор технических наук";
        _rectors[1].Title = "Профессор";
        _rectors[1].Position = "Ректор";
        _rectors[1].UniversityiId = 1;
        _rectors[2].Name = "Вадим";
        _rectors[2].Surname = "Ружников";
        _rectors[2].Patronymic = "Александрович";
        _rectors[2].Degree = "Кандидат технических наук";
        _rectors[2].Title = "Доцент";
        _rectors[2].Position = "Ректор";
        _rectors[2].UniversityiId = 2;

        _faculties = new List<Faculty>();
        for (var i = 0; i < 6; ++i)
        {
            _faculties.Add(new Faculty());
            _faculties[i].Id = i;
        }
        _faculties[0].Name = "Институт информатики и кибернетики";
        _faculties[0].WorkersCount = 16;
        _faculties[0].StudentsCount = 110;
        _faculties[0].UniversityId = 0;
        _faculties[1].Name = "Институт экономики и управления";
        _faculties[1].WorkersCount = 22;
        _faculties[1].StudentsCount = 81;
        _faculties[1].UniversityId = 0;
        _faculties[2].Name = "Юридический институт";
        _faculties[2].WorkersCount = 11;
        _faculties[2].StudentsCount = 65;
        _faculties[2].UniversityId = 0;
        _faculties[3].Name = "Социально-гумманитарный институт";
        _faculties[3].WorkersCount = 30;
        _faculties[3].UniversityId = 1;
        _faculties[3].StudentsCount = 200;
        _faculties[4].Name = "Институт доп. образования";
        _faculties[4].WorkersCount = 22;
        _faculties[4].StudentsCount = 62;
        _faculties[4].UniversityId = 1;
        _faculties[5].Name = "Институт двигателей и энергетических установок";
        _faculties[5].WorkersCount = 16;
        _faculties[5].StudentsCount = 70;
        _faculties[5].UniversityId = 2;

        _specialtyTableNodes = new List<SpecialtyTableNode>();
        for (var i = 0; i < 11; ++i)
        {
            _specialtyTableNodes.Add(new SpecialtyTableNode());
            _specialtyTableNodes[i].Id = i;
        }
        _specialtyTableNodes[0].Specialty = Specialties[0];
        _specialtyTableNodes[0].CountGroups = 8;
        _specialtyTableNodes[0].UniversityId = 0;
        _specialtyTableNodes[0].SpecialtyID = 0;
        _specialtyTableNodes[1].Specialty = Specialties[0];
        _specialtyTableNodes[1].CountGroups = 17;
        _specialtyTableNodes[1].UniversityId = 0;
        _specialtyTableNodes[1].SpecialtyID = 0;
        _specialtyTableNodes[2].Specialty = Specialties[1];
        _specialtyTableNodes[2].CountGroups = 6;
        _specialtyTableNodes[2].UniversityId = 0;
        _specialtyTableNodes[2].SpecialtyID = 1;
        _specialtyTableNodes[3].Specialty = Specialties[1];
        _specialtyTableNodes[3].CountGroups = 6;
        _specialtyTableNodes[3].UniversityId = 1;
        _specialtyTableNodes[3].SpecialtyID = 1;
        _specialtyTableNodes[4].Specialty = Specialties[2];
        _specialtyTableNodes[4].CountGroups = 9;
        _specialtyTableNodes[4].UniversityId = 1;
        _specialtyTableNodes[4].SpecialtyID = 2;
        _specialtyTableNodes[5].Specialty = Specialties[2];
        _specialtyTableNodes[5].CountGroups = 4;
        _specialtyTableNodes[5].UniversityId = 1;
        _specialtyTableNodes[5].SpecialtyID = 2;
        _specialtyTableNodes[6].Specialty = Specialties[3];
        _specialtyTableNodes[6].CountGroups = 8;
        _specialtyTableNodes[6].UniversityId = 1;
        _specialtyTableNodes[6].SpecialtyID = 3;
        _specialtyTableNodes[7].Specialty = Specialties[3];
        _specialtyTableNodes[7].CountGroups = 8;
        _specialtyTableNodes[7].UniversityId = 2;
        _specialtyTableNodes[7].SpecialtyID = 3;
        _specialtyTableNodes[8].Specialty = Specialties[4];
        _specialtyTableNodes[8].CountGroups = 10;
        _specialtyTableNodes[8].UniversityId = 2;
        _specialtyTableNodes[8].SpecialtyID = 4;
        _specialtyTableNodes[9].Specialty = Specialties[4];
        _specialtyTableNodes[9].CountGroups = 8;
        _specialtyTableNodes[9].UniversityId = 2;
        _specialtyTableNodes[9].SpecialtyID = 4;
        _specialtyTableNodes[10].Specialty = Specialties[4];
        _specialtyTableNodes[10].CountGroups = 8;
        _specialtyTableNodes[10].UniversityId = 2;
        _specialtyTableNodes[10].SpecialtyID = 4;

        _universities = new List<University>();
        for (var i = 0; i < 3; ++i)
        {
            _universities.Add(new University());
            _universities[i].Id = i;
        }
        _universities[0].Number = "12345";
        _universities[0].Name = "Самарский университет";
        _universities[0].Address = "Самара";
        _universities[0].RectorData = Rectors[0];
        _universities[0].UniversityProperty = "муниципальная";
        _universities[0].ConstructionProperty = "муниципальная";
        _universities[0].RectorId = 0;
        _universities[1].Number = "56789";
        _universities[1].Name = "СамГТУ";
        _universities[1].Address = "Самара";
        _universities[1].RectorData = Rectors[1];
        _universities[1].UniversityProperty = "муниципальная";
        _universities[1].ConstructionProperty = "муниципальная";
        _universities[1].RectorId = 1;
        _universities[2].Number = "45678";
        _universities[2].Name = "ПГУТИ";
        _universities[2].Address = "Самара";
        _universities[2].RectorData = Rectors[2];
        _universities[2].UniversityProperty = "муниципальная";
        _universities[2].ConstructionProperty = "федеральная";
        _universities[2].RectorId = 2;
        _universities[0].FacultiesData.AddRange(new Faculty[] { Faculties[0], Faculties[1], Faculties[2] });
        _universities[0].DepartmentsData.AddRange(new Department[] { Departments[0], Departments[1] });
        _universities[0].SpecialtyTable.AddRange(new SpecialtyTableNode[] { SpecialtyTableNodes[0], SpecialtyTableNodes[1], SpecialtyTableNodes[2] });
        _universities[1].FacultiesData.AddRange(new Faculty[] { Faculties[3], Faculties[4] });
        _universities[1].DepartmentsData.Add(Departments[2]);
        _universities[1].SpecialtyTable.AddRange(new SpecialtyTableNode[] { SpecialtyTableNodes[3], SpecialtyTableNodes[4], SpecialtyTableNodes[5], SpecialtyTableNodes[6] });
        _universities[2].FacultiesData.Add(Faculties[5]);
        _universities[2].DepartmentsData.Add(Departments[3]);
        _universities[2].SpecialtyTable.AddRange(new SpecialtyTableNode[] { SpecialtyTableNodes[7], SpecialtyTableNodes[8], SpecialtyTableNodes[9], SpecialtyTableNodes[10] });
    }


    public List<University> Universities => _universities;
    public List<Department> Departments => _departments;
    public List<Faculty> Faculties => _faculties;
    public List<Specialty> Specialties => _specialties;
    public List<Rector> Rectors => _rectors;
    public List<SpecialtyTableNode> SpecialtyTableNodes => _specialtyTableNodes;

}
