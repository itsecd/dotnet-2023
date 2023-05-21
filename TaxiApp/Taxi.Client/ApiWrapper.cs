using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Taxi.Client;

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

    public Task<ICollection<Driver>> GetDriversAsync()
    {
        return _client.DriverAllAsync();
    }

    public Task<Driver> AddDriverAsync(DriverSetDto driver)
    {
        return _client.DriverPOSTAsync(driver);
    }

    public Task UpdateDriverAsync(ulong id, DriverSetDto driver)
    {
        return _client.DriverPUTAsync(id, driver);
    }

    public Task DeleteDriverAsync(ulong id)
    {
        return _client.DriverDELETEAsync(id);
    }

    public Task<ICollection<PassengerGetDto>> GetPassengersAsync()
    {
        return _client.PassengerAllAsync();
    }

    public Task<PassengerGetDto> AddPassengerAsync(PassengerSetDto passenger)
    {
        return _client.PassengerPOSTAsync(passenger);
    }

    public Task UpdatePassengerAsync(ulong id, PassengerSetDto passenger)
    {
        return _client.PassengerPUTAsync(id, passenger);
    }

    public Task DeletePassengerAsync(ulong id)
    {
        return _client.PassengerDELETEAsync(id);
    }


    public Task<ICollection<VehicleGetDto>> GetVehiclesAsync()
    {
        return _client.VehicleAllAsync();
    }

    public Task<VehicleGetDto> AddVehicleAsync(VehicleSetDto vehicle)
    {
        return _client.VehiclePOSTAsync(vehicle);
    }

    public Task UpdateVehicleAsync(ulong id, VehicleSetDto vehicle)
    {
        return _client.VehiclePUTAsync(id, vehicle);
    }

    public Task DeleteVehicleAsync(ulong id)
    {
        return _client.VehicleDELETEAsync(id);
    }


    public Task<ICollection<VehicleClassification>> GetVehicleClassificationsAsync()
    {
        return _client.VehicleClassificationAllAsync();
    }

    public Task<VehicleClassification> AddVehicleClassificationAsync(VehicleClassificationSetDto vehicleClassification)
    {
        return _client.VehicleClassificationPOSTAsync(vehicleClassification);
    }

    public Task UpdateVehicleClassificationAsync(ulong id, VehicleClassificationSetDto vehicleClassification)
    {
        return _client.VehicleClassificationPUTAsync(id, vehicleClassification);
    }

    public Task DeleteVehicleClassificationAsync(ulong id)
    {
        return _client.VehicleClassificationDELETEAsync(id);
    }


    public Task<ICollection<RideGetDto>> GetRidesAsync()
    {
        return _client.RideAllAsync();
    }

    public Task<Ride> AddRideAsync(RideSetDto ride)
    {
        return _client.RidePOSTAsync(ride);
    }

    public Task UpdateRideAsync(ulong id, RideSetDto ride)
    {
        return _client.RidePUTAsync(id, ride);
    }

    public Task DeleteRideAsync(ulong id)
    {
        return _client.RideDELETEAsync(id);
    }

    public Task<ICollection<VehicleAndDriverGetDto>> VehicleAndDriverAsync(ulong id)
    {
        return _client.VehicleAndDriverAsync(id);
    }

    public Task<ICollection<PassengerGetDto>> PassengersPeriodAsync(DateTimeOffset minDate, DateTimeOffset maxDate)
    {
        return _client.PassengersPeriodAsync(minDate, maxDate);
    }

    public Task<ICollection<CountPassengerRidesGetDto>> CountPassengerRidesAsync()
    {
        return _client.CountPassengerRidesAsync();
    }

    public Task<ICollection<Driver>> TopDriverAsync()
    {
        return _client.RidesTopDriverAsync();
    }

    public Task<ICollection<InfosAboutRidesGetDto>> InfosAboutRidesAsync()
    {
        return _client.InfosAboutRidesAsync();
    }

    public Task<ICollection<MaxRidesOfPassengerGetDto>> MaxRidesOfPassengerAsync(DateTimeOffset? minDate,
        DateTimeOffset? maxDate)
    {
        return _client.MaxRidesOfPassengerAsync(minDate, maxDate);
    }
}