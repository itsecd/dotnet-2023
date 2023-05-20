using EnterpriseWarehouseServer.Dto;
using EnterpriseWarehouseServer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseWarehouseServer.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AnalyticsController : ControllerBase
{
    private readonly ILogger<AnalyticsController> _logger;

    private readonly IMainRepository _mainRepository;
    public AnalyticsController(ILogger<AnalyticsController> logger, IMainRepository mainRepository)
    {
        _logger = logger;
        _mainRepository = mainRepository;
    }

    /// <summary>
    ///     [HttpGet("GetAllProductSortebByTitle")] - return information about the company's products, sorted by product name(Title)
    /// <return>List of Produc</return>
    /// </summary>
    [HttpGet("GetAllProductSortebByTitle")]
    public IEnumerable<ProductGetDto> GetAllProductSortebByTitle()
    {
        _logger.LogInformation("Get all product sorteb by title.");
        return _mainRepository.Products.Select(product =>
            new ProductGetDto
            {
                ItemNumber = product.ItemNumber,
                Title = product.Title,
                Quantity = product.Quantity,
                CellNumber = product.CellNumber
            }
        ).OrderBy(_mainRepository => _mainRepository.Title);
    }

    /// <summary>
    ///     [HttpGet("GetInformationProductReceivedOnCertainDay")] - return information about the company's products received on the specified day by the recipient of products
    /// <return>List of Produc</return>
    /// </summary>
    [HttpGet("GetInformationProductReceivedOnCertainDay/{date_str}")]
    public IEnumerable<ProductGetDto> GetInformationProductReceivedOnCertainDay(DateTime date)
    {
        _logger.LogInformation("Get information product received on certain day.");
        var query = (from invoice in _mainRepository.Invoices
                     from infoProduct in invoice.Products
                     where invoice.ShipmentDate == date.Date
                     join product in _mainRepository.Products on infoProduct.Key equals product.ItemNumber
                     select new ProductGetDto
                     {
                         ItemNumber = product.ItemNumber,
                         Title = product.Title,
                         Quantity = product.Quantity,
                         CellNumber = product.CellNumber
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
        var query = (from warehouse in _mainRepository.StorageCell
                     join product in _mainRepository.Products on warehouse.ItemNumberProducts equals product.ItemNumber
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
    public InfoOfAllInvoiceGetDto GetInfoOrganizationsReceivedMaxVolumeProductsForGivenPeriod(DateTime date_begin, DateTime date_end)
    {
        _logger.LogInformation("Get info organizations received max volume products for given period.");
        var query = (from invoice in _mainRepository.Invoices
                     from product in invoice.Products
                     where invoice.ShipmentDate > date_begin.Date && invoice.ShipmentDate < date_end.Date
                     group invoice by new
                     {
                         invoice.NameOrganization,
                         invoice.AdressOrganization
                     } into grp
                     select new InfoOfAllInvoiceGetDto
                     {
                         NameOrganization = grp.Key.NameOrganization,
                         AdressOrganization = grp.Key.AdressOrganization,
                         Quantity = grp.Sum(x => x.Products.Sum(x => x.Value))
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
        var query = (from product in _mainRepository.Products
                     orderby product.Quantity descending
                     select new ProductGetDto
                     {
                         ItemNumber = product.ItemNumber,
                         Title = product.Title,
                         Quantity = product.Quantity,
                         CellNumber = product.CellNumber,
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
        var query = (from invoice in _mainRepository.Invoices
                     from listProduct in invoice.Products
                     join product in _mainRepository.Products on listProduct.Key equals product.ItemNumber
                     group invoice by new
                     {
                         invoice.NameOrganization,
                         invoice.AdressOrganization,
                         listProduct.Key,
                         product.Title
                     } into grp
                     select new InfoAboutTheQuantityGoodsDeliveredGetDto
                     {
                         NameOrganization = grp.Key.NameOrganization,
                         AdressOrganization = grp.Key.AdressOrganization,
                         ItemNumber = grp.Key.Key,
                         Title = grp.Key.Title,
                         Quantity = grp.Sum(x => x.Products.Sum(x => x.Value))
                     }).ToList();
        return query;
    }
}
