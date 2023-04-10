using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Domain;
using StoreApp.Server.Dto;
using StoreApp.Server.Repository;

namespace StoreApp.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StoreController : ControllerBase
{

    private readonly ILogger<StoreController> _logger;
    private readonly IStoreAppRepository _storeAppRepository;
    private readonly IMapper _mapper;

    public StoreController(ILogger<StoreController> logger, IStoreAppRepository storeAppRepository, IMapper mapper)
    {
        _logger = logger;
        _storeAppRepository = storeAppRepository;
        _mapper = mapper;
    }


    [HttpGet]
    public IEnumerable<StoreGetDto> Get()
    {
        _logger.LogInformation("Get stores");
        return _storeAppRepository.Stores.Select(store => _mapper.Map<StoreGetDto>(store));
    }

    [HttpGet("{id}")]
    public ActionResult<StoreGetDto> Get(int id)
    {
        var getStore = _storeAppRepository.Stores.FirstOrDefault(store => store.StoreId == id);
        if (getStore == null)
        {
            _logger.LogInformation($"Not found store with ID: {id}.");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"GET store with ID: {id}.");
            return Ok(_mapper.Map<StoreGetDto>(getStore));
        }

    }

    [HttpPost]
    public ActionResult Post([FromBody] StorePostDto storeToPost)
    {
        _storeAppRepository.Stores.Add(_mapper.Map<Store>(storeToPost));
        _logger.LogInformation($"POST store ({storeToPost.StoreName},  {storeToPost.StoreAddress})");
        return Ok();
    }

    [HttpPut]
    public ActionResult Put(int id, [FromBody] StorePostDto cusomerToPut)
    {
        var store = _storeAppRepository.Stores.FirstOrDefault(x => x.StoreId == id);
        if (store == null)
        {
            _logger.LogInformation($"Not found store with ID: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"PUT store with ID: {id} ({store.StoreName}->{cusomerToPut.StoreName}, {store.StoreAddress}->{cusomerToPut.StoreAddress})");
            _mapper.Map(cusomerToPut, store);
            return Ok();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var store = _storeAppRepository.Stores.FirstOrDefault(x => x.StoreId == id);
        if (store == null)
        {
            _logger.LogInformation($"Not found store with ID: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"DELETE store with ID: {id}");
            _storeAppRepository.Stores.Remove(store);
            return Ok();
        }
    }


}
