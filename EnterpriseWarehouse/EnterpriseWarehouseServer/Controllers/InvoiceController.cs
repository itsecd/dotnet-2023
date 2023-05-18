using Enterprise.Data;
using EnterpriseWarehouseServer.Dto;
using EnterpriseWarehouseServer.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace EnterpriseWarehouseServer.Controllers;
[Route("api/[controller]")]
[ApiController]
public class InvoiceController : ControllerBase
{
    private readonly ILogger<InvoiceController> _logger;

    private readonly IMainRepository _mainRepository;
    public InvoiceController(ILogger<InvoiceController> logger, IMainRepository mainRepository)
    {
        _logger = logger;
        _mainRepository = mainRepository;
    }

    /// <summary>
    ///     [HttpGet] - return all invoice
    /// </summary>
    /// <returns>List of Invoice</returns>
    [HttpGet]
    public IEnumerable<InvoiceGetDto> Get()
    {
        _logger.LogInformation("Get invoice.");
        return _mainRepository.Invoices.Select(invoice =>
            new InvoiceGetDto
            {
                Id = invoice.Id,
                NameOrganization = invoice.NameOrganization,
                AdressOrganization = invoice.AdressOrganization,
                ShipmentDate = invoice.ShipmentDate.ToShortDateString(),
                Products = invoice.Products,
            }
        );
    }

    /// <summary>
    ///     [HttpGet("{id}")] - return invoice with id
    /// </summary>
    /// <param Id = "id" >Id of the Invoice to be view</param>
    /// <returns>Info of product</returns>
    [HttpGet("{id}")]
    public ActionResult<InvoiceGetDto?> Get(int id)
    {
        var invoice = _mainRepository.Invoices.FirstOrDefault(invoice => invoice.Id == id);
        if (invoice == null)
        {
            _logger.LogInformation("Not found ivoice with {id}.", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get invoice with {id}.", id);
            return Ok(new InvoiceGetDto
            {
                Id = invoice.Id,
                NameOrganization = invoice.NameOrganization,
                AdressOrganization = invoice.AdressOrganization,
                ShipmentDate = invoice.ShipmentDate.ToShortDateString(),
                Products = invoice.Products,
            });
        }
    }

    /// <summary>
    ///     [HttpPost] - add new invoice
    /// </summary>
    /// <param Invoice>Add new Invoice</param>
    [HttpPost]
    public void Post([FromBody] InvoicePostDto invoice)
    {
        _mainRepository.Invoices.Add(new Invoice(
            invoice.Id,
            invoice.NameOrganization,
            invoice.AdressOrganization,
            invoice.ShipmentDate.ToDateTime(TimeOnly.Parse("10:00:00AM")),
            invoice.Products
            )
        );
    }

    /// <summary>
    ///     [HttpPut("{id}")] - update info of invoice with id
    /// </summary>
    /// <param Id="id">Id of the Invoice to be update</param>
    /// <returns>Result of operation</returns>
    [HttpPut("{id}")]
    public ActionResult<InvoicePostDto?> Put(int id, [FromBody] InvoicePostDto invoice_)
    {
        var invoice = _mainRepository.Invoices.FirstOrDefault(invoice => invoice.Id == id);
        if (invoice == null)
        {
            _logger.LogInformation("Not found ivoice with {id}.", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Put invoice with {id}.", id);
            invoice.Id = invoice_.Id;
            invoice.NameOrganization = invoice_.NameOrganization;
            invoice.AdressOrganization = invoice_.AdressOrganization;
            invoice.ShipmentDate = invoice_.ShipmentDate.ToDateTime(TimeOnly.Parse("10:00:00AM"));
            invoice.Products = invoice_.Products;
            return Ok();
        }
    }

    /// <summary>
    ///     [HttpDelete("{id}")] - delete invoice with id
    /// </summary>
    /// <param Id="id">Id of the Invoice to be removed</param>
    /// <returns>Result of operation</returns>
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var invoice = _mainRepository.Invoices.FirstOrDefault(invoice => invoice.Id == id);
        if (invoice == null)
        {
            _logger.LogInformation("Not found ivoice with {id}.", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Delete invoice with {id}.", id);
            _mainRepository.Invoices.Remove(invoice);
            return Ok();
        }
    }
}