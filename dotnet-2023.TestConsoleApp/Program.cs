using dotnet_2023.DataModel.InstituteDocumentation;
using dotnet_2023.DataModel.InstitutionStructure;
using dotnet_2023.DataModel.Organization;
using dotnet_2023.DataModel.Person;
using dotnet_2023.lib.FillDataBase.Generation;

Console.WriteLine("First Meow");

var basePerson = (BasePerson)new GenerationRandomPerson().Generation();

var speciality = (Speciality)new GenerationRandomSpeciality().GenerationDefinite(14);

var group = new GroupOfStudents()
{
    IdSpeciality = speciality.Code,
};

var person = new Student()
{
    Name = basePerson.Name,
    Email = basePerson.Email,
    Phone = basePerson.Phone,
    Surname = basePerson.Surname,
    Patronymic = basePerson.Patronymic,
    IdSpeciality = speciality.Code,
    Speciality = speciality,
    Group = group,
    IdGroup = group.Id,
};

var groupMany = new GenerationRandomGroup().Generation() as GroupOfStudents;


var inst = new GenerationRandomInsitute().GenerationDefinite(4) as HigherEducationInstitution;


Console.WriteLine(inst);