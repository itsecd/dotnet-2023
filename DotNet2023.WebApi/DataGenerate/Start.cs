using DotNet2023.Domain.InstituteDocumentation;
using DotNet2023.Domain.Organization;
using DotNet2023.WebApi.DataBase;

namespace DotNet2023.WebApi.DataGenerate;

public class Start
{
    public List<Speciality>? Specialities { get; set; } = new();
    public Random Rnd { get; set; } = new();
    public List<InstituteSpeciality>? InstituteSpecialityList { get; set; } = new();

    public Start()
    {
        for (var i = 0; i < 30; i++)
        {
            Specialities.Add(Generator.Speciality(i));
        }
    }

    public void GenerationInst()
    {
        var faculty1 = new int[] { 1, 2, 3, 5 };
        var department1 = new Dictionary<int, int[]>
        {
            {1, new int[]{1, 5, 3} },
            {2, new int[]{7, 4, 0} },
            {3, new int[]{6, 5, 3} },
            {5, new int[]{2, 8} },
        };
        var inst1 = Generator.Institution(0, faculty1, department1);
        FullInst(inst1, InstituteSpecialityList);

        var faculty2 = new int[] { 2, 0, 4, 6 };
        var department2 = new Dictionary<int, int[]>
        {
            {2, new int[]{1, 0, 7} },
            {0, new int[]{2} },
            {4, new int[]{5, 3} },
            {6, new int[]{8, 6, 4} },
        };
        var inst2 = Generator.Institution(1, faculty2, department2);
        FullInst(inst2, InstituteSpecialityList);

        var faculty3 = new int[] { 4, 3 };
        var department3 = new Dictionary<int, int[]>
        {
            {4, new int[]{0, 1, 2, 3, 4} },
            {3, new int[]{5, 6} },
        };
        var inst3 = Generator.Institution(2, faculty3, department3);
        FullInst(inst3, InstituteSpecialityList);

        using (var db = new DbContextWebApi())
        {
            db.Institutes.Add(inst1);
            db.Institutes.Add(inst2);
            db.Institutes.Add(inst3);
            db.InstituteSpecialties.AddRange(InstituteSpecialityList);
            db.SaveChanges();
        }
    }

    public Speciality GetSpeciality(List<string> tmp)
    {
        var res = new Speciality();

        do
        {
            res = Specialities[Rnd.Next(0, 29)];
        } while (tmp.Contains(res.Code));

        return res;
    }

    public void FullInst(HigherEducationInstitution institution, List<InstituteSpeciality> specinst)
    {
        var tmp = new List<string>();
        foreach (var fac in institution.Faculties)
        {
            var e = fac.Departments;
            foreach (var depr in e)
            {

                var spec = GetSpeciality(tmp);
                tmp.Add(spec.Code);

                for (var i = 0; i < Rnd.Next(1, 5); i++)
                {
                    Generator.GroupOfStudent(spec, depr);
                }

                var specInst = new InstituteSpeciality()
                {
                    Key = spec.Code + institution.Id,
                    HigherEducationInstitution = institution,
                    IdHigherEducationInstitution = institution.Id,
                    Speciality = spec,
                    IdSpeciality = institution.Id,
                };
                if (!specinst.Contains(specInst))
                {
                    specinst.Add(specInst);
                }
            }
        }
    }
}
