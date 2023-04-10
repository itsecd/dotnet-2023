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

    /// <summary>
    /// GET all stores
    /// </summary>
    /// <returns>
    /// JSON stores
    /// </returns>
    [HttpGet]
    public IEnumerable<StoreGetDto> Get()
    {
        _logger.LogInformation("Get stores");
        return _storeAppRepository.Stores.Select(store => _mapper.Map<StoreGetDto>(store));
    }

    /// <summary>
    /// GET store by ID
    /// </summary>
    /// <param name="storeId">
    /// ID
    /// </param>
    /// <returns>
    /// JSON store
    /// </returns>
    [HttpGet("{storeId}")]
    public ActionResult<StoreGetDto> Get(int storeId)
    {
        var getStore = _storeAppRepository.Stores.FirstOrDefault(store => store.StoreId == storeId);
        if (getStore == null)
        {
            _logger.LogInformation($"Not found store with ID: {storeId}.");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"GET store with ID: {storeId}.");
            return Ok(_mapper.Map<StoreGetDto>(getStore));
        }

    }

    /// <summary>
    /// POST store
    /// </summary>
    /// <param name="storeToPost">
    /// Store
    /// </param>
    /// <returns>
    /// Code-200
    /// </returns>
    [HttpPost]
    public ActionResult Post([FromBody] StorePostDto storeToPost)
    {
        _storeAppRepository.Stores.Add(_mapper.Map<Store>(storeToPost));
        _logger.LogInformation($"POST store ({storeToPost.StoreName},  {storeToPost.StoreAddress})");
        return Ok();
    }

    /// <summary>
    /// PUT store
    /// </summary>
    /// <param name="storeId">
    /// ID
    /// </param>
    /// <param name="storeToPut">
    /// Store
    /// </param>
    /// <returns>
    /// Code-200 or Code-404
    /// </returns>
    [HttpPut("{storeId}")]
    public ActionResult Put(int storeId, [FromBody] StorePostDto storeToPut)
    {
        var store = _storeAppRepository.Stores.FirstOrDefault(x => x.StoreId == storeId);
        if (store == null)
        {
            _logger.LogInformation($"Not found store with ID: {storeId}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"PUT store with ID: {storeId} ({store.StoreName}->{storeToPut.StoreName}, {store.StoreAddress}->{storeToPut.StoreAddress})");
            _mapper.Map(storeToPut, store);
            return Ok();
        }
    }

    /// <summary>
    /// DELETE store
    /// </summary>
    /// <param name="storeId">
    /// ID
    /// </param>
    /// <returns>
    /// Code-200 or Code-404
    /// </returns>
    [HttpDelete("{storeId}")]
    public IActionResult Delete(int storeId)
    {
        var store = _storeAppRepository.Stores.FirstOrDefault(x => x.StoreId == storeId);
        if (store == null)
        {
            _logger.LogInformation($"Not found store with ID: {storeId}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"DELETE store with ID: {storeId}");
            _storeAppRepository.Stores.Remove(store);
            return Ok();
        }
    }
}
