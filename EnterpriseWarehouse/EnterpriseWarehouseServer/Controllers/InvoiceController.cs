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

    private readonly IMainRepository _context;
    public InvoiceController(ILogger<InvoiceController> logger, IMainRepository mainRepository)
    {
        _logger = logger;
        _context = mainRepository;
    }

    /// <summary>
    ///     [HttpGet] - return all invoice
    /// </summary>
    /// <returns>List of Invoice</returns>
    [HttpGet]
    public IEnumerable<InvoiceGetDto> Get()
    {
        _logger.LogInformation("Get invoice.");
        var result = (from invoice in _context.Invoices
                      group invoice by new
                      {
                          invoiceId = invoice.Id,
                          nameOrg = invoice.NameOrganization,
                          addressOrg = invoice.AdressOrganization,
                          shipmentDate = invoice.ShipmentDate
                      } into grp
                      select new InvoiceGetDto
                      {
                          Id = grp.Key.invoiceId,
                          NameOrganization = grp.Key.nameOrg,
                          AdressOrganization = grp.Key.addressOrg,
                          ShipmentDate = grp.Key.shipmentDate.ToShortDateString(),
                          Products = (from invoiceContent in _context.InvoicesContent
                                      where invoiceContent.InvoiceId == grp.Key.invoiceId
                                      select (invoiceContent.ProductItemNumber, invoiceContent.Quantity)).ToDictionary(x => x.ProductItemNumber, x => x.Quantity)
                      });
        return result;
        /* return _context.Invoices.Select(invoice =>
             new InvoiceGetDto
             {
                 Id = invoice.Id,
                 NameOrganization = invoice.NameOrganization,
                 AdressOrganization = invoice.AdressOrganization,
                 ShipmentDate = invoice.ShipmentDate.ToShortDateString(),
                 Products = invoice.InvoiceContentId,
             }
         );*/
    }

    /// <summary>
    ///     [HttpGet("{id}")] - return invoice with id
    /// </summary>
    /// <param Id = "id" >Id of the Invoice to be view</param>
    /// <returns>Info of product</returns>
    [HttpGet("{id}")]
    public ActionResult<InvoiceGetDto?> Get(int id)
    {
        var invoice = _context.Invoices.FirstOrDefault(invoice => invoice.Id == id);
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
                Products = _context.InvoicesContent.Where(res => res.InvoiceId == id).Select(result =>
                (result.ProductItemNumber, result.Quantity)).ToDictionary(x => x.ProductItemNumber, x => x.Quantity)
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
        var new_invoice = new Invoice(
            invoice.Id,
            invoice.NameOrganization,
            invoice.AdressOrganization,
            DateTime.ParseExact(invoice.ShipmentDate, "dd.mm.yyyy", null).Date
            );
        foreach (var elem in invoice.Products)
        {
            var product = _context.Products.FirstOrDefault(x => x.ItemNumber == elem.Key);
            var new_invoiceContent = new InvoiceContent(
                 (uint)new Random().Next(4, 10000),
                 new_invoice,
                 product,
                 elem.Value
                );
            new_invoiceContent.ProductItemNumber = elem.Key;
            new_invoiceContent.InvoiceId = invoice.Id;
            new_invoice.InvoiceContent.Add(new_invoiceContent);
            product.InvoiceContent.Add(new_invoiceContent);
            _context.InvoicesContent.Add(new_invoiceContent);
        }
        _context.Invoices.Add(new_invoice);
    }

    /// <summary>
    ///     [HttpPut("{id}")] - update info of invoice with id
    /// </summary>
    /// <param Id="id">Id of the Invoice to be update</param>
    /// <returns>Result of operation</returns>
    [HttpPut("{id}")]
    public ActionResult<InvoicePostDto?> Put(int id, [FromBody] InvoicePostDto invoice_)
    {
        var invoice = _context.Invoices.FirstOrDefault(invoice => invoice.Id == id);
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
            invoice.ShipmentDate = DateTime.ParseExact(invoice_.ShipmentDate, "dd.mm.yyyy", null).Date;
            foreach (var elem in invoice_.Products)
            {
                var product = _context.InvoicesContent.FirstOrDefault(product => (product.InvoiceId == invoice.Id && product.ProductItemNumber == elem.Key));
                if (product != null)
                {
                    product.Product = _context.Products.FirstOrDefault(_product => _product.ItemNumber == product.ProductItemNumber);
                    product.InvoiceId = invoice_.Id;
                    product.ProductItemNumber = elem.Key;
                    product.Quantity = elem.Value;
                }
                else
                {
                    _context.InvoicesContent.Add(new InvoiceContent(
                        (uint)new Random().Next(4, 10000),
                        invoice,
                        _context.Products.FirstOrDefault(product_ => product_.ItemNumber == elem.Key),
                        elem.Value
                    ));
                }
            }

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
        var invoice = _context.Invoices.FirstOrDefault(invoice => invoice.Id == id);
        if (invoice == null)
        {
            _logger.LogInformation("Not found ivoice with {id}.", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Delete invoice with {id}.", id);
            var products = _context.InvoicesContent.Where(res => res.InvoiceId == id).ToList();
            if (products != null)
            {
                for (var i = 0; i < products.Count(); i++)
                {
                    _context.InvoicesContent.Remove(products[i]);
                }
            }
            _context.Invoices.Remove(invoice);
            return Ok();
        }
    }
}