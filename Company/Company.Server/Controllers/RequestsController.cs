using AutoMapper;
using Company.Domain;
using Company.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company.Server.Controllers;

/// <summary>
/// Controller for requesting different data sets
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RequestsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ILogger<RequestsController> _logger;
    private readonly CompanyDbContext _context;

    /// <summary>
    /// A constructor of the RequestsController
    /// </summary>
    public RequestsController(IMapper mapper, ILogger<RequestsController> logger, CompanyDbContext context)
    {
        _mapper = mapper;
        _logger = logger;
        _context = context;
    }


    /// <summary>
    /// Request #1 outputs all Workers of the given Department 
    /// </summary>
    /// <param name="id">Id of Department</param>
    /// <returns>All Workers of the given Department</returns>
    [HttpGet("Request1/{id}")]
    public async Task<ActionResult<IEnumerable<WorkerGetDto>>> GetRequest1(int id)
    {
        var workers = await _context.WorkerDb.ToListAsync();
        var departments = await _context.DepartmentDb.ToListAsync();
        var workersAndDepartments = await _context.WorkersAndDepartmentsDb.ToListAsync();

        var query = (from worker in workers
                     join obj in workersAndDepartments on worker.Id equals obj.WorkerId
                     join department in departments on obj.DepartmentId equals department.Id
                     where department.Id == id
                     select _mapper.Map<WorkerGetDto>(worker)).ToList();

        return query;
    }


    /// <summary>
    /// Request #2 outputs all Workers working in more than 1 Department; the result is sorted by last name, first name, patronymic name
    /// </summary>
    /// <returns>All Workers working in more than 1 Department</returns>
    [HttpGet("Request2")]
    public async Task<ActionResult<IEnumerable<Request2Dto>>> GetRequest2()
    {
        var workers = await _context.WorkerDb.ToListAsync();
        var workersAndDepartments = await _context.WorkersAndDepartmentsDb.ToListAsync();

        var query = (from worker in workers
                     join obj in workersAndDepartments on worker.Id equals obj.WorkerId
                     group worker by new
                     {
                         worker.Id,
                         worker.RegistrationNumber,
                         worker.LastName,
                         worker.FirstName,
                         worker.Patronymic
                     } into grp
                     where grp.Count() > 1
                     orderby grp.Key.LastName, grp.Key.FirstName, grp.Key.Patronymic
                     select new Request2Dto()
                     {
                         Id = grp.Key.Id,
                         RegistrationNumber = grp.Key.RegistrationNumber,
                         LastName = grp.Key.LastName,
                         FirstName = grp.Key.FirstName,
                         Patronymic = grp.Key.Patronymic,
                         NumberOfDepartments = grp.Count()
                     }).ToList();

        return query;
    }


    /// <summary>
    /// Request #3 outputs the archive of dismissals, including registration number, first name, last name, 
    /// patronymic, birth date, workshop, department and job of the worker
    /// </summary>
    /// <returns>Archive of dismissals</returns>
    [HttpGet("Request3")]
    public async Task<ActionResult<IEnumerable<Request3Dto>>> GetRequest3()
    {
        var MaxDateTime = new DateTime(9999, 12, 31);

        var workers = await _context.WorkerDb.ToListAsync();
        var departments = await _context.DepartmentDb.ToListAsync();
        var jobs = await _context.JobDb.ToListAsync();
        var workshops = await _context.WorkshopDb.ToListAsync();
        var workersAndDepartments = await _context.WorkersAndDepartmentsDb.ToListAsync();
        var workersAndJobs = await _context.WorkersAndJobsDb.ToListAsync();

        var query = (from worker in workers
                     join obj1 in workersAndDepartments on worker.Id equals obj1.WorkerId
                     join department in departments on obj1.DepartmentId equals department.Id
                     join obj2 in workersAndJobs on worker.Id equals obj2.WorkerId
                     join job in jobs on obj2.JobId equals job.Id
                     join workshop in workshops on worker.WorkshopId equals workshop.Id
                     where obj2.DismissalDate != MaxDateTime
                     select new Request3Dto()
                     {
                         Id = worker.Id,
                         RegistrationNumber = worker.RegistrationNumber,
                         LastName = worker.LastName,
                         FirstName = worker.FirstName,
                         Patronymic = worker.Patronymic,
                         BirthDate = worker.BirthDate,
                         DepartmentName = department.Name,
                         JobName = job.Name,
                         WorkshopName = workshop.Name,
                         DismissalDate = obj2.DismissalDate
                     }).ToList();

        return query;
    }


    /// <summary>
    /// Request #4 outputs an average age of Workers for each department
    /// </summary>
    /// <returns>average age of Workers for each department</returns>
    [HttpGet("Request4")]
    public async Task<ActionResult<IEnumerable<Request4Dto>>> GetRequest4()
    {
        var workers = await _context.WorkerDb.ToListAsync();
        var departments = await _context.DepartmentDb.ToListAsync();
        var workersAndDepartments = await _context.WorkersAndDepartmentsDb.ToListAsync();

        var query = (from tuple in from worker in workers
                                   join obj in workersAndDepartments on worker.Id equals obj.WorkerId
                                   select new
                                   {
                                       workerAge = (DateTime.Now - worker.BirthDate).TotalDays / 365,
                                       departmentId = obj.Department?.Id,
                                       departmentName = obj.Department?.Name
                                   }
                     group tuple by new
                     {
                         tuple.departmentId,
                         tuple.departmentName
                     } into grp
                     select new Request4Dto()
                     {
                         DepartmentName = grp.Key.departmentName,
                         AverageAge = grp.Average(worker => worker.workerAge)
                     }).ToList();

        return query;
    }


    /// <summary>
    /// Request #5 outputs the info about Workers, who received a vacation in past year
    /// </summary>
    /// <returns>The info about Workers, who received a vacation in past year</returns>
    [HttpGet("Request5")]
    public async Task<ActionResult<IEnumerable<Request5Dto>>> GetRequest5()
    {
        var workers = await _context.WorkerDb.ToListAsync();
        var vacations = await _context.VacationDb.ToListAsync();
        var workersAndVacations = await _context.WorkersAndVacationsDb.ToListAsync();

        var query = (from worker in workers
                     join obj in workersAndVacations on worker.Id equals obj.WorkerId
                     join vacation in vacations on obj.VacationId equals vacation.Id
                     where (DateTime.Now - vacation.IssueDate).TotalDays < 365
                     select new Request5Dto()
                     {
                         Id = worker.Id,
                         RegistrationNumber = worker.RegistrationNumber,
                         LastName = worker.LastName,
                         FirstName = worker.FirstName,
                         IssueDate = vacation.IssueDate
                     }).ToList();
        return query;
    }


    /// <summary>
    /// Request #6 outputs the top-5 Workers, who have the longest working experience it the company
    /// </summary>
    /// <returns>The top-5 Workers, who have the longest working experience it the company</returns>
    [HttpGet("Request6")]
    public async Task<ActionResult<IEnumerable<Request6Dto>>> GetRequest6()
    {
        var MaxDateTime = new DateTime(9999, 12, 31);

        var workers = await _context.WorkerDb.ToListAsync();
        var workersAndJobs = await _context.WorkersAndJobsDb.ToListAsync();

        var additionalQuery = (from worker in workers
                               join obj in workersAndJobs on worker.Id equals obj.WorkerId
                               select new
                               {
                                   worker.Id,
                                   worker.RegistrationNumber,
                                   worker.LastName,
                                   worker.FirstName,
                                   worker.Patronymic,
                                   obj.HireDate,
                                   dismissalDate = (obj.DismissalDate == MaxDateTime) ? DateTime.Now : obj.DismissalDate
                               }).ToList();
        var query = (from obj in additionalQuery
                     group obj by new
                     {
                         obj.Id,
                         obj.RegistrationNumber,
                         obj.LastName,
                         obj.FirstName,
                         obj.Patronymic
                     } into grp
                     let workExperience = grp.Sum(grpElem => (grpElem.dismissalDate - grpElem.HireDate).TotalDays / 365)
                     orderby workExperience descending
                     select new Request6Dto()
                     {
                         Id = grp.Key.Id,
                         RegistrationNumber = grp.Key.RegistrationNumber,
                         LastName = grp.Key.LastName,
                         FirstName = grp.Key.FirstName,
                         Patronymic = grp.Key.Patronymic,
                         WorkExperience = workExperience
                     }).Take(5).ToList();

        return query;
    }
}