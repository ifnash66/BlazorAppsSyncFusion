using System.Net.Mime;
using System.Text;
using System.Text.Json;
using BlazorApps.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorServer.Services;

public class HomeVisitClientService
{
    private readonly HttpClient _httpClient;

    public HomeVisitClientService(HttpClient httpClient)
    {
        _httpClient = httpClient;
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
            return null;
        }
    }
}