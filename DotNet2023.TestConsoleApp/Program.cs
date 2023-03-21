using DotNet2023.Domain.Organization;
using DotNet2023.TestConsoleApp.DBContext;
using System.Text.Json;

Console.WriteLine("Первая лабораторная работа. Тестовое приложение для работы с бд");

using (var fs = new FileStream("DataInstitutions.json", FileMode.OpenOrCreate))
{
    var elem = JsonSerializer.Deserialize<List<HigherEducationInstitution>>(fs);
    Console.WriteLine($"{elem.Count}. {elem[0].Faculties.Count}");
}


//using (var db = new DbContextTest())
//{
//    var institutions = db.Institutes.ToList();
//    var faculty = db.Faculties.ToList();
//    var departmt = db.Departments.ToList();
//    var group = db.GroupOfStudents.ToList();

//    var spec = db.Specialties.ToList();
//    var specs = db.InstituteSpecialties.ToList();

//    var students = db.Students.ToList();
//    var educ = db.EducationWorker.ToList();

//    Console.WriteLine("");

//    foreach (var elem in group)
//        elem.Department = null;
//    foreach (var elem in departmt)
//    {
//        elem.Faculty = null;
//        elem.Institute = null;
//    }
//    foreach (var elem in faculty)
//        elem.Institute = null;
//    foreach (var elem in spec)
//    {
//        elem.Institutes = null;
//    }
//    foreach (var elem in specs)
//    {
//        elem.HigherEducationInstitution = null;
//        elem.Speciality = null;
//    }
//    foreach (var elem in students)
//        elem.Group = null;



//    using (var fs = new FileStream("DataInstitutions.json", FileMode.OpenOrCreate))
//    {
//        JsonSerializer.Serialize<List<HigherEducationInstitution>>(fs, institutions);
//    }
//}

