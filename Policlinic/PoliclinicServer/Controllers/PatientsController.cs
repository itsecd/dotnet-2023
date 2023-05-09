using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Policlinic;
using PoliclinicServer.Dto;

namespace PoliclinicServer.Controllers;
/// <summary>
/// Patients controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class PatientsController : ControllerBase
{
    private readonly PoliclinicDbContext _context;

    private readonly IMapper _mapper;
    /// <summary>
    /// PatientsController constructor
    /// </summary>
    /// <param name="context"></param>
    /// <param name="mapper"></param>
    public PatientsController(PoliclinicDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Get all patients
    /// </summary>
    /// <returns>List of all patients</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PatientGetDto>>> GetPatients()
    {
        if (_context.Patients == null)
        {
            return NotFound();
        }
        return await _mapper.ProjectTo<PatientGetDto>(_context.Patients).ToListAsync();
    }

    /// <summary>
    /// Get patient with given id
    /// </summary>
    /// <param name="id">Patient's id</param>
    /// <returns>Patient</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<PatientGetDto>> GetPatient(int id)
    {
        if (_context.Patients == null)
        {
            return NotFound();
        }
        var patient = await _context.Patients.FindAsync(id);

        if (patient == null)
        {
            return NotFound();
        }

        return _mapper.Map<PatientGetDto>(patient);
    }

    /// <summary>
    /// Change data about patient
    /// </summary>
    /// <param name="id">Patient's id</param>
    /// <param name="patient">Changeable patient</param>
    /// <returns>The result of the operation</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPatient(int id, PatientPostDto patient)
    {
        if (_context.Patients == null)
        {
            return NotFound();
        }

        var patientToModify = await _context.Patients.FindAsync(id);
        if (patientToModify == null)
        {
            return NotFound();
        }

        _mapper.Map(patient, patientToModify);

        await _context.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>
    /// Add new patient
    /// </summary>
    /// <param name="patient">Patient</param>
    /// <returns>Created patient</returns>
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<PatientPostDto>> PostPatient(PatientPostDto patient)
    {
        if (_context.Patients == null)
        {
            return Problem("Entity set 'PoliclinicDbContext.Patients' is null.");
        }
        var mappedPatient = _mapper.Map<Patient>(patient);
        _context.Patients.Add(mappedPatient);

        await _context.SaveChangesAsync();

        return CreatedAtAction("PostPatient", new { id = mappedPatient.Id }, _mapper.Map<PatientPostDto>(mappedPatient));
    }

    /// <summary>
    /// Deletion a patient
    /// </summary>
    /// <param name="id">Patient's id</param>
    /// <returns>The result of the operation</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePatient(int id)
    {
        if (_context.Patients == null)
        {
            return NotFound();
        }
        var patient = await _context.Patients.FindAsync(id);
        if (patient == null)
        {
            return NotFound();
        }

        _context.Patients.Remove(patient);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
