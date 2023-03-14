using System.Linq;
using Realtors;
namespace UnitTest;
public class realtortest:IClassFixture<RealtFixture>
{
    private readonly RealtFixture _fixture;
    public realtortest(RealtFixture fixture)
    {
        _fixture = fixture;
    }
    /// <summary>
    /// first request - information about all clients looking for real estate of a given type
    /// </summary>
public void AllClient()
{
    var HouseuninList = HouseFixture.ToList();
    var whobuyUnin = (from house in HousenonList where house.House.Type == "uninhabited" select house.Client.FirstName).ToList();
            Assert.Equal(HouseuninList[0].Client.FirstName,whobuyUnin[0]);

}
    /// <summary>
    /// second request - all sellers who left orders for a given period
    /// </summary>

    /// <summary>
    /// third request - information about sellers and real estate objects that correspond to a specific buyer's request
    /// </summary>

    /// <summary>
    /// fourth request - information about the number of applications for each type of property    /// </summary>

    /// <summary>
    /// fifth request - Display the top 5 clients by the number of applications
    /// </summary>

    /// <summary>
    /// sixth request - information about clients who opened orders with the minimum cost    
    /// </summary>

}
