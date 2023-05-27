using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace NonResidentialFund.Client;
public class ApiWrapper
{
    private readonly ApiClient _client;
    public ApiWrapper()
    {
        var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json").Build();
        var serverUrl = configuration.GetSection("ServerUrl").Value;
        _client = new ApiClient(serverUrl, new HttpClient());
    }
    
    public Task<ICollection<BuildingGetDto>> GetBuildingsAsync()
    {
        return _client.BuildingAllAsync();
    }
    public Task<BuildingGetDto> GetBuildingAsync(int id)
    {
        return _client.Building2Async(id);
    }

    public Task<BuildingGetDto> AddBuildingAsync(BuildingPostDto building)
    {
        return _client.BuildingAsync(building);
    }

    public Task<BuildingGetDto> UpdateBuildingAsync(int id, BuildingPostDto building)
    {
        return _client.Building3Async(id, building);
    }
    public Task DeleteBuildingAsync(int id)
    {
        return _client.Building4Async(id);
    }

    public Task<ICollection<BuyerGetDto>> GetBuyersAsync()
    {
        return _client.BuyerAllAsync();
    }
    public Task<BuyerGetDto> GetBuyerAsync(int id)
    {
        return _client.Buyer2Async(id);
    }

    public Task<BuyerGetDto> AddBuyerAsync(BuyerPostDto buyer)
    {
        return _client.BuyerAsync(buyer);
    }

    public Task<BuyerGetDto> UpdateBuyerAsync(int id, BuyerPostDto buyer)
    {
        return _client.Buyer3Async(id, buyer);
    }
    public Task DeleteBuyerAsync(int id)
    {
        return _client.Buyer4Async(id);
    }

    public Task<ICollection<OrganizationGetDto>> GetOrganizationsAsync()
    {
        return _client.OrganizationAllAsync();
    }

    public Task<OrganizationGetDto> GetOrganizationAsync(int id)
    {
        return _client.Organization2Async(id);
    }

    public Task<OrganizationGetDto> AddOrganizationAsync(OrganizationPostDto organization)
    {
        return _client.OrganizationAsync(organization);
    }

    public Task<OrganizationGetDto> UpdateOrganizationAsync(int id, OrganizationPostDto organization)
    {
        return _client.Organization3Async(id, organization);
    }
    public Task DeleteOrganizationAsync(int id)
    {
        return _client.Organization4Async(id);
    }

    public Task<ICollection<AuctionGetDto>> GetAuctionsAsync()
    {
        return _client.AuctionAllAsync();
    }

    public Task<AuctionGetDto> GetAuctionAsync(int id)
    {
        return _client.Auction2Async(id);
    }

    public Task<AuctionGetDto> AddAuctionAsync(AuctionPostDto auction)
    {
        return _client.AuctionAsync(auction);
    }

    public Task<AuctionGetDto> UpdateAuctionAsync(int id, AuctionPostDto auction)
    {
        return _client.Auction3Async(id, auction);
    }
    public Task DeleteAuctionAsync(int id)
    {
        return _client.Auction4Async(id);
    }
    public Task<ICollection<DistrictGetDto>> GetDistrictsAsync()
    {
        return _client.DistrictAllAsync();
    }

    public Task<DistrictGetDto> GetDistrictAsync(int id)
    {
        return _client.District2Async(id);
    }

    public Task<DistrictGetDto> AddDistrictAsync(DistrictPostDto district)
    {
        return _client.DistrictAsync(district);
    }

    public Task<DistrictGetDto> UpdateDistrictAsync(int id, DistrictPostDto district)
    {
        return _client.District3Async(id, district);
    }
    public Task DeleteDistrictAsync(int id)
    {
        return _client.District4Async(id);
    }
    public Task<ICollection<PrivatizedGetDto>> GetPrivatizedAllAsync()
    {
        return _client.PrivatizedAllAsync();
    }

    public Task<PrivatizedGetDto> GetPrivatizedAsync(int id)
    {
        return _client.Privatized2Async(id);
    }

    public Task<PrivatizedGetDto> AddPrivatizedAsync(PrivatizedPostDto privatized)
    {
        return _client.PrivatizedAsync(privatized);
    }

    public Task<PrivatizedGetDto> UpdatePrivatizedAsync(int id, PrivatizedPostDto privatized)
    {
        return _client.Privatized3Async(id, privatized);
    }
    public Task DeletePrivatizedAsync(int id)
    {
        return _client.Privatized4Async(id);
    }

    public Task<ICollection<AuctionGetDto>> GetAuctionsNotAllLotsSoldAsync()
    {
        return _client.GetAuctionsNotAllLotsSoldAsync();
    }

    public Task<ICollection<BuyerGetDto>> GetBuyersInSpecifiedDistrictAsync(int id)
    {
        return _client.GetBuyersInSpecifiedDistrictAsync(id);
    }

    public Task<ICollection<BuyerAddressDto>> GetAddressesOfAuctionParticipantsInSpecifiedDateAsync(DateTime date)
    {
        return _client.GetAddressesOfAuctionParticipantsInSpecifiedDateAsync(date);
    }

    public Task<ICollection<BuyerExpensesDto>> GetTopBuyersByExpensesAsync()
    {
        return _client.GetTopBuyersByExpensesAsync();
    }

    public Task<ICollection<AuctionIncomeDto>> GetAuctionsWithHighestIncomeAsync()
    {
        return _client.GetAuctionsWithHighestIncomeAsync();
    }
}
