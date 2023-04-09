using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shops.Server.Dto;
using Shops.Server.Repository;
using Shops.Domain;

/// <summary>
/// Analytics controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AnalyticsController: ControllerBase
{
    private readonly ILogger<AnalyticsController> _logger;
    private readonly IShopRepository _shopRepository;
    private readonly IMapper _mapper;
    /// <summary>
    /// Controller constructor 
    /// </summary>
    public AnalyticsController(ILogger<AnalyticsController> logger, IShopRepository shopRepository, IMapper mapper)
    {
        _logger = logger;
        _shopRepository = shopRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// Display information about all products in a given shop.
    /// </summary>
    /// <param name="id"> Id of shop.</param>
    /// <returns>Ok(information about all products in shop by id)</returns>
    [HttpGet("information-product-in-shop")]
    public ActionResult Get(int id)
    {
        var found_Shop = _shopRepository.Shops.FirstOrDefault(f_shop => f_shop.Id == id);
        if (found_Shop == null)
            return NotFound();
        _logger.LogInformation("Get list of products in shop");
        var fixtureShop = _shopRepository.Shops;
        var query =
            (from shop in fixtureShop
             where shop.Id == id
             select shop.Products).ToList()[0];
        if (query.Count == 0)
        {
            return NotFound();
        }
        else 
        {
            var result = _mapper.Map<IEnumerable<ProductQuantity>, IEnumerable<ProductQuantityGetDto>>(query);
            return Ok(result);
        }

    }
    /// <summary>
    /// For a given product, display a list of stores in which it is available.
    /// </summary>
    /// <param name="id"> Id of product.</param>
    /// <returns>Ok(information about all products in shop by id)</returns>
    [HttpGet("shops-with-product")]
    public ActionResult GetProductAvailable(int id)
    {
        var found_Product = _shopRepository.Products.FirstOrDefault(f_product => f_product.Id == id);
        if (found_Product == null)
            return NotFound();
        _logger.LogInformation("Get list of shop with product");
        var fixtureShop = _shopRepository.Shops;
        var query =
            (from shop in fixtureShop
             from products in shop.Products
             where products.ProductId == id
             select shop).ToList();
        if (query.Count == 0)
        {
            return NotFound();
        }
        var result = _mapper.Map<IEnumerable<Shop>, IEnumerable<ShopGetDto>>(query);
        return Ok(result);
    }
    /// <summary>
    /// Output information about the average cost of goods of each product group for each store
    /// </summary>
    /// <returns>Ok(information about the average cost products groups in shops)</returns>
    [HttpGet("average-price-product-groups")]
    public ActionResult GetAvgPriceProductGroup()
    {
        _logger.LogInformation("Get list of avg price ");
        var fixtureShop = _shopRepository.Shops;
        var productList = _shopRepository.Products;
        var productInShop =
            (from shop in fixtureShop
             from products in shop.Products
             select products).ToList();

        var result =
            (from ps in productInShop
             join p in productList on ps.ProductId equals p.Id
             join s in fixtureShop on ps.ShopId equals s.Id
             group new { p, s } by new { p.ProductGroupCode, s.Id } into grp
             select new
             {
                 ShopId = grp.Key.Id,
                 PoductGroup = grp.Key.ProductGroupCode,
                 AvgPrice = grp.Average(x => x.p.Price)
             }
            ).ToList();
        return Ok(result);
    }
    /// <summary>
    /// Output the top 5 purchases by the total amount of the sale.
    /// </summary>
    /// <returns>Ok(information about top 5 purchases by the total amount of the sale)</returns>
    [HttpGet("top-5-purchases")]
    public ActionResult GetTop5Purchases()
    {
        _logger.LogInformation("Get list of top 5 purchases");
        var customer = _shopRepository.Customers;
        var fixtureShop = _shopRepository.Shops;
        var topPurch =
            (from shop in fixtureShop
             from pr in shop.PurchaseRecords
             orderby pr.Sum descending
             select pr
            ).Take(5).ToList();
        var result = _mapper.Map<IEnumerable<PurchaseRecord>, IEnumerable<PurchaseRecordGetDto>>(topPurch);

        return Ok(result);
    }
    /// <summary>
    /// Display all information about goods exceeding the storage limit date,indicating the store.
    /// </summary>
    /// <returns>Ok(information about goods exceeding the storage limit date)</returns>
    [HttpGet("product-delay")]
    public ActionResult GetProductDelay()
    {
        _logger.LogInformation("Get list of product delay");
        var fixtureShop = _shopRepository.Shops;
        var productList = _shopRepository.Products;
        var productInShop =
            (from shop in fixtureShop
             from products in shop.Products
             select products).ToList();
        var expiredProduct =
            (from ps in productInShop
             join p in productList on ps.ProductId equals p.Id
             join s in fixtureShop on ps.ShopId equals s.Id
             where p.StorageLimitDate < DateTime.Now
             select new
             {
                 ShopId = s.Id,
                 ProductId = p.Id,
                 StorageLimitDate = p.StorageLimitDate,
             }
            ).ToList();
        return Ok(expiredProduct);
    }
    /// <summary>
    /// Display a list of stores in which goods were sold for a month in excess of the specified amount.
    /// </summary>
    /// <param name="amount">Specified amount.</param>
    /// <param name="beginDate">The number from which the month is counted.</param>
    /// <returns>Ok(stores in which goods were sold for a month in excess of the specified amount)</returns>
    [HttpGet("shop-earned-more")]
    public ActionResult GetShopEarnedMore(double amount, DateTime beginDate)
    {
        _logger.LogInformation("Get list of stores in which goods were sold for a month in excess of the specified amount");
        var fixtureShop = _shopRepository.Shops;
        var purchases =
           (from shop in fixtureShop
            from pr in shop.PurchaseRecords
            select new
            {
                Shop = shop,
                DateSale = pr.DateSale,
                Sale = pr.Sum
            }
            ).ToList();
        var result =
           (from purchase in purchases
            where purchase.DateSale >= beginDate && purchase.DateSale <= beginDate.AddMonths(1)
            group purchase by purchase.Shop into sgrp
            select new
            {
                ShopId = sgrp.Key.Id,
                SumSale = sgrp.Sum(purchase => purchase.Sale)
            } into shopSales
            where shopSales.SumSale >= amount
            select new
            {
                ShopId = shopSales.ShopId,
                SumSale = shopSales.SumSale,
            }
            ).ToList();

        return Ok(result);
    }

}
