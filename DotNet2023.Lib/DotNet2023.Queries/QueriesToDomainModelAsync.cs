using DotNet2023.DataBase.DBContext;
using DotNet2023.Domain.InstituteDocumentation;
using DotNet2023.Domain.Organization;
using Microsoft.EntityFrameworkCore;

namespace DotNet2023.Queries;

public class QueriesToDomainModelAsync
{
    /// <summary>
    /// Async Get Institution By Id
    /// </summary>
    /// <param name="db">data base context</param>
    /// <param name="initials">Institution initials</param>
    /// <returns>HigherEducationInstitution or null, if there is none</returns>
    public static async Task<HigherEducationInstitution>? GetInstitutionByIdAsync
        (DataBaseContext db, string id) =>
        await db.Institutes.
        FirstOrDefaultAsync(x => x.Id == id);

    /// <summary>
    /// Async Get Institution By Initials
    /// </summary>
    /// <param name="db">data base context</param>
    /// <param name="initials">Institution initials</param>
    /// <returns>HigherEducationInstitution or null, if there is none</returns>
    public static async Task<HigherEducationInstitution>? GetInstitutionByInitialsAsync
        (DataBaseContext db, string initials) =>
        await db.Institutes
        .FirstOrDefaultAsync(x => x.Initials == initials);

    /// <summary>
    /// Async Get First 5 Popular speciality
    /// </summary>
    /// <param name="db">data base context</param>
    /// <returns>array of speliality</returns>
    public static async Task<Speciality[]>? GetPopularSpecialityAsync(DataBaseContext db) =>
        await db.Specialties
        .Select(x => x)
        .OrderByDescending(x => db.GroupOfStudents
            .Count(i => i.IdSpeciality == x.Code))
        .Take(5)
        .ToArrayAsync();

    /// <summary>
    /// Async Get Institutions with max departments
    /// </summary>
    /// <param name="db">data base context</param>
    /// <returns>array of HigherEducationInstitution</returns>
    public static async Task<HigherEducationInstitution[]>? GetInstitutionsWithMaxDepartmentsAsync
        (DataBaseContext db) =>
        await db.Institutes
        .Select(x => x)
        .OrderByDescending(x => x.Departments.Count)
        .ThenBy(x => x.FullName)
        .ToArrayAsync();

    /// <summary>
    /// Async Get Institutions By InstitutionalProperty
    /// </summary>
    /// <param name="db">data base context</param>
    /// <param name="property">InstitutionalProperty type (0 or 1)</param>
    /// <returns>Dictionary<string, int>, 
    /// where string is Id Institution, int count of groups</string></returns>
    public static async Task<Dictionary<string, int>> GetOwnershipInstitutionAndGroupAsync
        (DataBaseContext db, InstitutionalProperty property) =>
        await db.Institutes
        .Where(x => x.InstitutionalProperty == property)
        .ToDictionaryAsync(x => x.Id, e => e.Departments
        .Sum(i => i.GroupOfStudents.Count()));


    /// <summary>
    /// Async Get information about University struct by initials
    /// </summary>
    /// <param name="db">data base context</param>
    /// <param name="initials">institution initials</param>
    /// <returns>ResponseUniversityStructByInitials: 
    /// Name - initials
    /// CountFaculties - count faculty
    /// CountDepartments - count department
    /// CountSpecialties - count specialities</returns>
    public static async Task<ResponseUniversityStructByInitials>? GetInstitutionStructByInitialsAsync
        (DataBaseContext db, string initials) =>
        await db.Institutes
        .Where(x => x.Initials == initials)
        .Select(x => new ResponseUniversityStructByInitials()
        {
            Name = x.Initials,
            CountFaculties = x.Faculties.Count,
            CountDepartments = x.Departments.Count,
            CountSpecialities = x.Specialties
            .Select(i => i.Speciality).Count()
        })
        .FirstOrDefaultAsync();

    /// <summary>
    /// Async Get Information about Struct University 
    /// </summary>
    /// <param name="db"></param>
    /// <param name="institutionalProperty">InstitutionalProperty property 
    /// possible value (0 or 1)</param>
    /// <param name="buildingProperty">BuildingProperty property 
    /// possible value (0, 1 or 2)</param>
    /// <returns>ResponseUniversityStructByProperty: 
    /// Name - Initials Institution
    /// CountFaculties - faculties count
    /// CountDepartments - departments count
    /// CountGroups - groups count</returns>
    public static async Task<ResponseUniversityStructByProperty[]>? GetInstitutionStructAsync
        (DataBaseContext db, InstitutionalProperty institutionalProperty,
        BuildingProperty buildingProperty) =>
        await db.Institutes
        .Where(x =>
        x.InstitutionalProperty == institutionalProperty &&
        x.BuildingProperty == buildingProperty)
        .Select(x => new ResponseUniversityStructByProperty
        {
            Name = x.Initials,
            CountFaculties = x.Faculties.Count,
            CountDepartments = x.Departments.Count,
            CountGroups = x.Departments
            .SelectMany(i => i.GroupOfStudents).Count()
        })
        .ToArrayAsync();
}
