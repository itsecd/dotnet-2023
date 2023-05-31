namespace TestProject;
public class UnitTest : IClassFixture<FixtureRealt>
{
    private readonly FixtureRealt _fixture;
    public UnitTest(FixtureRealt fixture)
    {
        _fixture = fixture;
    }
    /// <summary>
    /// first request - information about all clients looking for real estate of a given type
    /// </summary>
    [Fact]
    public void AllClients()
    {

        var resultList = (from clients in _fixture.Clients
                          join applications in _fixture.Applications on clients.Id equals applications.ClientId
                          join connect in _fixture.ApplicationHasHouses on applications.Id equals connect.ApplicationId
                          join house in _fixture.Houses on connect.HouseId equals house.Id
                          where applications.Type == "Purchase" && house.Type == "Uninhabited"
                          group clients by new
                          {
                              clients.Surname,
                              clients.Name,
                              clients.Number,
                              clients.Registration,
                              clients.Passport
                          } into grp
                          select new
                          {
                              grp.Key.Surname,
                              grp.Key.Name,
                              grp.Key.Number,
                              grp.Key.Registration,
                              grp.Key.Passport
                          }).ToList(); ;
        Assert.Equal(3, resultList.Count);
        Assert.Equal("Gorshnev", resultList[0].Surname);
        Assert.Equal("Michael", resultList[0].Name);
        Assert.Equal("Aerodromnaya, 47a", resultList[0].Registration);
        Assert.Equal("880-05-55", resultList[0].Number);
        Assert.Equal("91245", resultList[0].Passport);
        Assert.Equal("Paramonov", resultList[1].Surname);
        Assert.Equal("Ilya", resultList[1].Name);
        Assert.Equal("Galaktionovskaya, 40", resultList[1].Registration);
        Assert.Equal("341-21-09", resultList[1].Number);
        Assert.Equal("21415", resultList[1].Passport);
        Assert.Equal("Shnirov", resultList[2].Surname);
        Assert.Equal("Sergey", resultList[2].Name);
        Assert.Equal("Krasnoarmeyskaya, 1a", resultList[2].Registration);
        Assert.Equal("336-64-36", resultList[2].Number);
        Assert.Equal("32218", resultList[2].Passport);
    }
    /// <summary>
    /// second request - all sellers who left orders for a given period
    /// </summary>
    [Fact]
    public void ApplicationsForThePeriod()
    {
        var query = (from clients in _fixture.Clients
                     join applications in _fixture.Applications on clients.Id equals applications.ClientId
                     where applications.Data < new DateTime(2023, 02, 01) && applications.Data > new DateTime(1234, 01, 01) && applications.Type == "Sale"
                     group clients by new
                     {
                         clients.Surname,
                         clients.Name,
                         clients.Number,
                         clients.Registration,
                         clients.Passport
                     } into grp
                     select new
                     {
                         grp.Key.Surname,
                         grp.Key.Name,
                         grp.Key.Number,
                         grp.Key.Registration,
                         grp.Key.Passport
                     }).ToList();
        Assert.Single(query);
        Assert.Equal("King", query[0].Surname);
        Assert.Equal("Stiven", query[0].Name);
        Assert.Equal("Lesnaya, 23", query[0].Registration);
        Assert.Equal("964-98-70", query[0].Number);
        Assert.Equal("57504", query[0].Passport);
    }
    /// <summary>
    /// third request - information about sellers and real estate objects that correspond to a specific buyer's request
    /// </summary>
    [Fact]
    public void BuyerRequest()
    {
        var query = (from clients in _fixture.Clients
                     join applications in _fixture.Applications on clients.Id equals applications.ClientId
                     join connect in _fixture.ApplicationHasHouses on applications.Id equals connect.ApplicationId
                     join house in _fixture.Houses on connect.HouseId equals house.Id
                     where applications.Type == "Sale" && applications.Cost == 1
                     select new
                     {
                         clients.Surname,
                         clients.Name,
                         clients.Number,
                         clients.Registration,
                         clients.Passport,
                         house.Square,
                         house.Type,
                         house.Rooms,
                         house.Address
                     }).ToList();
        Assert.Single(query);
        Assert.Equal("King", query[0].Surname);
        Assert.Equal("Stiven", query[0].Name);
        Assert.Equal("Lesnaya, 23", query[0].Registration);
        Assert.Equal("964-98-70", query[0].Number);
        Assert.Equal("57504", query[0].Passport);
        Assert.Equal(2, query[0].Rooms);
        Assert.Equal("Lesnaya, 23", query[0].Address);
        Assert.Equal(45, query[0].Square);
        Assert.Equal("Uninhabited", query[0].Type);
    }
    /// <summary>
    /// fourth request - information about the number of applications for each type of property    
    /// </summary>
    [Fact]
    public void QuantityHousesOfOneType()
    {
        var query1 = (from applications in _fixture.Applications
                      join connect in _fixture.ApplicationHasHouses on applications.Id equals connect.ApplicationId
                      join house in _fixture.Houses on connect.HouseId equals house.Id
                      where house.Type == "Uninhabited"
                      select applications).Count();
        var query2 = (from applications in _fixture.Applications
                      join connect in _fixture.ApplicationHasHouses on applications.Id equals connect.ApplicationId
                      join house in _fixture.Houses on connect.HouseId equals house.Id
                      where house.Type == "Residential"
                      select applications).Count();
        Assert.Equal(5, query1);
        Assert.Equal(2, query2);
    }
    /// <summary>
    /// fifth request - Display the top 5 clients by the number of applications
    /// </summary>
    [Fact]
    public void TopFive()
    {
        var query1 = (from clien in _fixture.Clients
                      join applications in _fixture.Applications on clien.Id equals applications.ClientId
                      where applications.Type == "Purchase"
                      group clien by new
                      {
                          clien.Surname,
                          clien.Name,
                          clien.Applications.Count
                      } into grp
                      select new
                      {
                          grp.Key.Surname,
                          grp.Key.Name,
                          grp.Key.Count
                      }).ToList();
        var result = (from client in query1
                      orderby query1.Count descending
                      select client).Take(5).ToList();
        Assert.Equal(4, result.Count());
        Assert.Equal(1, result[0].Count);
        Assert.Equal("Gorshnev", result[0].Surname);
        Assert.Equal("Terrible", result[3].Surname);
        var query2 = (from clien in _fixture.Clients
                      join applications in _fixture.Applications on clien.Id equals applications.ClientId
                      where applications.Type == "Sale"
                      group clien by new
                      {
                          clien.Surname,
                          clien.Name,
                          clien.Applications.Count
                      } into grp
                      select new
                      {
                          grp.Key.Surname,
                          grp.Key.Name,
                          grp.Key.Count
                      }).ToList();
        var result2 = (from client in query2
                       orderby query2.Count descending
                       select client).Take(5).ToList();
        Assert.Single(result2);
        Assert.Equal(1, result2[0].Count);
        Assert.Equal("King", result2[0].Surname);
    }
    /// <summary>
    /// sixth request - information about clients who opened orders with the minimum cost    
    /// </summary>
    [Fact]
    public void MinimumCost()
    {
        var query = (from clients in _fixture.Clients
                     join applications in _fixture.Applications on clients.Id equals applications.ClientId
                     group clients by new
                     {
                         clients.Surname,
                         clients.Name,
                         clients.Number,
                         clients.Registration,
                         clients.Passport,
                         applications.Cost
                     } into grp
                     select new
                     {
                         grp.Key.Surname,
                         grp.Key.Name,
                         grp.Key.Number,
                         grp.Key.Registration,
                         grp.Key.Passport,
                         grp.Key.Cost
                     }).ToList();
        var min = query.Min(x => x.Cost);
        foreach (var q in query)
        {
            if (q.Cost == min)
            {
                Assert.Equal("Stiven", q.Name);
                Assert.Equal("King", q.Surname);
                Assert.Equal("Lesnaya, 23", q.Registration);
                Assert.Equal("964-98-70", q.Number);
                Assert.Equal("57504", q.Passport);
                Assert.Equal(1, (int)q.Cost);
            }
        }
    }
}
