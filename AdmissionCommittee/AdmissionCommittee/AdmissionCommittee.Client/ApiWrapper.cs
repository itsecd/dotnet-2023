using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace AdmissionCommittee.Client;

/// <summary>
/// Сlass for accessing server methods
/// </summary>
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


    /// <summary>
    /// Get all Entrants
    /// </summary>
    /// <returns>ICollection type EntrantGetDto</returns>
    public Task<ICollection<EntrantGetDto>> GetEntrantsAsync()
    {
        return _client.EntrantAllAsync();
    }

    /// <summary>
    /// Add Entrant
    /// </summary>
    /// <param name="entrantPostDto">new Entrant</param>
    /// <returns></returns>
    public Task AddEntrantAsync(EntrantPostDto entrantPostDto)
    {
        return _client.EntrantPOSTAsync(entrantPostDto);
    }

    /// <summary>
    /// Update information about Entrant
    /// </summary>
    /// <param name="idEntrant">id Entrant</param>
    /// <param name="entrantPostDto">Entrant for update</param>
    /// <returns></returns>
    public Task UpdateEntrantAsync(int idEntrant, EntrantPostDto entrantPostDto)
    {
        return _client.EntrantPUTAsync(idEntrant, entrantPostDto);
    }


    /// <summary>
    /// Delete Entrant by id
    /// </summary>
    /// <param name="idEntrant">id Entrant</param>
    /// <returns></returns>
    public Task DeleteEntrantAsync(int idEntrant)
    {
        return _client.EntrantDELETEAsync(idEntrant);
    }


    /// <summary>
    /// Get all EntrantResult
    /// </summary>
    /// <returns>ICollection type EntrantResultGetDto</returns>
    public Task<ICollection<EntrantResultGetDto>> GetEntrantResultsAsync()
    {
        return _client.EntrantResultAllAsync();
    }

    /// <summary>
    /// Add EntrantResult
    /// </summary>
    /// <param name="entResultPostDto">new EntrantResult</param>
    /// <returns></returns>
    public Task AddEntrantResultAsync(EntrantResultPostDto entResultPostDto)
    {
        return _client.EntrantResultPOSTAsync(entResultPostDto);
    }

    /// <summary>
    /// Update information about EntrantResult
    /// </summary>
    /// <param name="idEntResult">id EntrantResult</param>
    /// <param name="entResultPostDto">EntrantResult for update</param>
    /// <returns></returns>
    public Task UpdateEntrantResultAsync(int idEntResult, EntrantResultPostDto entResultPostDto)
    {
        return _client.EntrantResultPUTAsync(idEntResult, entResultPostDto);
    }

    /// <summary>
    /// Delete EntrantResult by id
    /// </summary>
    /// <param name="idEntResult">id EntrantResult</param>
    /// <returns></returns>
    public Task DeleteEntrantResultAsync(int idEntResult)
    {
        return _client.EntrantResultDELETEAsync(idEntResult);
    }

    /// <summary>
    /// Get all Result
    /// </summary>
    /// <returns>ICollection type ResultGetDto</returns>
    public Task<ICollection<ResultGetDto>> GetResultsAsync()
    {
        return _client.ResultAllAsync();
    }

    /// <summary>
    /// Add Result
    /// </summary>
    /// <param name="resultPostDto">new Result</param>
    /// <returns></returns>
    public Task AddResultAsync(ResultPostDto resultPostDto)
    {
        return _client.ResultPOSTAsync(resultPostDto);
    }

    /// <summary>
    /// Update information about Result
    /// </summary>
    /// <param name="idResult">id Result</param>
    /// <param name="resultPostDto">new Result</param>
    /// <returns></returns>
    public Task UpdateResultAsync(int idResult, ResultPostDto resultPostDto)
    {
        return _client.ResultPUTAsync(idResult, resultPostDto);
    }

    /// <summary>
    /// Delete Result by id
    /// </summary>
    /// <param name="idResult">id Result</param>
    /// <returns></returns>
    public Task DeleteResultAsync(int idResult)
    {
        return _client.ResultDELETEAsync(idResult);
    }

    /// <summary>
    /// Get all Statement
    /// </summary>
    /// <returns>ICollection type StatementGetDto</returns>
    public Task<ICollection<StatementGetDto>> GetStatementsAsync()
    {
        return _client.StatementAllAsync();
    }

    /// <summary>
    /// Add Statement
    /// </summary>
    /// <param name="statementPostDto">new Statement</param>
    /// <returns></returns>
    public Task AddStatementAsync(StatementPostDto statementPostDto)
    {
        return _client.StatementPOSTAsync(statementPostDto);
    }

    /// <summary>
    /// Update information about Statement
    /// </summary>
    /// <param name="idStatement">id Statement</param>
    /// <param name="statementPostDto">Statement for update</param>
    /// <returns></returns>
    public Task UpdateStatementAsync(int idStatement, StatementPostDto statementPostDto)
    {
        return _client.StatementPUTAsync(idStatement, statementPostDto);
    }

    /// <summary>
    /// Delete Statement by id
    /// </summary>
    /// <param name="idStatement">id Statement</param>
    /// <returns></returns>
    public Task DeleteStatementAsync(int idStatement)
    {
        return _client.StatementDELETEAsync(idStatement);
    }

    /// <summary>
    /// Get all StatementSpecialty
    /// </summary>
    /// <returns>ICollection type StatementSpecialtyGetDto</returns>
    public Task<ICollection<StatementSpecialtyGetDto>> GetStatementSpecialtiesAsync()
    {
        return _client.StatementSpecialtyAllAsync();
    }

    /// <summary>
    /// Add StatementSpecialty
    /// </summary>
    /// <param name="stSpecialtyPostDto">new StatementSpecialty</param>
    /// <returns></returns>
    public Task AddStatementSpecialtyAsync(StatementSpecialtyPostDto stSpecialtyPostDto)
    {
        return _client.StatementSpecialtyPOSTAsync(stSpecialtyPostDto);
    }

    /// <summary>
    /// Update information about StatementSpecialty
    /// </summary>
    /// <param name="idStSpecialty">id StatementSpecialty</param>
    /// <param name="stSpecialtyPostDto">StatementSpecilty for update</param>
    /// <returns></returns>
    public Task UpdateStatementSpecialtyAsync(int idStSpecialty, StatementSpecialtyPostDto stSpecialtyPostDto)
    {
        return _client.StatementSpecialtyPUTAsync(idStSpecialty, stSpecialtyPostDto);
    }

    /// <summary>
    /// Delete StatementSpecialty by id
    /// </summary>
    /// <param name="idStSpecialty">id StatementSpecialty</param>
    /// <returns></returns>
    public Task DeleteStatementSpecialtyAsync(int idStSpecialty)
    {
        return _client.StatementSpecialtyDELETEAsync(idStSpecialty);
    }

    /// <summary>
    /// Get all Specialty
    /// </summary>
    /// <returns>ICollection type SpecialtyGetDto</returns>
    public Task<ICollection<SpecialtyGetDto>> GetSpecialtiesAsync()
    {
        return _client.SpecialtyAllAsync();
    }

    /// <summary>
    /// Add Specialty 
    /// </summary>
    /// <param name="specialtyPostDto">new Specialty</param>
    /// <returns></returns>
    public Task AddSpecialtyAsync(SpecialtyPostDto specialtyPostDto)
    {
        return _client.SpecialtyPOSTAsync(specialtyPostDto);
    }

    /// <summary>
    /// Update information about Specialty
    /// </summary>
    /// <param name="idSpecialty">id Specialty</param>
    /// <param name="specialtyPostDto">Specialty for update</param>
    /// <returns></returns>
    public Task UpdateSpecialtyAsync(int idSpecialty, SpecialtyPostDto specialtyPostDto)
    {
        return _client.SpecialtyPUTAsync(idSpecialty, specialtyPostDto);
    }

    /// <summary>
    /// Delete Specialty by id
    /// </summary>
    /// <param name="idSpecialty">id Specialty</param>
    /// <returns></returns>
    public Task DeleteSpecialtyAsync(int idSpecialty)
    {
        return _client.SpecialtyDELETEAsync(idSpecialty);
    }


    /// <summary>
    /// Get Entrants From City 
    /// </summary>
    /// <param name="city">name city</param>
    /// <returns>ICollection type EntrantGetDto</returns>
    public Task<ICollection<EntrantGetDto>> GetEntrantsFromCityAsync(string city)
    {
        return _client.GetEntrantsFromSpecifiedCityAsync(city);
    }

    /// <summary>
    /// Get Entrants Over Twenty Years Older
    /// </summary>
    /// <returns>ICollection type EntrantGetDto</returns>
    public Task<ICollection<EntrantGetDto>> GetEntrantsOverTwentyYearsOlderAsync()
    {
        return _client.GetEntrantsOverTwentyYearsOlderAsync();
    }

    /// <summary>
    /// Get Entrants In Specialty
    /// </summary>
    /// <param name="specialty">name specialty</param>
    /// <returns>ICollection type EntrantGetDto</returns>
    public Task<ICollection<EntrantGetDto>> GetEntrantsInSpecialtyAsync(string specialty)
    {
        return _client.GetEntrantsEnteringSpecifiedSpecialtyAsync(specialty);
    }

    /// <summary>
    /// Get Count Entrants In Each Specialty
    /// </summary>
    /// <returns>ICollection type CountEntrantsInEachSpecialtyGetDto</returns>
    public Task<ICollection<CountEntrantsInEachSpecialtyGetDto>> GetCountEntrantsInEachSpecialtyAsync()
    {
        return _client.CountOfEntrantsEnteringEachSpecialtyAsync();
    }

    /// <summary>
    /// Get Entrants Top Five
    /// </summary>
    /// <returns>ICollection type EntrantGetDto</returns>
    public Task<ICollection<EntrantGetDto>> GetEntrantsTopFiveAsync()
    {
        return _client.TopFiveEntrantsAsync();
    }
}