﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PharmacyCityNetwork.Server.Dto;
using PharmacyCityNetwork.Server.Repository;

namespace PharmacyCityNetwork.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;

    private readonly IPharmacyCityNetworkRepository _productsRepository;
    private readonly IMapper _mapper;
    public ProductController(ILogger<ProductController> logger, IPharmacyCityNetworkRepository productsRepository, IMapper mapper)
    {
        _logger = logger;
        _productsRepository = productsRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<ProductGetDto> Get()
    {
        return _productsRepository.Products.Select(product => _mapper.Map<ProductGetDto>(product));
    }

    [HttpGet("{id}")]
    public ActionResult<Product> Get(int id)
    {
        var product = _productsRepository.Products.FirstOrDefault(product => product.Id == id);
        if (product == null)
        {
            _logger.LogInformation($"Not found product: {id}");
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<ProductGetDto>(product));
        }
    }

    [HttpPost]
    public void Post([FromBody] ProductPostDto product)
    {
        _productsRepository.Products.Add(_mapper.Map<Product>(product));
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ProductPostDto productToPut)
    {
        var product = _productsRepository.Products.FirstOrDefault(product => product.Id == id);
        if (product == null)
        {
            _logger.LogInformation("Not found product: {id}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(productToPut, product);
            return Ok();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var product = _productsRepository.Products.FirstOrDefault(product => product.Id == id);
        if (product == null)
        {
            _logger.LogInformation($"Not found product: {id}");
            return NotFound();
        }
        else
        {
            _productsRepository.Products.Remove(product);
            return Ok();
        }
    }
}