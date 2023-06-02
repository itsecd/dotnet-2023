using AutoMapper;
using Enterprise.Data;
using EnterpriseWarehouseServer.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseWarehouseServer.Controllers;
[Route("api/[controller]")]
[ApiController]
public class InvoiceController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;

    private readonly EnterpriseWarehouseDbContext _context;

    private readonly IMapper _mapper;
    public InvoiceController(ILogger<ProductController> logger, EnterpriseWarehouseDbContext context, IMapper mapper)
    {
        _logger = logger;
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    ///     [HttpGet] - return all invoice
    /// </summary>
    /// <returns>List of Invoices</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<InvoiceGetDto>>> Get()
    {
        _logger.LogInformation("Get invoice.");
        if (_context.Invoices != null && _context.Products != null)
        {
            var result_temp = await (from invoice in _context.Invoices
                                     group invoice by new
                                     {
                                         invoiceId = invoice.Id,
                                         nameOrg = invoice.NameOrganization,
                                         addressOrg = invoice.AddressOrganization,
                                         shipmentDate = invoice.ShipmentDate
                                     } into grp
                                     select new
                                     {
                                         Id = grp.Key.invoiceId,
                                         NameOrganization = grp.Key.nameOrg,
                                         AdressOrganization = grp.Key.addressOrg,
                                         ShipmentDate = grp.Key.shipmentDate.ToShortDateString()
                                     }).ToListAsync();
            var result = new List<InvoiceGetDto>();
            foreach (var item in result_temp)
            {
                var products = await (from invoice in _context.Invoices
                                      from invoiceContent in invoice.InvoicesContent
                                      where invoice.Id == item.Id
                                      select new { invoiceContent.Product.ItemNumber, invoiceContent.Quantity }).ToDictionaryAsync(x => x.ItemNumber, x => x.Quantity);
                result.Add(new InvoiceGetDto
                {
                    Id = item.Id,
                    NameOrganization = item.NameOrganization,
                    AdressOrganization = item.AdressOrganization,
                    ShipmentDate = item.ShipmentDate,
                    Products = products
                });
            }
            return result;
        }
        else
            return NotFound();
    }

    /// <summary>
    ///     [HttpGet("{id}")] - return invoice with id
    /// </summary>
    /// <param Id = "id" >Id of the Invoices to be view</param>
    /// <returns>Info of product</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<InvoiceGetDto?>> Get(int id)
    {
        if (_context.Invoices != null && _context.InvoicesContent != null)
        {
            var invoice = await _context.Invoices.FirstOrDefaultAsync(invoice => invoice.Id == id);
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
                    AdressOrganization = invoice.AddressOrganization,
                    ShipmentDate = invoice.ShipmentDate.ToShortDateString(),
                    Products = _context.InvoicesContent.Where(res => res.InvoiceId == id).Select(result =>
                    new { result.Product.ItemNumber, result.Quantity }).ToDictionary(x => x.ItemNumber, x => x.Quantity)
                });
            }
        }
        else
        {
            _logger.LogInformation("Not found invoice with {id}.", id);
            return NotFound();
        }
    }

    /// <summary>
    ///     [HttpPost] - add new invoice
    /// </summary>
    /// <param Invoices>Add new Invoices</param>
    /// <returns>Result of operation</returns>
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<int>> Post([FromBody] InvoicePostDto invoice)
    {
        if (_context.Invoices != null)
        {
            var new_invoice = new Invoice(
                invoice.Id,
                invoice.NameOrganization,
                invoice.AdressOrganization,
                DateTime.Parse(invoice.ShipmentDate).Date
                );
            var mappedInvoice = _mapper.Map<Invoice>(new_invoice);
            _context.Invoices.Add(mappedInvoice);
            foreach (var elem in invoice.Products)
            {
                if (_context.Products != null && _context.InvoicesContent != null)
                {
                    var product = await _context.Products.FirstOrDefaultAsync(x => x.ItemNumber == elem.Key);
                    if (product != null)
                    {
                        var new_invoiceContent = new InvoiceContent
                        {
                            InvoiceId = new_invoice.Id,
                            ProductID = product.Id,
                            Quantity = elem.Value,
                            Product = product
                        };
                        var mappedInvoiceContent = _mapper.Map<InvoiceContent>(new_invoiceContent);
                        _context.InvoicesContent.Add(mappedInvoiceContent);
                    }
                    else
                        return Problem("Not found product with item number.");
                }
                else
                    return Problem("Entity set 'EnterpriseWarehouseDbContext.Products is null.");
            }
            _context.SaveChanges();
            return CreatedAtAction("Post", invoice.Id);
        }
        else
            return Problem("Entity set invoices is null.");
    }

    /// <summary>
    ///     [HttpPut("{id}")] - update info of invoice with id
    /// </summary>
    /// <param Id="id">Id of the Invoices to be update</param>
    /// <returns>Result of operation</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] InvoicePostDto invoice_)
    {
        if (_context.Invoices == null)
            return NotFound();
        var invoice = await _context.Invoices.FirstOrDefaultAsync(invoice => invoice.Id == id);
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
            invoice.AddressOrganization = invoice_.AdressOrganization;
            invoice.ShipmentDate = DateTime.Parse(invoice_.ShipmentDate);
            foreach (var elem in invoice_.Products)
            {
                if (_context.InvoicesContent != null && _context.Products != null)
                {
                    var invoicesContent = await _context.InvoicesContent.Where(product => (product.InvoiceId == invoice.Id)).FirstAsync();
                    if (invoicesContent != null)
                    {
                        var newProduct = await _context.Products.FirstOrDefaultAsync(_product => _product.ItemNumber == elem.Key);
                        invoicesContent.Product = newProduct;
                        invoicesContent.InvoiceId = invoice_.Id;
                        invoicesContent.ProductID = newProduct.Id;
                        invoicesContent.Quantity = elem.Value;
                    }
                    else
                        return NotFound();
                }
                else
                    return Problem("Entity set products or invoices content is null.");
            }
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

    /// <summary>
    ///     [HttpDelete("{id}")] - delete invoice with id
    /// </summary>
    /// <param Id="id">Id of the Invoices to be removed</param>
    /// <returns>Result of operation</returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        if (_context.Invoices != null)
        {
            var invoice = await _context.Invoices.FirstOrDefaultAsync(invoice => invoice.Id == id);
            if (invoice == null)
            {
                _logger.LogInformation("Not found ivoice with {id}.", id);
                return NotFound();
            }
            else
            {
                if (_context.InvoicesContent != null)
                {
                    _logger.LogInformation("Delete invoice with {id}.", id);
                    var products = await _context.InvoicesContent.Where(res => res.InvoiceId == id).ToListAsync();
                    if (products != null)
                    {
                        for (var i = 0; i < products.Count(); i++)
                        {
                            _context.InvoicesContent.Remove(products[i]);
                        }
                    }
                    _context.Invoices.Remove(invoice);
                    await _context.SaveChangesAsync();
                    return NoContent();
                }
                else
                    return Problem("Entity set invoices content is null.");
            }
        }
        else
            return Problem("Entity set invoices is null.");
    }
}