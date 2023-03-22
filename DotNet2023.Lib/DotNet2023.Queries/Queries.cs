using DotNet2023.DataBase.DBContext;
using DotNet2023.Domain.InstituteDocumentation;
using DotNet2023.Domain.Organization;

namespace DotNet2023.Queries;

public static class Queries
{
    /// <summary>
    /// Get Institution By Id
    /// </summary>
    /// <param name="db">data base context</param>
    /// <param name="initials">Institution initials</param>
    /// <returns>HigherEducationInstitution or null, if there is none</returns>
    public static HigherEducationInstitution? GetHigherEducationInstitutionById
        (DataBaseContext db, string id) =>
        db.Institutes.FirstOrDefault(x => x.Id == id);

    /// <summary>
    /// Get Institution By Initials
    /// </summary>
    /// <param name="db">data base context</param>
    /// <param name="initials">Institution initials</param>
    /// <returns>HigherEducationInstitution or null, if there is none</returns>
    public static HigherEducationInstitution? GetHigherEducationInstitutionByInitials
        (DataBaseContext db, string initials) =>
        db.Institutes.FirstOrDefault(x => x.Initials == initials);

    // TODO or create a simple class for request?....

    /// <summary>
    /// Get information about University struct by initials
    /// </summary>
    /// <param name="db">data base context</param>
    /// <param name="initials">institution initials</param>
    /// <returns>Anonymous type with parameters: 
    /// name - initials
    /// faculties - count faculty
    /// departments - count department
    /// specialties - count specialities</returns>
    public static List<dynamic> GetInfrormationUniversityStructByInitials
        (DataBaseContext db, string initials) =>
        db.Institutes
            .Where(x => x.Initials == initials)
            .Select(x => new
            {
                name = x.Initials,
                faculties = x.Faculties.Count(),
                departments = x.Departments.Count(),
                specialties = x!.Specialties
                    .Select(i => i.Speciality).Count()
            }).ToList<dynamic>();

    /// <summary>
    /// Get First 5 Popular speciality
    /// </summary>
    /// <param name="db">data base context</param>
    /// <returns>array of speliality</returns>
    public static Speciality[]? GetPopularSpeciality(DataBaseContext db) =>
        db.Specialties
            .Select(x => x)
            .OrderByDescending(x => db.GroupOfStudents
                .Count(i => i.IdSpeciality == x.Code))
            .Take(5)
            .ToArray();

    /// <summary>
    /// Get Institutions with max departments
    /// </summary>
    /// <param name="db">data base context</param>
    /// <returns>array of HigherEducationInstitution</returns>
    public static HigherEducationInstitution[]? GetInstitutionsWithMaxDepartments
        (DataBaseContext db) =>
        db.Institutes
            .Select(x => x)
            .OrderByDescending(x => x.Departments.Count)
            .ThenBy(x => x.FullName)
            .ToArray();

    /// <summary>
    /// Get Institutions By InstitutionalProperty
    /// </summary>
    /// <param name="db">data base context</param>
    /// <param name="property">InstitutionalProperty type (0 or 1)</param>
    /// <returns>Dictionary<string, int>, 
    /// where string is Id Institution, int count of groups</string></returns>
    public static Dictionary<string, int> GetOwnershipInstitutionAndGroup
        (DataBaseContext db, InstitutionalProperty property) =>
        db.Institutes
            .Where(x => x.InstitutionalProperty == property)
            .ToDictionary(x => x.Id,
            e => e.Departments
            .Sum(i => i.GroupOfStudents.Count()));

    /// <summary>
    /// Get Information about Struct University 
    /// </summary>
    /// <param name="db"></param>
    /// <param name="institutionalProperty">InstitutionalProperty property 
    /// possible value (0 or 1)</param>
    /// <param name="buildingProperty">BuildingProperty property 
    /// possible value (0, 1 or 2)</param>
    /// <returns>Anonymous type with parameters: 
    /// name - Initials Institution
    /// faculties - faculties count
    /// departments - departments count
    /// groups - groups count</returns>
    public static List<dynamic> GetInfrormationStructUniversity
        (DataBaseContext db, InstitutionalProperty institutionalProperty,
        BuildingProperty buildingProperty) =>
        db.Institutes
            .Where(x =>
                x.InstitutionalProperty == institutionalProperty &&
                x.BuildingProperty == buildingProperty)
            .Select(x => new
            {
                name = x.Initials,
                faculties = x.Faculties.Count,
                departments = x.Departments.Count,
                groups = x.Departments.SelectMany(i => i.GroupOfStudents)
                    .Count()
            })
            .ToList<dynamic>();
}