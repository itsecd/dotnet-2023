using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace AdmissionCommittee.Client;
public class ApiWrapper
{
    private readonly ApiClient _client;

    public ApiWrapper()
    {
        var confugaration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var serverUrl = confugaration.GetSection("ServerUrl").Value;

        _client = new ApiClient(serverUrl, new HttpClient());
    }

    public Task<ICollection<EntrantGetDto>> GetEntrantsAsync()
    {
        return _client.EntrantAllAsync();
    }

    public Task AddEntrantAsync(EntrantPostDto entrantPostDto)
    {
        return _client.EntrantPOSTAsync(entrantPostDto);
    }

    public Task UpdateEntrantAsync(int idEntrant, EntrantPostDto entrantPostDto)
    {
        return _client.EntrantPUTAsync(idEntrant, entrantPostDto);
    }

    public Task DeleteEntrantAsync(int idEntrant)
    {
        return _client.EntrantDELETEAsync(idEntrant);
    }

    //EntrantResult
    public Task<ICollection<EntrantResultGetDto>> GetEntrantResultsAsync()
    {
        return _client.EntrantResultAllAsync();
    }

    public Task AddEntrantResultAsync(EntrantResultPostDto entResultPostDto)
    {
        return _client.EntrantResultPOSTAsync(entResultPostDto);
    }

    public Task UpdateEntrantResultAsync(int idEntResult, EntrantResultPostDto entResultPostDto)
    {
        return _client.EntrantResultPUTAsync(idEntResult, entResultPostDto);
    }

    public Task DeleteEntrantResultAsync(int idEntResult)
    {
        return _client.EntrantResultDELETEAsync(idEntResult);
    }

    //Result
    public Task<ICollection<ResultGetDto>> GetResultsAsync()
    {
        return _client.ResultAllAsync();
    }

    public Task AddResultAsync(ResultPostDto resultPostDto)
    {
        return _client.ResultPOSTAsync(resultPostDto);
    }

    public Task UpdateResultAsync(int idResult, ResultPostDto resultPostDto)
    {
        return _client.ResultPUTAsync(idResult, resultPostDto);
    }

    public Task DeleteResultAsync(int idResult)
    {
        return _client.ResultDELETEAsync(idResult);
    }

    //Statement
    public Task<ICollection<StatementGetDto>> GetStatementsAsync()
    {
        return _client.StatementAllAsync();
    }

    public Task AddStatementAsync(StatementPostDto statementPostDto)
    {
        return _client.StatementPOSTAsync(statementPostDto);
    }

    public Task UpdateStatementAsync(int idStatement, StatementPostDto statementPostDto)
    {
        return _client.StatementPUTAsync(idStatement, statementPostDto);
    }

    public Task DeleteStatementAsync(int idStatement)
    {
        return _client.StatementDELETEAsync(idStatement);
    }

    //StatementSpecialty
    public Task<ICollection<StatementSpecialtyGetDto>> GetStatementSpecialtiesAsync()
    {
        return _client.StatementSpecialtyAllAsync();
    }

    public Task AddStatementSpecialtyAsync(StatementSpecialtyPostDto stSpecialtyPostDto)
    {
        return _client.StatementSpecialtyPOSTAsync(stSpecialtyPostDto);
    }

    public Task UpdateStatementSpecialtyAsync(int idStSpecialty, StatementSpecialtyPostDto stSpecialtyPostDto)
    {
        return _client.StatementSpecialtyPUTAsync(idStSpecialty, stSpecialtyPostDto);
    }

    public Task DeleteStatementSpecialtyAsync(int idStSpecialty)
    {
        return _client.StatementSpecialtyDELETEAsync(idStSpecialty);
    }

    //Specialty
    public Task<ICollection<SpecialtyGetDto>> GetSpecialtiesAsync()
    {
        return _client.SpecialtyAllAsync();
    }

    public Task AddSpecialtyAsync(SpecialtyPostDto specialtyPostDto)
    {
        return _client.SpecialtyPOSTAsync(specialtyPostDto);
    }

    public Task UpdateSpecialtyAsync(int idSpecialty, SpecialtyPostDto specialtyPostDto)
    {
        return _client.SpecialtyPUTAsync(idSpecialty, specialtyPostDto);
    }

    public Task DeleteSpecialtyAsync(int idSpecialty)
    {
        return _client.SpecialtyDELETEAsync(idSpecialty);
    }


    //request
    public Task<ICollection<EntrantGetDto>> GetEntrantsFromCityAsync(string city)
    {
        return _client.GetEntrantsFromSpecifiedCityAsync(city);
    }

    public Task<ICollection<EntrantGetDto>> GetEntrantsOverTwentyYearsOlderAsync()
    {
        return _client.GetEntrantsOverTwentyYearsOlderAsync();
    }

    public Task<ICollection<EntrantGetDto>> GetEntrantsInSpecialtyAsync(string specialty)
    {
        return _client.GetEntrantsEnteringSpecifiedSpecialtyAsync(specialty);
    }

    public Task<ICollection<CountEntrantsInEachSpecialtyGetDto>> GetCountEntrantsInEachSpecialtyAsync()
    {
        return _client.CountOfEntrantsEnteringEachSpecialtyAsync();
    }

    public Task<ICollection<EntrantGetDto>> GetEntrantsTopFiveAsync()
    {
        return _client.TopFiveEntrantsAsync();
    }
}