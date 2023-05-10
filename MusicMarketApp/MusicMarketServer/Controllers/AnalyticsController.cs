using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MusicMarket;
using MusicMarketServer.Dto;

using Microsoft.EntityFrameworkCore;
using MusicMarketplace;

namespace MusicMarketServer.Controllers;

/// <summary>
/// Контроллер запросов
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AnalyticsController : ControllerBase
{
    /// <summary>
    /// Хранение логгера
    /// </summary>
    private readonly ILogger<AnalyticsController> _logger;

    /// <summary>
    /// Хранение DbContext
    /// </summary>
    private readonly IDbContextFactory<MusicMarketDbContext> _contextFactory;

    /// <summary>
    /// Хранение маппера
    /// </summary>
    private readonly IMapper _mapper;

    /// <summary>
    /// AnlyticsController конструктор
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="contextFactory"></param>
    /// <param name="mapper"></param>
    public AnalyticsController(ILogger<AnalyticsController> logger, IDbContextFactory<MusicMarketDbContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }


    /// <summary>
    /// Запрос 1 - Вывести информацию о всех проданных виниловых пластинках.
    /// </summary>
    /// <returns>Ok(information about all sold vinyl records)</returns>
    [HttpGet("information_about_vinyl_records")]
    public async Task<ActionResult<ProductGetDto>> GetSoldVinylRecords()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get information about all sold vinyl records");

        var result = await (from product in context.Products
                            where product.TypeOfCarrier == "vinyl record" && product.Status == "sold"
                      select _mapper.Map<Product, ProductGetDto>(product)).ToListAsync();
        if (result.Count == 0)
        {
            _logger.LogInformation("Not found sold vinyl records");
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get information about sold vinyl records:", result.Count);
            return Ok(result);
        }
    }

    /// <summary>
    /// Запрос 2 - Вывести информацию о всех товарах указанного продавца, упорядочить по цене.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Ok(information about products by seller  with id)</returns>
    [HttpGet("All_products_by_seller_id")]
    public async Task<ActionResult<ProductGetDto>> ProductsBySeller(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation($"Get information about products with seller id {id}");
        var products = await (from product in context.Products
                        where product.IdSeller == id
                        orderby product.Price
                        select _mapper.Map<Product, ProductGetDto>(product)).ToListAsync();
        if (products.Count == 0)
        {
            _logger.LogInformation("Not found product");
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get information about products");
            return Ok(products);
        }
    }

    /// <summary>
    /// Запрос 3 - Вывести информацию о продаваемых дисковых изданиях       
    /// альбомов указанного исполнителя, состояние аудионосителя и упаковки 
    /// которых не хуже "хорошее".
    /// </summary>
    /// <returns>Ok(Information about sale good and better disks)</returns>
    [HttpGet("Good_disks_by_singer")]
    public async Task<ActionResult<ProductGetDto>> GoodDisksInfo(string name)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get good disks");
        var products = await (from product in context.Products
                        where product.Creator != null && product.Creator == name && product.TypeOfCarrier == "disc" && product.Status == "sale"
                        && product.PublicationType == "album"
                        && (product.MediaStatus == "new" || product.MediaStatus == "excellent" || product.MediaStatus == "good")
                        orderby product.Price
                        select _mapper.Map<Product, ProductGetDto>(product)).ToListAsync();
        if (products.Count == 0)
        {
            _logger.LogInformation("Not found disks with this creator");
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get information about found disks");
            return Ok(products);
        }
    }

    /// <summary>
    /// Запрос 4 - Вывести информацию о количестве проданных на торговой площадке товаров каждого типа аудионосителя.
    /// </summary>
    /// <returns>Ok(Count of sold audio carriers each type)</returns>
    [HttpGet("Sold_audio_carriers")]
    public async Task<ActionResult> SoldAudioCarriers()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get count of sold audio carriers each type");
        var result = await (from product in context.Products
                      where (product.Status == "sold")
                      group product by product.TypeOfCarrier into carrierGroup
                      select new
                      {
                          carrier = carrierGroup.Key,
                          number = carrierGroup.Count()
                      }).ToListAsync();
        return Ok(result);
    }

    /// <summary>
    /// Запрос 5 - Вывести информацию о топ 5 покупателях 
    /// по средней стоимости совершенных покупок с учетом стоимости доставки.
    /// </summary>
    /// <returns>Top 5 customers</returns>
    //[HttpGet("Top_5_customers")]
    //public async Task<IActionResult> TopFiveСustomer()
    //{
    //    await using var context = await _contextFactory.CreateDbContextAsync();
    //    _logger.LogInformation("Get top 5 customers");
    //    var customers = context.Customers;
    //    var purchases = context.Purchases;
    //    var products = context.Products;
    //    var sellers = context.Sellers;

    //    var customerPurchases =
    //        from customer in customers
    //        from purchase in customer.Purchases
    //        //from product in purchase.IdProduct
    //        select new
    //        {
    //            customer.Id,
    //            PurchaseCost = purchase.IdProduct.Sum(product => product.Price + product.Seller?.Price)
    //        };
    //    var customerAvgPurchases = 
    //        from customerPurchase in customerPurchases
    //        group customerPurchase by customerPurchase.Id into customer
    //        select new
    //        {
    //            customer.Key,
    //            AvgCost = customer.Average(cust => cust.PurchaseCost)
    //        };
    //   var result = await customerAvgPurchases.OrderBy(customer => customer.AvgCost).Take(5).Reverse().ToListAsync();

    //    if (result.Count == 0)
    //    {
    //        _logger.LogInformation("No information found");
    //        return NotFound();
    //    }
    //    else
    //    {
    //        return Ok(result);
    //    }
    //}

    /// <summary>
    /// Запрос 6 - Вывести информацию о количестве проданных товаров каждым продавцом за последние две недели.
    /// </summary>
    /// <returns> Information about sold products in two weeks</returns>
    //[HttpGet("sold_products")]
    //public async Task<IActionResult> SoldProductsInTwoWeeks()
    //{
    //    await using var context = await _contextFactory.CreateDbContextAsync();
    //    _logger.LogInformation("Get information about sold products in two weeks");
    //    var now = DateTime.Now;

    //    var purchases = context.Purchases;
    //    var products = context.Products;

    //    var request = await (from purchase in purchases
    //                   where purchase.Date >= now.AddDays(-14)
    //                   select new
    //                   {
    //                       seller = purchase.IdProducts[0].Seller,
    //                       count = purchase.Products.Count
    //                   }).ToListAsync();

    //    var selCount = await (from sel in request group sel by sel.seller.ShopName into g select new { seller = g.Key, count = g.Sum(x => x.count) }).ToListAsync();
        
    //    if (selCount.Count == 0)
    //    {
    //        _logger.LogInformation("No information found");
    //        return NotFound();
    //    }
    //    else
    //    {
    //        return Ok(selCount);
    //    }
    //}
}