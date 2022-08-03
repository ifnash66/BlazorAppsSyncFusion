using System.Net.Mime;
using System.Text;
using System.Text.Json;
using BlazorApps.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorServer.Services;

public class HostClientService
{
    private readonly HttpClient _httpClient;

    public HostClientService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<HostRecord?> Get(int id)
    {
        try
        {
            var hostRecord = await _httpClient.GetFromJsonAsync<HostRecord>($"GetHost/{id}");
            return hostRecord;
        }
        catch (HttpRequestException e)
        {
            return null;
        }
    }
    
    public async Task<IEnumerable<HostRecord>?> GetAll()
    {
        try
        {
            var hostRecords = await _httpClient.GetFromJsonAsync<IEnumerable<HostRecord>>("GetHosts");
            return hostRecords;
        }
        catch (HttpRequestException e)
        {
            return null;
        }
    }

    public async Task AddHost(HostRecord hostRecord)
    {
        try
        {
            await _httpClient.PostAsJsonAsync("AddHost", hostRecord);
        }
        catch (HttpRequestException e)
        {
        }
    }
    
    public async Task UpdateHost(int hostRecordId, HostRecord hostRecord)
    {
        try
        {
            await _httpClient.PutAsJsonAsync($"UpdateHost/{hostRecordId}", hostRecord);
        }
        catch (HttpRequestException e)
        {
        }
    }
    
    public async Task DeleteHost(int hostRecordId)
    {
        var response = await _httpClient.DeleteAsync($"DeleteHost/{hostRecordId}");
        if (response.IsSuccessStatusCode)
        {
        }
    }
}