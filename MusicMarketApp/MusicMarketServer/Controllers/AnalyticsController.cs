using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MusicMarket;
using MusicMarketServer.Dto;
using MusicMarketServer.Repository;

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
    /// Хранение репозитория
    /// </summary>
    private readonly IMusicMarketRepository _musicMarketRepository;

    /// <summary>
    /// Хранение маппера
    /// </summary>
    private readonly IMapper _mapper;
    public AnalyticsController(ILogger<AnalyticsController> logger, IMusicMarketRepository musicMarketRepository, IMapper mapper)
    {
        _logger = logger;
        _musicMarketRepository = musicMarketRepository;
        _mapper = mapper;
    }


    /// <summary>
    /// Запрос 1 - Вывести информацию о всех проданных виниловых пластинках.
    /// </summary>
    /// <returns></returns>
    [HttpGet("information_about_vinyl_records")]
    public ActionResult<ProductGetDto> GetSoldVinylRecords()
    {
        _logger.LogInformation("Get information about all sold vinyl records");

        var result = (from product in _musicMarketRepository.Products
                      where product.TypeOfCarrier == "vinyl record" && product.Status == "sold"
                      select _mapper.Map<Product, ProductGetDto>(product)).ToList();
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
    /// <returns></returns>
    [HttpGet("All_products_by_seller_id")]
    public ActionResult<ProductGetDto> ProductsBySeller(int id)
    {
        _logger.LogInformation("Get information about products with id", id);
        var products = (from product in _musicMarketRepository.Products
                        where product.Seller != null && product.SellerId == id
                        orderby product.Price
                        select _mapper.Map<Product, ProductGetDto>(product)).ToList();
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
    /// <returns></returns>
    [HttpGet("Good_disks_by_singer")]
    public ActionResult<ProductGetDto> GoodDisksInfo(string name)
    {
        _logger.LogInformation("Get good disks");
        var products = (from product in _musicMarketRepository.Products
                        where product.Creator != null && product.Creator == name && product.TypeOfCarrier == "disc" && product.Status == "sale"
                        && product.PublicationType == "album"
                        && (product.MediaStatus == "new" || product.MediaStatus == "excellent" || product.MediaStatus == "good")
                        orderby product.Price
                        select _mapper.Map<Product, ProductGetDto>(product)).ToList();
        if (products.Count == 0)
        {
            _logger.LogInformation($"Not found disks with creator {name} ");
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
    /// <returns></returns>
    [HttpGet("Sold_audio_carriers")]
    public ActionResult SoldAudioCarriers()
    {
        _logger.LogInformation("Get count of sold audio carriers each type");
        var result = (from product in _musicMarketRepository.Products
                      where (product.Status == "sold")
                      group product by product.TypeOfCarrier into carrierGroup
                      select new
                      {
                          carrier = carrierGroup.Key,
                          number = carrierGroup.Count()
                      }).ToList();
        return Ok(result);
    }

    /// <summary>
    /// Запрос 5 - Вывести информацию о топ 5 покупателях 
    /// по средней стоимости совершенных покупок с учетом стоимости доставки.
    /// </summary>
    /// <returns></returns>
    [HttpGet("Top_5_customers")]
    public IActionResult TopFiveСustomer()
    {
        _logger.LogInformation("Get top 5 customers");
        var customers = _musicMarketRepository.Customers;
        var purchases = _musicMarketRepository.Purchases;
        var products = _musicMarketRepository.Products;
        var sellers = _musicMarketRepository.Sellers;

        var customerPurchases =
            from customer in customers
            from purchase in customer.Purchases
            from product in purchase.Products
            select new
            {
                customer.Id,
                PurchaseCost = purchase.Products.Sum(product => product.Price + product.Seller?.Price)
            };
        var customerAvgPurchases =
            from customerPurchase in customerPurchases
            group customerPurchase by customerPurchase.Id into customer
            select new
            {
                customer.Key,
                AvgCost = customer.Average(cust => cust.PurchaseCost)
            };
        var result = customerAvgPurchases.OrderBy(customer => customer.AvgCost).Take(5).Reverse().ToList();

        if (result.Count == 0)
        {
            _logger.LogInformation("No information found");
            return NotFound();
        }
        else
        {
            return Ok(result);
        }
    }

    /// <summary>
    /// Запрос 6 - Вывести информацию о количестве проданных товаров каждым продавцом за последние две недели.
    /// </summary>
    /// <returns></returns>
    [HttpGet("sold_products")]
    public IActionResult SoldProductsInTwoWeeks()
    {
        _logger.LogInformation("Get information about sold products in two weeks");
        var now = DateTime.Now;


        var purchases = _musicMarketRepository.Purchases;

        var request = (from purchase in purchases
                       where purchase.Date >= now.AddDays(-14)
                       select new
                       {
                           seller = purchase.Products[0].Seller,
                           count = purchase.Products.Count
                       }).ToList();

        var selCount = (from sel in request
                        group sel by sel.seller.ShopName into g
                        select new
                        {
                            seller = g.Key,
                            count = g.Sum(x => x.count)
                        }).ToList();
        if (selCount.Count == 0)
        {
            _logger.LogInformation("No information found");
            return NotFound();
        }
        else
        {
            return Ok(selCount);
        }
    }
}