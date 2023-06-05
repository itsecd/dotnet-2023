using AutoMapper;
using EnterpriseWarehouse.Model;
using EnterpriseWarehouse.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace EnterpriseWarehouse.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AnalyticsController : ControllerBase
{
    private readonly ILogger<AnalyticsController> _logger;

    private readonly EnterpriseWarehouseDbContext _context;

    private readonly IMapper _mapper;
    public AnalyticsController(ILogger<AnalyticsController> logger, EnterpriseWarehouseDbContext context, IMapper mapper)
    {
        _logger = logger;
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    ///     [HttpGet("GetAllProductSortebByTitle")] - return information about the company's products, sorted by product name(Title)
    /// <return>List of Produc</return>
    /// </summary>
    [HttpGet("GetAllProductSortebByTitle")]
    public async Task<ActionResult<IEnumerable<ProductGetDto>>> GetAllProductSortebByTitle()
    {
        _logger.LogInformation("Get products.");
        if (_context.Products != null)
        {
            return await _mapper.ProjectTo<ProductGetDto>(_context.Products).OrderBy(product => product.Title).ToListAsync();
        }
        else
            return NotFound();
    }

    /// <summary>
    ///     [HttpGet("GetInformationProductReceivedOnCertainDay")] - return information about the company's products received on the specified day by the recipient of products
    /// <return>List of Produc</return>
    /// </summary>
    [HttpGet("GetInformationProductReceivedOnCertainDay/{date}")]
    public async Task<ActionResult<IEnumerable<ProductGetDto>>> GetInformationProductReceivedOnCertainDay(string date)
    {
        if (_context.Invoices != null && _context.InvoicesContent != null)
        {
            _logger.LogInformation("Get information product received on certain day.");
            var query = await (from invoice in _context.Invoices
                               where invoice.ShipmentDate == DateTime.Parse(date)
                               from invoiceContent in invoice.InvoicesContent
                               select new ProductGetDto
                               {
                                   ItemNumber = invoiceContent.Product.ItemNumber,
                                   Title = invoiceContent.Product.Title,
                                   Quantity = invoiceContent.Product.Quantity
                               }).ToListAsync();
            return query;
        }
        else
            return NotFound();
    }

    /// <summary>
    ///     [HttpGet("GetCurrentStateWarehouseWithCellNumbers")] - return the state of the warehouse at the moment with the numbers of cells of the warehouse and their contents
    /// <return>List information of product and storage cell</return>
    /// </summary>
    [HttpGet("GetCurrentStateWarehouseWithCellNumbers")]
    public async Task<ActionResult<IEnumerable<StatusStorageCellGetDto>>> GetCurrentStateWarehouseWithCellNumbers()
    {
        if (_context.StorageCells != null && _context.Products != null)
        {
            _logger.LogInformation("Get current state warehouse with cell numbers.");
            var query = await (from warehouse in _context.StorageCells
                               orderby warehouse.Number
                               select new StatusStorageCellGetDto
                               {
                                   Number = warehouse.Number,
                                   ItemNumberProducts = warehouse.Product.ItemNumber,
                                   Title = warehouse.Product.Title,
                                   Quantity = warehouse.Product.Quantity
                               }).ToListAsync();
            return query;
        }
        else
            return NotFound();
    }

    /// <summary>
    ///     [HttpGet("GetInfoOrganizationsReceivedMaxVolumeProductsForGivenPeriod")] - return information about the organizations that received the maximum volume products for a given period
    /// <return>Information of invoice with max quantity</return>
    /// </summary>
    [HttpGet("GetInfoOrganizationsReceivedMaxVolumeProductsForGivenPeriod/{date_begin},{date_end}")]
    public async Task<ActionResult<InfoOfAllInvoiceGetDto>> GetInfoOrganizationsReceivedMaxVolumeProductsForGivenPeriod(string date_begin, string date_end)
    {
        if (_context.StorageCells != null && _context.Products != null && _context.Invoices != null && _context.InvoicesContent != null)
        {
            _logger.LogInformation("Get info organizations received max volume products for given period.");
            Console.WriteLine(DateTime.Parse(date_begin));
            var query = await (from invoice in _context.Invoices
                               join invoiceContent in _context.InvoicesContent on invoice.Id equals invoiceContent.InvoiceId
                               where invoice.ShipmentDate >= DateTime.Parse(date_begin) && invoice.ShipmentDate <= DateTime.Parse(date_end)
                               group invoiceContent by new
                               {
                                   invoice.NameOrganization,
                                   invoice.AddressOrganization
                               } into grp
                               select new InfoOfAllInvoiceGetDto
                               {
                                   NameOrganization = grp.Key.NameOrganization,
                                   AdressOrganization = grp.Key.AddressOrganization,
                                   Quantity = grp.Sum(x => x.Quantity)
                               }).ToListAsync();
            InfoOfAllInvoiceGetDto? result = query.MaxBy(x => x.Quantity);
            return result;
        }
        else
            return NotFound();
    }

    /// <summary>
    ///     [HttpGet("GetTopFiveProductsByStockAvailability")] - return the top 5 products by stock availability
    /// <return>List of product</return>
    /// </summary>
    [HttpGet("GetTopFiveProductsByStockAvailability")]
    public async Task<ActionResult<IEnumerable<ProductGetDto>>> GetTopFiveProductsByStockAvailability()
    {
        if (_context.Products != null)
        {
            _logger.LogInformation("Get top five products by stock availability.");
            var query = await (from product in _context.Products
                               orderby product.Quantity descending
                               select new ProductGetDto
                               {
                                   ItemNumber = product.ItemNumber,
                                   Title = product.Title,
                                   Quantity = product.Quantity
                               }).Take(5).ToListAsync();
            return query;
        }
        else
            return NotFound();
    }

    /// <summary>
    ///     [HttpGet("GetInfoAboutTheQuantityGoodsDelivered")] - return information about the quantity of delivered goods for each goods and each organization
    /// <return>List of product and storage cell</return>
    /// </summary>
    [HttpGet("GetInfoAboutTheQuantityGoodsDelivered")]
    public async Task<ActionResult<IEnumerable<InfoAboutTheQuantityGoodsDeliveredGetDto>>> GetInfoAboutTheQuantityGoodsDelivered()
    {
        if (_context.StorageCells != null && _context.Products != null && _context.Invoices != null && _context.InvoicesContent != null)
        {
            _logger.LogInformation("Get info about the quantity goods delivered.");
            var query = await (from invoice in _context.Invoices
                               join invoiceContent in _context.InvoicesContent on invoice.Id equals invoiceContent.InvoiceId
                               join product in _context.Products on invoiceContent.ProductID equals product.Id
                               group invoiceContent by new
                               {
                                   invoice.NameOrganization,
                                   invoice.AddressOrganization,
                                   product.ItemNumber,
                                   product.Title
                               } into grp
                               select new InfoAboutTheQuantityGoodsDeliveredGetDto
                               {
                                   NameOrganization = grp.Key.NameOrganization,
                                   AdressOrganization = grp.Key.AddressOrganization,
                                   ItemNumber = grp.Key.ItemNumber,
                                   Title = grp.Key.Title,
                                   Quantity = grp.Sum(x => x.Quantity)
                               }).ToListAsync();
            return query;
        }
        else
            return NotFound();
    }
}
