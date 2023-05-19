using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace RentalService.Client;

public class ApiWrapper
{
    private readonly ApiClient _client;

    public ApiWrapper()
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        var serverUrl = configuration.GetSection("ServerUrl").Value;
        _client = new ApiClient(serverUrl, new HttpClient());
    }

    public async Task<ICollection<ClientGetDto>> GetClientsAsync()
    {
        return await _client.ClientAllAsync();
    }

    public async Task<ClientGetDto> AddClientsAsync(ClientPostDto client)
    {
        return await _client.ClientPOSTAsync(client);
    }

    public async Task UpdateClientsAsync(long id, ClientPostDto client)
    {
        await _client.ClientPUTAsync(id, client);
    }

    public async Task DeleteClientsAsync(long id)
    {
        await _client.ClientDELETEAsync(id);
    }

    public async Task<ICollection<IssuedCar>> GetIssuedCarsAsync()
    {
        return await _client.IssuedCarAllAsync();
    }

    public async Task<IssuedCar> AddIssuedCarAsync(IssuedCarPostDto issuedCar)
    {
        return await _client.IssuedCarPOSTAsync(issuedCar);
    }

    public async Task UpdateIssuedCarAsync(long id, IssuedCarPostDto issuedCar)
    {
        await _client.IssuedCarPUTAsync(id, issuedCar);
    }

    public async Task DeleteIssuedCarAsync(long id)
    {
        await _client.IssuedCarDELETEAsync(id);
    }

    public async Task<ICollection<RefundInformation>> GetRefundInformationsAsync()
    {
        return await _client.RefundInformationAllAsync();
    }

    public async Task<RefundInformation> AddRefundInformationAsync(RefundInformationPostDto refundInformation)
    {
        return await _client.RefundInformationPOSTAsync(refundInformation);
    }

    public async Task UpdateRefundInformationAsync(long id, RefundInformationPostDto refundInformation)
    {
        await _client.RefundInformationPUTAsync(id, refundInformation);
    }

    public async Task DeleteRefundInformationAsync(long id)
    {
        await _client.RefundInformationDELETEAsync(id);
    }

    public async Task<ICollection<RentalInformation>> GetRentalInformationsAsync()
    {
        return await _client.RentalInformationAllAsync();
    }

    public async Task<RentalInformation> AddRentalInformationAsync(RentalInformationPostDto rentalInformation)
    {
        return await _client.RentalInformationPOSTAsync(rentalInformation);
    }

    public async Task UpdateRentalInformationAsync(long id, RentalInformationPostDto rentalInformation)
    {
        await _client.RentalInformationPUTAsync(id, rentalInformation);
    }

    public async Task DeleteRentalInformationAsync(long id)
    {
        await _client.RentalInformationDELETEAsync(id);
    }

    public async Task<ICollection<RentalPointGetDto>> GetRentalPointsAsync()
    {
        return await _client.RentalPointAllAsync();
    }

    public async Task<RentalPointGetDto> AddRentalPointAsync(RentalPointPostDto rentalPoint)
    {
        return await _client.RentalPointPOSTAsync(rentalPoint);
    }

    public async Task UpdateRentalPointAsync(long id, RentalPointPostDto rentalPoint)
    {
        await _client.RentalPointPUTAsync(id, rentalPoint);
    }

    public async Task DeleteRentalPointAsync(long id)
    {
        await _client.RentalPointDELETEAsync(id);
    }

    public async Task<ICollection<VehicleModelGetDto>> GetVehicleModelsAsync()
    {
        return await _client.VehicleModelAllAsync();
    }

    public async Task<VehicleModelGetDto> AddVehicleModelAsync(VehicleModelPostDto vehicleModel)
    {
        return await _client.VehicleModelPOSTAsync(vehicleModel);
    }

    public async Task UpdateVehicleModelAsync(long id, VehicleModelPostDto vehicleModel)
    {
        await _client.VehicleModelPUTAsync(id, vehicleModel);
    }

    public async Task DeleteVehicleModelAsync(long id)
    {
        await _client.VehicleModelDELETEAsync(id);
    }

    public async Task<ICollection<VehicleGetDto>> GetVehiclesAsync()
    {
        return await _client.VehicleAllAsync();
    }

    public async Task<VehicleGetDto> AddVehicleAsync(VehiclePostDto vehicle)
    {
        return await _client.VehiclePOSTAsync(vehicle);
    }

    public async Task UpdateVehicleAsync(long id, VehiclePostDto vehicle)
    {
        await _client.VehiclePUTAsync(id, vehicle);
    }

    public async Task DeleteVehicleAsync(long id)
    {
        await _client.VehicleDELETEAsync(id);
    }

    public async Task<ICollection<VehicleGetDto>> RentedVehicleAsync()
    {
        return await _client.RentAsync();
    }
}