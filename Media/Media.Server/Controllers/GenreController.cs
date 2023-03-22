using Media.Domain;
using Microsoft.AspNetCore.Mvc;


namespace Media.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class GenreController : ControllerBase
{
    private MediaRepository _repository;
    public GenreController(MediaRepository repository)
    {
        _repository = repository;
    }
    [HttpGet]
    public IEnumerable<Genre> Get()
    {
        return _repository.Genres;
    }

    [HttpGet("{id}")]
    public ActionResult<Genre> Get(int id)
    {
        var genre = _repository.Genres.FirstOrDefault(genre => genre.Id == id);
        if (genre == null) { return NotFound(); }
        else return Ok(genre);
    }

    [HttpPost]
    public void Post([FromBody] GenreDto genre)
    {
        _repository.Genres.Add(new Genre
        {
            Id = genre.Id,
            Name = genre.Name
        });
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Genre putGenre)
    {
        var genreIndex = _repository.Genres.IndexOf(putGenre);
        var genre = _repository.Genres.FirstOrDefault(genre => genre.Id == id);
        if (genre == null)
        {
            _repository.Genres.Add(new Genre
            {
                Id = putGenre.Id,
                Name = putGenre.Name
            });
            return NotFound();
        }
        else
        {
            genre.Name = putGenre.Name;
            genre.Id = putGenre.Id;
            return Ok(new { genre.Id });
        }
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        var genre = _repository.Genres.FirstOrDefault(genre => genre.Id == id);
        if (genre != null) _repository.Genres.Remove(genre);
    }
}
