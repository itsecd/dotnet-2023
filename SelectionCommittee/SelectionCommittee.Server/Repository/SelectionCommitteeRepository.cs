namespace SelectionCommittee.Server.Repository;

using Microsoft.EntityFrameworkCore;
using SelectionCommittee.Domain;
using SelectionCommittee.Model;

/// <summary>
/// Работа со списками сущностей приемной комиссии.
/// </summary>
public class SelectionCommitteeRepository : ISelectionCommitteeRepository
{
    /// <summary>
    /// Контекст приемной комиссии.
    /// </summary>
    private readonly SelectionCommitteeContext _context;

    public SelectionCommitteeRepository(SelectionCommitteeContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Получение всех абитуриентов.
    /// </summary>
    /// <returns>Последовательность абитуриентов.</returns>
    public async Task<IEnumerable<Enrollee>> GetEnrollees()
    {
        return (await _context.Enrollees.ToListAsync())
            .Select(enrollee => new Enrollee
            {
                Id = enrollee.Id,
                FirstName = enrollee.FirstName,
                LastName = enrollee.LastName,
                Patronymic = enrollee.Patronymic,
                Age = enrollee.Age,
                BirthDate = enrollee.BirthDate,
                Country = enrollee.Country,
                City = enrollee.City,
                SpecializationId = enrollee.SpecializationId
            });
    }

    /// <summary>
    /// Получение абитуриента по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор абитуриента, которого необходимо получить.</param>
    /// <returns>Абитуриента.</returns>
    public async Task<Enrollee?> GetEnrollee(int id)
    {
        var enrollee = await _context.Enrollees
            .FirstOrDefaultAsync(enrollee => enrollee.Id == id);

        if (enrollee == null)
        {
            return null;
        }

        return new Enrollee
        {
            Id = enrollee.Id,
            FirstName = enrollee.FirstName,
            LastName = enrollee.LastName,
            Patronymic = enrollee.Patronymic,
            Age = enrollee.Age,
            BirthDate = enrollee.BirthDate,
            Country = enrollee.Country,
            City = enrollee.City,
            SpecializationId = enrollee.SpecializationId
        };
    }

    /// <summary>
    /// Создание абитуриента.
    /// </summary>
    /// <param name="model">Модель, в которой содержатся данные для создания абитуриента.</param>
    public async Task<int> AddEnrollee(Enrollee model)
    {
        var enrolleeDbModel = new EnrolleeDbModel
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Patronymic = model.Patronymic,
            Age = model.Age,
            BirthDate = model.BirthDate,
            Country = model.Country,
            City = model.City,
            SpecializationId = model.SpecializationId
        };

        await _context.Enrollees.AddAsync(enrolleeDbModel);

        await _context.SaveChangesAsync();

        return enrolleeDbModel.Id;
    }

    /// <summary>
    /// Изменение данных абитуриента.
    /// </summary>
    /// <param name="id">Идентификатор абитуриента, данные которого необходимо изменить.</param>
    /// <param name="model">Содержит данные, которые будут присвоены необходимому абитуриенту.</param>
    public async Task UpdateEnrollee(int id, Enrollee model)
    {
        var entity = await _context.Enrollees.FirstAsync(enrollee => enrollee.Id == id);

        entity.FirstName = model.FirstName;
        entity.LastName = model.LastName;
        entity.Patronymic = model.Patronymic;
        entity.Age = model.Age;
        entity.BirthDate = model.BirthDate;
        entity.Country = model.Country;
        entity.City = model.City;
        entity.SpecializationId = model.SpecializationId;

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Удаление абитуриента по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор абитуриента, которого необходимо удалить.</param>
    public async Task DeleteEnrollee(int id)
    {
        _context.Remove(await _context.Enrollees.FirstAsync(enrollee => enrollee.Id == id));

        _context.ExamResults.RemoveRange((await _context.ExamResults
            .ToListAsync()).Where(examResult => examResult.EnrolleeId == id));

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Получение всех результатов экзаменов.
    /// </summary>
    /// <returns>Последовательность результатов экзаменов.</returns>
    public async Task<IEnumerable<ExamResult>> GetExamResults()
    {
        return (await _context.ExamResults.ToListAsync())
            .Select(examResult => new ExamResult
            {
                Id = examResult.Id,
                SubjectName = examResult.SubjectName,
                Points = examResult.Points,
                EnrolleeId = examResult.EnrolleeId
            });
    }

    /// <summary>
    /// Получение результата экзамена по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор результата экзамена, который необходимо получить.</param>
    /// <returns>Запись.</returns>
    public async Task<ExamResult?> GetExamResult(int id)
    {
        var examResult = await _context.ExamResults
            .FirstOrDefaultAsync(examResult => examResult.Id == id);

        if (examResult == null)
        {
            return null;
        }

        return new ExamResult
        {
            Id = examResult.Id,
            SubjectName = examResult.SubjectName,
            Points = examResult.Points,
            EnrolleeId = examResult.EnrolleeId
        };
    }

    /// <summary>
    /// Создание результата экзамена.
    /// </summary>
    /// <param name="model">Модель, в которой содержатся данные для создания результата экзамена.</param>
    public async Task<int> AddExamResult(ExamResult model)
    {
        var examResultDbModel = new ExamResultDbModel
        {
            Id = model.Id,
            SubjectName = model.SubjectName,
            Points = model.Points,
            EnrolleeId = model.EnrolleeId
        };

        await _context.ExamResults.AddAsync(examResultDbModel);

        await _context.SaveChangesAsync();

        return examResultDbModel.Id;
    }

    /// <summary>
    /// Изменение данных результата экзамена.
    /// </summary>
    /// <param name="id">Идентификатор результата экзамена, данные которого необходимо изменить.</param>
    /// <param name="model">Содержит данные, которые будут присвоены необходимому результату экзамена.</param>
    public async Task UpdateExamResult(int id, ExamResult model)
    {
        var entity = await _context.ExamResults.FirstAsync(examResult => examResult.Id == id);

        entity.SubjectName = model.SubjectName;
        entity.Points = model.Points;
        entity.EnrolleeId = model.EnrolleeId;

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Удаление результата экзамена по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор результата экзамена, которого необходимо удалить.</param>
    public async Task DeleteExamResult(int id)
    {
        _context.ExamResults.Remove(await _context.ExamResults
            .FirstAsync(examResult => examResult.Id == id));

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Получение всех факультетов.
    /// </summary>
    /// <returns>Последовательность факультетов.</returns>
    public async Task<IEnumerable<Faculty>> GetFaculties()
    {
        return (await _context.Faculties.ToListAsync())
            .Select(faculty => new Faculty
            {
                Id = faculty.Id,
                Name = faculty.Name
            });
    }

    /// <summary>
    /// Получение факультета по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор факультета, которого необходимо получить.</param>
    /// <returns>Факутет.</returns>
    public async Task<Faculty?> GetFaculty(int id)
    {
        var faculty = await _context.Faculties
            .FirstOrDefaultAsync(faculty => faculty.Id == id);

        if (faculty == null)
        {
            return null;
        }

        return new Faculty
        {
            Id = faculty.Id,
            Name = faculty.Name
        };
    }

    /// <summary>
    /// Создание факультета.
    /// </summary>
    /// <param name="model">Модель, в которой содержатся данные для создания факультета.</param>
    public async Task<int> AddFaculty(Faculty model)
    {
        var facultyDbModel = new FacultyDbModel
        {
            Name = model.Name
        };

        await _context.Faculties.AddAsync(facultyDbModel);

        await _context.SaveChangesAsync();

        return facultyDbModel.Id;
    }

    /// <summary>
    /// Изменение данных факультета.
    /// </summary>
    /// <param name="id">Идентификатор факультета, данные которого необходимо изменить.</param>
    /// <param name="model">Содержит данные, которые будут присвоены необходимому факультету.</param>
    public async Task UpdateFaculty(int id, Faculty model)
    {
        var entity = await _context.Faculties
            .FirstAsync(faculty => faculty.Id == id);

        entity.Name = model.Name;

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Удаление факультета по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор факультета, которого необходимо удалить.</param>
    public async Task DeleteFaculty(int id)
    {
        _context.Faculties.Remove(await _context.Faculties.FirstAsync(faculty => faculty.Id == id));

        _context.Specializations.RemoveRange((await _context.Specializations
            .ToListAsync()).Where(specialization => specialization.FacultyId == id));

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Получение всех специальностей.
    /// </summary>
    /// <returns>Последовательность специальностей.</returns>
    public async Task<IEnumerable<Specialization>> GetSpecializations()
    {
        return (await _context.Specializations.ToListAsync())
            .Select(specialization => new Specialization
            {
                Id = specialization.Id,
                Priority = specialization.Priority,
                Name = specialization.Name,
                FacultyId = specialization.FacultyId
            });
    }

    /// <summary>
    /// Получение специальности по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор специальности, которую необходимо получить.</param>
    /// <returns>Специальность.</returns>
    public async Task<Specialization?> GetSpecialization(int id)
    {
        var specialization = await _context.Specializations
            .FirstOrDefaultAsync(specialization => specialization.Id == id);

        if (specialization == null)
        {
            return null;
        }

        return new Specialization
        {
            Id = specialization.Id,
            Priority = specialization.Priority,
            Name = specialization.Name,
            FacultyId = specialization.FacultyId
        };
    }

    /// <summary>
    /// Создание специальности.
    /// </summary>
    /// <param name="model">Модель, в которой содержатся данные для создания специальности.</param>
    public async Task<int> AddSpecialization(Specialization model)
    {
        var specializationDbModel = new SpecializationDbModel
        {
            Id = model.Id,
            Priority = model.Priority,
            Name = model.Name,
            FacultyId = model.FacultyId
        };

        await _context.Specializations.AddAsync(specializationDbModel);

        await _context.SaveChangesAsync();

        return specializationDbModel.Id;
    }

    /// <summary>
    /// Изменение данных специальности.
    /// </summary>
    /// <param name="id">Идентификатор специальности, данные которой необходимо изменить.</param>
    /// <param name="model">Содержит данные, которые будут присвоены необходимой специальности.</param>
    public async Task UpdateSpecialization(int id, Specialization model)
    {
        var entity = await _context.Specializations
            .FirstAsync(specialization => specialization.Id == id);

        entity.Priority = model.Priority;
        entity.Name = model.Name;
        entity.FacultyId = model.FacultyId;

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Удаление специальности по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор специальности, которую необходимо удалить.</param>
    public async Task DeleteSpecialization(int id)
    {
        _context.Remove(await _context.Specializations
            .FirstAsync(specialization => specialization.Id == id));

        await _context.SaveChangesAsync();
    }
}
