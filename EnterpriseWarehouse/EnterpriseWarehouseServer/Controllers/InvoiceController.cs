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

    private readonly IInvoiceRepository _invoiceRepository;
    public InvoiceController(ILogger<InvoiceController> logger, IInvoiceRepository invoiceRepository)
    {
        _logger = logger;
        _invoiceRepository = invoiceRepository;
    }

    [HttpGet]
    public IEnumerable<InvoiceGetDto> Get()
    {
        _logger.LogInformation("Get invoice.");
        return _invoiceRepository.Invoices.Select(invoice =>
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

    [HttpGet("{id}")]
    public ActionResult<InvoiceGetDto?> Get(int id)
    {
        var invoice = _invoiceRepository.Invoices.FirstOrDefault(invoice => invoice.Id == id);
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

    [HttpPost]
    public void Post([FromBody] InvoicePostDto invoice)
    {
        _invoiceRepository.Invoices.Add(new Invoice(
            invoice.Id,
            invoice.NameOrganization,
            invoice.AdressOrganization,
            invoice.ShipmentDate.ToDateTime(TimeOnly.Parse("10:00:00AM")),
            invoice.Products
            )
        );
    }

    [HttpPut("{id}")]
    public ActionResult<InvoicePostDto?> Put(int id, [FromBody] InvoicePostDto invoice_)
    {
        var invoice = _invoiceRepository.Invoices.FirstOrDefault(invoice => invoice.Id == id);
        if (invoice == null)
        {
            _logger.LogInformation("Not found ivoice with {id}.", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get invoice with {id}.", id);
            invoice.Id = invoice_.Id;
            invoice.NameOrganization = invoice_.NameOrganization;
            invoice.AdressOrganization = invoice_.AdressOrganization;
            invoice.ShipmentDate = invoice_.ShipmentDate.ToDateTime(TimeOnly.Parse("10:00:00AM"));
            invoice.Products = invoice_.Products;
            return Ok();
        }
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var invoice = _invoiceRepository.Invoices.FirstOrDefault(invoice => invoice.Id == id);
        if (invoice == null)
        {
            _logger.LogInformation("Not found ivoice with {id}.", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get invoice with {id}.", id);
            _invoiceRepository.Invoices.Remove(invoice);
            return Ok();
        }
    }
}