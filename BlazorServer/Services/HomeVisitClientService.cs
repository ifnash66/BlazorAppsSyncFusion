using System.Net.Mime;
using System.Text;
using System.Text.Json;
using BlazorApps.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorServer.Services;

public class HomeVisitClientService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<HomeVisitClientService> _logger;

    public HomeVisitClientService(HttpClient httpClient, ILogger<HomeVisitClientService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<HomeVisitRecord?> Get(int id)
    {
        try
        {
            var visit = await _httpClient.GetFromJsonAsync<HomeVisitRecord>($"GetVisit/{id}");
            return visit;
        }
        catch (HttpRequestException e)
        {
            _logger.LogError(e, "Error getting home visit with id:{Id}", id);
            return null;
        }
    }

    public async Task<IEnumerable<HomeVisitRecord>?> GetAll()
    {
        try
        {
            var visits = await _httpClient.GetFromJsonAsync<IEnumerable<HomeVisitRecord>>("GetVisits");
            return visits;
        }
        catch (HttpRequestException e)
        {
            _logger.LogError(e, "Error getting home visits");
            return null;
        }
    }

    public async Task AddVisit(HomeVisitRecord visitRecord)
    {
        try
        {
            await _httpClient.PostAsJsonAsync("AddVisit", visitRecord);
        }
        catch (HttpRequestException e)
        {
            _logger.LogError(e, "Error adding visit for visit:{@HomeVisit}", visitRecord);
        }
    }

    public async Task UpdateVisit(int visitRecordId, HomeVisitRecord visitRecord)
    {
        try
        {
            await _httpClient.PutAsJsonAsync($"UpdateVisit/{visitRecordId}", visitRecord);
        }
        catch (HttpRequestException e)
        {
            _logger.LogError(e, "Error updating home visit with id:{Id} for visit record:{@VisitRecord}",
                visitRecord.Id, visitRecord);
        }
    }

    public async Task DeleteVisit(int visitRecordId)
    {
        try
        {
            await _httpClient.DeleteAsync($"DeleteVisit/{visitRecordId}");
        }
        catch (HttpRequestException e)
        {
            _logger.LogError(e, "Error deleting home visit with id:{Id}", visitRecordId);
        }
    }

    public async Task<IEnumerable<VisitStatus>?> GetVisitStatusList()
    {
        try
        {
            var visitStatusList = await _httpClient.GetFromJsonAsync<IEnumerable<VisitStatus>>("GetVisitStatusList");
            return visitStatusList;
        }
        catch (HttpRequestException e)
        {
            _logger.LogError(e, "Error getting visit status list");
            return null;
        }
    }
}