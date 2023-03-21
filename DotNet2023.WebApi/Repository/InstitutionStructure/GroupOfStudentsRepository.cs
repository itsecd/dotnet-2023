using DotNet2023.Domain.InstitutionStructure;
using DotNet2023.WebApi.DataBase;
using DotNet2023.WebApi.Interfaces.InstitutionStructure;
using Microsoft.EntityFrameworkCore;

namespace DotNet2023.WebApi.Repository.InstitutionStructure;
public class GroupOfStudentsRepository : IGroupOfStudents
{
    private readonly DbContextWebApi _dbContext;
    public GroupOfStudentsRepository(DbContextWebApi dbContext) =>
        _dbContext = dbContext;

    public bool CreateGroupOfStudents(GroupOfStudents groupOfStudents)
    {
        _dbContext.GroupOfStudents.Add(groupOfStudents);
        return Save();
    }

    public async Task<bool> CreateGroupOfStudentsAsync(GroupOfStudents groupOfStudents)
    {
        await _dbContext.GroupOfStudents.AddAsync(groupOfStudents);
        return await SaveAsync();
    }

    public bool DeleteGroupOfStudents(GroupOfStudents groupOfStudents)
    {
        _dbContext.GroupOfStudents.Remove(groupOfStudents);
        return Save();
    }

    public async Task<bool> DeleteGroupOfStudentsAsync(GroupOfStudents groupOfStudents)
    {
        _dbContext.GroupOfStudents.Remove(groupOfStudents);
        return await SaveAsync();
    }

    public ICollection<GroupOfStudents>? GetGroupOfStudents() =>
        _dbContext.GroupOfStudents.ToList();

    public ICollection<GroupOfStudents>? GetGroupOfStudentsByDepartment(
        string idDepartment) =>
        _dbContext.GroupOfStudents
        .Where(x => x.IdDepartment == idDepartment)
        .ToList();

    public ICollection<GroupOfStudents>? GetGroupOfStudentsBySpecialityCode(string code) =>
        _dbContext.GroupOfStudents
        .Where(x => x.IdSpeciality == code)
        .ToList();

    public GroupOfStudents? GetGroupOfStudentstById(string IdGroupOfStudents) =>
        _dbContext.GroupOfStudents
        .FirstOrDefault(x => x.Id == IdGroupOfStudents);

    public bool GroupOfStudentsExistsById(string IdGroupOfStudents) =>
        _dbContext.GroupOfStudents
        .Any(x => x.Id == IdGroupOfStudents);

    public async Task<bool> GroupOfStudentsExistsByIdAsync(string IdGroupOfStudents) =>
        await _dbContext.GroupOfStudents
        .AnyAsync(x => x.Id == IdGroupOfStudents);

    public bool Save()
    {
        var saved = _dbContext.SaveChanges();
        return saved > 0 ? true : false;
    }

    public async Task<bool> SaveAsync()
    {
        var saved = await _dbContext.SaveChangesAsync();
        return saved > 0 ? true : false;
    }

    public bool UpdateGroupOfStudents(GroupOfStudents groupOfStudents)
    {
        _dbContext.GroupOfStudents.Update(groupOfStudents);
        return Save();
    }

    public async Task<bool> UpdateGroupOfStudentsAsync(GroupOfStudents groupOfStudents)
    {
        _dbContext.GroupOfStudents.Update(groupOfStudents);
        return await SaveAsync();
    }
}
