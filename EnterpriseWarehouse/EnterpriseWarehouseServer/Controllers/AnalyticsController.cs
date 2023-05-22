using EnterpriseWarehouseServer.Dto;
using EnterpriseWarehouseServer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseWarehouseServer.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AnalyticsController : ControllerBase
{
    private readonly ILogger<AnalyticsController> _logger;

    private readonly IMainRepository _context;
    public AnalyticsController(ILogger<AnalyticsController> logger, IMainRepository mainRepository)
    {
        _logger = logger;
        _context = mainRepository;
    }

    /// <summary>
    ///     [HttpGet("GetAllProductSortebByTitle")] - return information about the company's products, sorted by product name(Title)
    /// <return>List of Produc</return>
    /// </summary>
    [HttpGet("GetAllProductSortebByTitle")]
    public IEnumerable<ProductGetDto> GetAllProductSortebByTitle()
    {
        _logger.LogInformation("Get all product sorteb by title.");
        return _context.Products.Select(product =>
            new ProductGetDto
            {
                ItemNumber = product.ItemNumber,
                Title = product.Title,
                Quantity = product.Quantity
            }
        ).OrderBy(_context => _context.Title);
    }

    /// <summary>
    ///     [HttpGet("GetInformationProductReceivedOnCertainDay")] - return information about the company's products received on the specified day by the recipient of products
    /// <return>List of Produc</return>
    /// </summary>
    [HttpGet("GetInformationProductReceivedOnCertainDay/{date}")]
    public IEnumerable<ProductGetDto> GetInformationProductReceivedOnCertainDay(string date)
    {
        _logger.LogInformation("Get information product received on certain day.");
        var query = (from invoice in _context.Invoices
                     where invoice.ShipmentDate == DateTime.Parse(date).Date
                     from invoiceContent in invoice.InvoiceContent
                     select new ProductGetDto
                     {
                         ItemNumber = invoiceContent.Product.ItemNumber,
                         Title = invoiceContent.Product.Title,
                         Quantity = invoiceContent.Product.Quantity
                     }).ToList();
        return query;
    }

    /// <summary>
    ///     [HttpGet("GetCurrentStateWarehouseWithCellNumbers")] - return the state of the warehouse at the moment with the numbers of cells of the warehouse and their contents
    /// <return>List information of product and storage cell</return>
    /// </summary>
    [HttpGet("GetCurrentStateWarehouseWithCellNumbers")]
    public IEnumerable<StatusStorageCellGetDto> GetCurrentStateWarehouseWithCellNumbers()
    {
        _logger.LogInformation("Get current state warehouse with cell numbers.");
        var query = (from warehouse in _context.StorageCell
                     join product in _context.Products on warehouse.ItemNumberProducts equals product.ItemNumber
                     orderby warehouse.Number
                     select new StatusStorageCellGetDto
                     {
                         Number = warehouse.Number,
                         ItemNumberProducts = warehouse.ItemNumberProducts,
                         Title = product.Title,
                         Quantity = product.Quantity,
                     }).ToList();
        return query;
    }

    /// <summary>
    ///     [HttpGet("GetInfoOrganizationsReceivedMaxVolumeProductsForGivenPeriod")] - return information about the organizations that received the maximum volume products for a given period
    /// <return>Information of invoice with max quantity</return>
    /// </summary>
    [HttpGet("GetInfoOrganizationsReceivedMaxVolumeProductsForGivenPeriod/{date_begin},{date_end}")]
    public InfoOfAllInvoiceGetDto GetInfoOrganizationsReceivedMaxVolumeProductsForGivenPeriod(string date_begin, string date_end)
    {
        _logger.LogInformation("Get info organizations received max volume products for given period.");
        var query = (from invoice in _context.Invoices
                     join invoiceContent in _context.InvoicesContent on invoice.Id equals invoiceContent.InvoiceId
                     join product in _context.Products on invoiceContent.ProductItemNumber equals product.ItemNumber
                     where invoice.ShipmentDate >= DateTime.Parse(date_begin).Date && invoice.ShipmentDate <= DateTime.Parse(date_end).Date
                     group invoiceContent by new
                     {
                         invoice.NameOrganization,
                         invoice.AdressOrganization
                     } into grp
                     select new InfoOfAllInvoiceGetDto
                     {
                         NameOrganization = grp.Key.NameOrganization,
                         AdressOrganization = grp.Key.AdressOrganization,
                         Quantity = grp.Sum(x => x.Quantity)
                     }).ToList();
        InfoOfAllInvoiceGetDto? result = query.MaxBy(x => x.Quantity);
        return result;
    }

    /// <summary>
    ///     [HttpGet("GetTopFiveProductsByStockAvailability")] - return the top 5 products by stock availability
    /// <return>List of product</return>
    /// </summary>
    [HttpGet("GetTopFiveProductsByStockAvailability")]
    public IEnumerable<ProductGetDto> GetTopFiveProductsByStockAvailability()
    {
        _logger.LogInformation("Get top five products by stock availability.");
        var query = (from product in _context.Products
                     orderby product.Quantity descending
                     select new ProductGetDto
                     {
                         ItemNumber = product.ItemNumber,
                         Title = product.Title,
                         Quantity = product.Quantity
                     }).Take(5).ToList();
        return query;
    }

    /// <summary>
    ///     [HttpGet("GetInfoAboutTheQuantityGoodsDelivered")] - return information about the quantity of delivered goods for each goods and each organization
    /// <return>List of product and storage cell</return>
    /// </summary>
    [HttpGet("GetInfoAboutTheQuantityGoodsDelivered")]
    public IEnumerable<InfoAboutTheQuantityGoodsDeliveredGetDto> GetInfoAboutTheQuantityGoodsDelivered()
    {
        _logger.LogInformation("Get info about the quantity goods delivered.");
        var query = (from invoice in _context.Invoices
                     join invoiceContent in _context.InvoicesContent on invoice.Id equals invoiceContent.InvoiceId
                     join product in _context.Products on invoiceContent.ProductItemNumber equals product.ItemNumber
                     group invoiceContent by new
                     {
                         invoice.NameOrganization,
                         invoice.AdressOrganization,
                         product.ItemNumber,
                         product.Title
                     } into grp
                     select new InfoAboutTheQuantityGoodsDeliveredGetDto
                     {
                         NameOrganization = grp.Key.NameOrganization,
                         AdressOrganization = grp.Key.AdressOrganization,
                         ItemNumber = grp.Key.ItemNumber,
                         Title = grp.Key.Title,
                         Quantity = grp.Sum(x => x.Quantity)
                     }).ToList();
        return query;
    }
}
