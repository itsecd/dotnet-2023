using AutoMapper;
using EnterpriseWarehouse.Model;
using EnterpriseWarehouse.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseWarehouse.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InvoiceContentController : ControllerBase
{
    private readonly ILogger<InvoiceContentController> _logger;

    private readonly EnterpriseWarehouseDbContext _context;

    private readonly IMapper _mapper;
    public InvoiceContentController(ILogger<InvoiceContentController> logger, EnterpriseWarehouseDbContext context, IMapper mapper)
    {
        _logger = logger;
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    ///     [HttpGet] - return all invoices content
    /// </summary>
    /// <returns>List of invoices content</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<InvoiceContentGetDto>>> Get()
    {
        _logger.LogInformation("Get products.");
        if (_context.InvoicesContent != null)
        {
            return await (from invoiceContent in _context.InvoicesContent
                          select new InvoiceContentGetDto
                          {
                              InvoiceId = invoiceContent.InvoiceId,
                              ProductIN = invoiceContent.Product.ItemNumber,
                              Quantity = invoiceContent.Quantity
                          }).ToListAsync();
        }
        else
            return NotFound();
    }

    /// <summary>
    ///     [HttpGet("{id}")] - return invoice content with id invoice
    /// </summary>
    /// <param id = "InvoiceId" >Invoice Id of the invoice whose contents are to be viewed</param>
    /// <returns>Info of invoice content</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<ActionResult<InvoiceContentGetDto?>>> Get(int id)
    {
        if (_context.InvoicesContent != null)
        {
            var invoiceContent = await (from _invoiceContent in _context.InvoicesContent
                                        where _invoiceContent.InvoiceId == id
                                        select new InvoiceContentGetDto
                                        {
                                            InvoiceId = _invoiceContent.InvoiceId,
                                            ProductIN = _invoiceContent.Product.ItemNumber,
                                            Quantity = _invoiceContent.Quantity
                                        }).ToListAsync();
            if (invoiceContent != null)
            {
                _logger.LogInformation("Get invoice content with invoiceId = {id}.", id);
                return Ok(invoiceContent);
            }
            else
            {
                _logger.LogInformation("Not found invoice content with invoiceId = {id}.", id);
                return NotFound();
            }
        }
        else
        {
            _logger.LogInformation("Not found invoice content with invoiceId = {id}.", id);
            return NotFound();
        }
    }

    /// <summary>
    ///     [HttpPost] - add new invoice content
    /// </summary>
    /// <param InvoiceContent>Add new invoice content </param>
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<int>> Post([FromBody] InvoiceContentPostDto invoiceContent)
    {
        if (_context.InvoicesContent != null && _context.Invoices != null && _context.Products != null)
        {
            var newProduct = await _context.Products.Where(product => product.ItemNumber == invoiceContent.ProductIN).FirstAsync();
            if (newProduct == null)
                return NotFound();
            var newInvoice = await _context.Invoices.Where(invoice => invoice.Id == invoiceContent.InvoiceId).FirstAsync();
            if (newInvoice == null)
                return NotFound();
            var newInvoiceContent = new InvoiceContent
            {
                InvoiceId = newInvoice.Id,
                Invoices = newInvoice,
                ProductID = newProduct.Id,
                Product = newProduct,
                Quantity = invoiceContent.Quantity
            };

            _context.Add(newInvoiceContent);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Post", newInvoiceContent.Id);
        }
        else
            return Problem("Entity set invoices content or invoices or products is null.");

    }

    /// <summary>
    ///     [HttpPut("{id}")] - update info of invoice content with invoiceId
    /// </summary>
    /// <param id="InvoiceId">InvoiceId of the invoice content to be update</param>
    /// <returns>Result of operation</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] InvoiceContentPostDto invoiceContentToPut)
    {
        if (_context.InvoicesContent == null || _context.Invoices == null || _context.Products == null)
            return NotFound();
        var invoiceContentToModify = await _context.InvoicesContent.Where(content => content.InvoiceId == id).FirstAsync();
        if (invoiceContentToModify == null)
        {
            _logger.LogInformation("Not found invoice content with invoiceId = {id}.", id);
            return NotFound();
        }
        else
        {
            var newProduct = await _context.Products.Where(product => product.ItemNumber == invoiceContentToPut.ProductIN).FirstAsync();
            var newInvoice = await _context.Invoices.Where(invoice => invoice.Id == invoiceContentToPut.InvoiceId).FirstAsync();
            if (newProduct != null && newInvoice != null)
            {
                invoiceContentToModify.Product = newProduct;
                invoiceContentToModify.Invoices = newInvoice;
                invoiceContentToModify.InvoiceId = invoiceContentToPut.InvoiceId;
                invoiceContentToModify.ProductID = newProduct.Id;
                invoiceContentToModify.Quantity = invoiceContentToPut.Quantity;
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
                return NotFound();
        }
    }

    /// <summary>
    ///     [HttpDelete("{id}")] - delete invoice content with invoiceId
    /// </summary>
    /// <param id="InvoiceId">id of the invoice content to be removed</param>
    /// <returns>Result of operation</returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        if (_context.InvoicesContent != null)
        {
            var invoiceContent = await _context.InvoicesContent.Where(content => content.InvoiceId == id).FirstAsync();
            if (invoiceContent == null)
            {
                _logger.LogInformation("Not found invoice content with invoiceId = {id}.", id);
                return NotFound();
            }
            else
            {
                _logger.LogInformation("Delete invoice content with invoiceId = {id}.", id);
                _context.InvoicesContent.Remove(invoiceContent);
                await _context.SaveChangesAsync();
                return Ok();
            }
        }
        else
            return NotFound();
    }
}
