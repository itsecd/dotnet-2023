using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Policlinic;
using PoliclinicServer.Dto;

namespace PoliclinicServer.Controllers;
/// <summary>
/// Doctors controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class DoctorsController : ControllerBase
{
    private readonly PoliclinicDbContext _context;

    private readonly IMapper _mapper;
    /// <summary>
    /// DoctorsController constructor
    /// </summary>
    /// <param name="context"></param>
    /// <param name="mapper"></param>
    public DoctorsController(PoliclinicDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Get all doctors
    /// </summary>
    /// <returns>List of all doctors</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DoctorGetDto>>> GetDoctors()
    {
        if (_context.Doctors == null)
        {
            return NotFound();
        }
        return await _mapper.ProjectTo<DoctorGetDto>(_context.Doctors).ToListAsync();
    }

    /// <summary>
    /// Get doctor with given id
    /// </summary>
    /// <param name="id">Doctor's id</param>
    /// <returns>Doctor</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<DoctorGetDto>> GetDoctor(int id)
    {
        if (_context.Doctors == null)
        {
            return NotFound();
        }
        var doctor = await _context.Doctors.FindAsync(id);

        if (doctor == null)
        {
            return NotFound();
        }

        return _mapper.Map<DoctorGetDto>(doctor);
    }

    /// <summary>
    /// Change data about doctor
    /// </summary>
    /// <param name="id">Doctor's id</param>
    /// <param name="doctor">Changeable doctor</param>
    /// <returns>The result of the operation</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutDoctor(int id, DoctorPostDto doctor)
    {
        if (_context.Doctors == null)
        {
            return NotFound();
        }

        var doctorToModify = await _context.Doctors.FindAsync(id);
        if (doctorToModify == null)
        {
            return NotFound();
        }

        _mapper.Map(doctor, doctorToModify);

        await _context.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>
    /// Add new doctor
    /// </summary>
    /// <param name="doctor">Doctor</param>
    /// <returns>Created doctor</returns>
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<DoctorPostDto>> PostDoctor(DoctorPostDto doctor)
    {
        if (_context.Doctors == null)
        {
            return Problem("Entity set 'PoliclinicDbContext.Doctors' is null.");
        }
        var mappedDoctor = _mapper.Map<Doctor>(doctor);
        _context.Doctors.Add(mappedDoctor);

        await _context.SaveChangesAsync();

        return CreatedAtAction("PostDoctor", new { id = mappedDoctor.Id }, _mapper.Map<DoctorPostDto>(mappedDoctor));
    }

    /// <summary>
    /// Deletion a doctor
    /// </summary>
    /// <param name="id">Doctor's id</param>
    /// <returns>The result of the operation</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDoctor(int id)
    {
        if (_context.Doctors == null)
        {
            return NotFound();
        }
        var doctor = await _context.Doctors.FindAsync(id);
        if (doctor == null)
        {
            return NotFound();
        }

        _context.Doctors.Remove(doctor);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}

