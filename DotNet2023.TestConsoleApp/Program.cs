using DotNet2023.DataModel.InstituteDocumentation;
using DotNet2023.DataModel.InstitutionStructure;
using DotNet2023.DataModel.Organization;
using DotNet2023.DataModel.Person;
using DotNet2023.TestConsoleApp;
using System.Text.Json;

var rnd = new Random();

int GetNextSpec(List<int> was, int point)
{
    do
    {
        point = rnd.Next(0, 30);
    } while (was.Contains(point));
    return point;
}


Console.WriteLine("Первая лабораторная работа. Тестовое приложение для работы с бд");

var faclts = new int[] { 1, 3, 4 };
var dct = new Dictionary<int, int[]>();


dct.Add(1, new int[] { 0, 1, 2, 9 });
dct.Add(3, new int[] { 3, 4 });
dct.Add(4, new int[] { 5, 6, 7 });

var institute = Generator.Institution(0, faclts, dct);
var listSpec = new List<Speciality>();

for (var i = 0; i < 30; i++)
{
    listSpec.Add(Generator.Speciality(i));
}


var instSpec = new List<InstituteSpeciality>();


var wass = new List<int>();

foreach (var fls in institute.Faculties)
{
    foreach (var dps in fls.Departments)
    {
        for (var i = 0; i < rnd.Next(1, 3); i++)
        {
            var curntl = GetNextSpec(wass, rnd.Next(0, 30));
            wass.Add(curntl);

            instSpec.Add(new InstituteSpeciality(listSpec[curntl].Code, institute.Id)
            {
                IdHigherEducationInstitution = institute.Id,
                HigherEducationInstitution = institute,
                IdSpeciality = listSpec[curntl].Code,
                Speciality = listSpec[curntl]
            });

            Generator.GroupOfStudents(rnd.Next(1, 4), listSpec[curntl], dps);
        }
    }
}

Console.WriteLine(institute);