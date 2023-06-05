using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace PoliclinicClient;
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

    public async Task<ICollection<PatientGetDto>> GetPatientsAsync()
    {
        return await _client.PatientsAllAsync();
    }

    public async Task AddPatientAsync(PatientPostDto patient)
    {
        await _client.PatientsAsync(patient);
    }

    public async Task UpdatePatientAsync(int id, PatientPostDto patient)
    {
        await _client.Patients3Async(id, patient);
    }

    public async Task DeletePatientAsync(int id)
    {
        await _client.Patients4Async(id);
    }

    public async Task<ICollection<DoctorGetDto>> GetDoctorsAsync()
    {
        return await _client.DoctorsAllAsync();
    }

    public async Task AddDoctorAsync(DoctorPostDto doctor)
    {
        await _client.DoctorsAsync(doctor);
    }

    public async Task UpdateDoctorAsync(int id, DoctorPostDto doctor)
    {
        await _client.Doctors3Async(id, doctor);
    }

    public async Task DeleteDoctorAsync(int id)
    {
        await _client.Doctors4Async(id);
    }

    public async Task<ICollection<ReceptionDto>> GetReceptionsAsync()
    {
        return await _client.ReceptionsAllAsync();
    }

    public async Task AddReceptionAsync(ReceptionDto reception)
    {
        await _client.ReceptionsAsync(reception);
    }

    public async Task UpdateReceptionAsync(int id, ReceptionDto reception)
    {
        await _client.Receptions3Async(id, reception);
    }

    public async Task DeleteReceptionAsync(int id)
    {
        await _client.Receptions4Async(id);
    }

    public async Task<ICollection<SpecializationDto>> GetSpecializationsAsync()
    {
        return await _client.SpecializationsAllAsync();
    }

    public async Task<ICollection<DoctorGetDto>> GetExperiencedDoctorsAsync()
    {
        return await _client.YearsAsync();
    }

    public async Task<ICollection<PatientGetDto>> GetCurrentHealthAsync()
    {
        return await _client.PatientsAsync();
    }

    public async Task<ICollection<CountPatientDto>> GetCountPatientsAsync()
    {
        return await _client.MonthAsync();
    }

    public async Task<ICollection<Top5DiseasesDto>> GetTopDiseasesAsync()
    {
        return await _client.DiseasesAsync();
    }
}
