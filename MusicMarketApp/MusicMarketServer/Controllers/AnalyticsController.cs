using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MusicMarket;
using MusicMarketServer.Dto;
using MusicMarketServer.Resository;

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
    /// <param name>product</param>
    /// <returns></returns>
    [HttpGet("information_aboout_vinyl_records")]
    public ActionResult<ProductGetDto> GetSoldVinylRecords()
    {
        _logger.LogInformation($"Get information aboout all sold vinyl records");

        var result = (from product in _musicMarketRepository.Products
                      where product.TypeOfCarrier == "vinyl record" && product.Status == "sold"
                      select _mapper.Map<Product, ProductGetDto>(product)).ToList();
        if (result.Count == 0)
        {
            _logger.LogInformation($"Not found sold vinyl records");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get information about sold vinyl records:", result.Count);
            return Ok(result);
        }
    }

    /// <summary>
    /// Запрос 2 - Вывести информацию о всех товарах указанного продавца, упорядочить по цене.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("All_seller's_products_by_id{id}")]
    public ActionResult<ProductGetDto> ProductsBySeller(int id)
    {
        _logger.LogInformation("Get information about products with id", id);
        var products = (from product in _musicMarketRepository.Products
                        where product.Seller != null && product.SellerId == id
                        orderby product.Price
                        select _mapper.Map<Product, ProductGetDto>(product)).ToList();
        if (products.Count == 0)
        {
            _logger.LogInformation($"Not found product with seller id: {0}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get information about structure of university");
            return Ok(products);
        }
    }

    /// <summary>
    /// Запрос 3 - Вывести информацию о продаваемых дисковых изданиях       
    /// альбомов указанного исполнителя, состояние аудионосителя и упаковки 
    /// которых не хуже "хорошее".
    /// </summary>
    /// <returns></returns>
    [HttpGet("Good+_disks_by_singer{name}")]
    public ActionResult<ProductGetDto> GoodDisksInfo(string name)
    {
        _logger.LogInformation("Get good+ disks");
        var products = (from product in _musicMarketRepository.Products
                        where product.Creator != null && product.Creator == name && product.TypeOfCarrier == "disc" && product.Status == "sale"
                        && product.PublicationType == "album"
                        && (product.MediaStatus == "new" || product.MediaStatus == "excellent" || product.MediaStatus == "good")
                        orderby product.Price
                        select _mapper.Map<Product, ProductGetDto>(product)).ToList();
        if (products.Count == 0)
        {
            _logger.LogInformation($"Not found disks with creator ", name);
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get information about found disks");
            return Ok(products);
        }
    }
}
///// <summary>
///// Запрос 4 - Вывести информацию о ВУЗах с максимальным количеством кафедр, упорядочить по названию.
///// </summary>
///// <returns></returns>
//[HttpGet("university_with_max_departments")]
//public IEnumerable<UniversityGetDto> MaxCountDepartments()
//{
//    _logger.LogInformation("Get universities with max count departments");
//    return (from university in _universityDataRepository.Universities
//            where university.DepartmentsData.Count == _universityDataRepository.Universities.Max(element => element.DepartmentsData.Count)
//            select _mapper.Map<University, UniversityGetDto>(university)).ToList();
//}

///// <summary>
///// Четветый запрос: Вывести информацию о количестве проданных на торговой площадке
///// товаров каждого типа аудионосителя.
///// </summary>

//[Fact]
//public void AidioCarriersInfo()
//{
//    var fixtureProduct = _fixture.FixtureProducts.ToList();
//    // диски,
//    var request0 = (from product in fixtureProduct
//                    where (product.TypeOfCarrier == "disc") && (product.Status == "sold")
//                    select product).Count();
//    // кассеты,
//    var request1 = (from product in fixtureProduct
//                    where (product.TypeOfCarrier == "cassette") && (product.Status == "sold")
//                    select product).Count();
//    // виниловые пластинки.
//    var request2 = (from product in fixtureProduct
//                    where (product.TypeOfCarrier == "vinyl record") && (product.Status == "sold")
//                    select product).Count();

//    Assert.Equal(2, request0);
//    Assert.Equal(2, request1);
//    Assert.Equal(2, request2);
//}

///// <summary>
///// Запрос 5 - Вывести информацию о ВУЗах с заданной собственностью учреждения, и количество групп в ВУЗе.
///// </summary>
///// <param name="universityProperty"></param>
///// <returns></returns>
//[HttpGet("university_with_target_property")]
//public IEnumerable<object> UniversityWithProperty(string universityProperty)
//{
//    _logger.LogInformation("Get information about universities with target property");
//    return (from university in _universityDataRepository.Universities
//            where (university.UniversityProperty == universityProperty)
//            select new
//            {
//                university.Id,
//                university.Name,
//                university.Number,
//                university.RectorId,
//                university.ConstructionProperty,
//                university.UniversityProperty,
//                count = university.SpecialtyTable.Sum(specialtyNode => specialtyNode.CountGroups)
//            }).ToList();
//}

///// <summary>
///// Пятый запрос: Вывести информацию о топ 5 покупателях 
///// по средней стоимости совершенных покупок с учетом стоимости доставки.
///// </summary>
//[Fact]
//public void TopFiveTest()
//{
//    var customers = _fixture.FixtureCustomers.ToList();
//    var purchases = _fixture.FixturePurchases.ToList();
//    var products = _fixture.FixtureProducts.ToList();
//    var sellers = _fixture.FixtureSellers.ToList();

//    var customerPurchases =
//        from customer in customers
//        from purchase in customer.Purchases
//        from product in purchase.Products
//        select new
//        {
//            customer.Id,
//            PurchaseCost = purchase.Products.Sum(product => product.Price + product.Seller?.Price)
//        };
//    var customerAvgPurchases =
//        from customerPurchase in customerPurchases
//        group customerPurchase by customerPurchase.Id into customer
//        select new
//        {
//            customer.Key,
//            AvgCost = customer.Average(cust => cust.PurchaseCost)
//        };
//    var top5 = customerAvgPurchases.OrderBy(customer => customer.AvgCost).Take(5);
//    var max = top5.Max(a => a.AvgCost);
//    Assert.Equal(7240, max);


//      return (from specialtyNode in _universityDataRepository.SpecialtyTableNodes
//                group specialtyNode by specialtyNode.Specialty.Code into specialtyGroup
//                orderby specialtyGroup.Count() descending
//                select new
//                {
//                    Specialty = specialtyGroup.Key,
//                    numRequests = specialtyGroup.Count()
//}).Take(5).ToList();
//}

///// <summary>
///// Запрос 6 - Вывести информацию о количестве факультетов, кафедр, специальностей по каждому типу собственности учреждения и собственности здания.
///// </summary>
///// <returns></returns>
//[HttpGet("count_departments")]
//public IEnumerable<object> CountDepartments()
//{
//    _logger.LogInformation("Get counts of faculty, departments and specialties");
//    return (from university in _universityDataRepository.Universities
//            group university by university.ConstructionProperty into universityConstGroup
//            from universityPropGroup in
//            (
//                from university in universityConstGroup
//                group university by university.UniversityProperty into universityPropGroup
//                select new
//                {
//                    UnivesityProp = universityPropGroup.Key
//                }
//            )
//            select new
//            {
//                ConstProp = universityConstGroup.Key,
//                UniversityProp = universityPropGroup.UnivesityProp,
//                Faculties = universityConstGroup.Sum(university => university.FacultiesData.Count),
//                Departments = universityConstGroup.Sum(university => university.DepartmentsData.Count),
//                Specialities = universityConstGroup.Sum(university => university.SpecialtyTable.Count)
//            }).ToList();
//}
///// <summary>
///// Шестой запрос: Вывести информацию о количестве проданных товаров каждым продавцом 
///// за последние две недели.
///// </summary>
//public void SoldProducsInTwoWeeks()
//{
//    var now = DateTime.Now;


//    var purchases = _fixture.FixturePurchases.ToList();

//    var request = (from purchase in purchases
//                   where purchase.Date >= now.AddDays(-14)
//                   select new
//                   {
//                       seller = purchase.Products[0].Seller,
//                       count = purchase.Products.Count
//                   }).ToList();

//    var selCount = (from sel in request
//                    group sel by sel.seller.ShopName into g
//                    select new
//                    {
//                        seller = g.Key,
//                        count = g.Sum(x => x.count)
//                    }).ToList();

//    Assert.Equal(1, selCount[0].count);
//    Assert.Equal(1, selCount[1].count);
//}
//}
