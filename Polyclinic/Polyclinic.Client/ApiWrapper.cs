using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Poluclinic.Client;

namespace Polyclinic.Client;
public class ApiWrapper
{
    private readonly ApiClient _client;

    public ApiWrapper()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        var serverUrl = configuration.GetSection("ServerUrl").Value;
        _client = new ApiClient(serverUrl, new HttpClient());
    }

    public Task<ICollection<PatientGetDto>> GetPatientsAsync()
    {
        return _client.PatientAllAsync();
    }

    public Task AddPatientAsync(PatientPostDto patient)
    {
        return _client.PatientAsync(patient);
    }

    public Task UpdatePatientAsync(int id, PatientPostDto patient)
    {
        return _client.Patient3Async(id, patient);
    }

    public Task DeletePatientAsync(int id)
    {
        return _client.Patient4Async(id);
    }

    public Task<ICollection<DoctorGetDto>> GetDoctorAsync()
    {
        return _client.DoctorsAllAsync();
    }

    public Task AddDoctorAsync(DoctorPostDto doctor)
    {
        return _client.DoctorsAsync(doctor);
    }

    public Task UpdateDoctorAsync(int id, DoctorPostDto doctor)
    {
        return _client.Doctors3Async(id, doctor);
    }

    public Task DeleteDoctorAsync(int id)
    {
        return _client.Doctors4Async(id);
    }

    public Task<ICollection<SpecializationsGetDto>> GetSpecializationsAsync()
    {
        return _client.SpecializationsAllAsync();
    }
}
