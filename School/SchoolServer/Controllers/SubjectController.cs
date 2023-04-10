using AutoMapper;
using SchoolServer.Dto;
using SchoolServer.Repository;
//using DotnetDiary.DiaryDomain;
using School.Classes;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ILogger<SubjectController> _logger;

        private readonly ISchoolRepository _diaryRepository;

        private readonly IMapper _mapper;

        public SubjectController(ILogger<SubjectController> logger, ISchoolRepository diaryRepository, IMapper mapper)
        {
            _logger = logger;
            _diaryRepository = diaryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<SubjectGetDto> Get()
        {
            return _diaryRepository.Subjects.Select(subject => _mapper.Map<SubjectGetDto>(subject));
        }

        // GET api/<SubjectController>/5
        [HttpGet("{id}")]
        public ActionResult<SubjectGetDto> Get(int id)
        {
            var diarySubject = _diaryRepository.Subjects.FirstOrDefault(subject => subject.Id == id);
            if (diarySubject == null)
            {
                _logger.LogInformation("Not Found class with id = {id}", id);
                return NotFound();
            }
            else
            {
                return Ok(_mapper.Map<SubjectGetDto>(diarySubject));
            }
        }

        // POST api/<SubjectController>
        [HttpPost]
        public void Post([FromBody] SubjectGetDto subject)
        {
            _diaryRepository.Subjects.Add(_mapper.Map<Subject>(subject));
        }

        // DELETE api/<SubjectController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var diarySubject = _diaryRepository.Subjects.FirstOrDefault(subject => subject.Id == id);
            if (diarySubject == null)
            {
                _logger.LogInformation("Not Found class with id = {id}", id);
                return NotFound();
            }
            else
            {
                _diaryRepository.Subjects.Remove(diarySubject);
                return Ok();
            }
        }
    }
}
