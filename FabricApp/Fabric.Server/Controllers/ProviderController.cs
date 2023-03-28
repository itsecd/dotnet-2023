using Fabrics.Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fabrics.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProviderController : ControllerBase
{
    // GET: api/<ProviderController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/<ProviderController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<ProviderController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<ProviderController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<ProviderController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
