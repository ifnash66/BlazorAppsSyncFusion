using System.Net.Mime;
using System.Text;
using System.Text.Json;
using BlazorServer.Data.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BlazorServer.Services;

public class HostClientService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<HostClientService> _logger;

    public HostClientService(HttpClient httpClient, ILogger<HostClientService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
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
            _logger.LogError(e, "Error getting host with id:{Id}", id);
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
            _logger.LogError(e, "Error getting hosts");
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
            _logger.LogError(e, "Error adding host record:{@Host}", hostRecord);
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
            _logger.LogError(e, "Error updating host with id:{Id} for host:{@Host}", hostRecordId, hostRecord);
        }
    }

    public async Task DeleteHost(int hostRecordId)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"DeleteHost/{hostRecordId}");
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException e)
        {
            _logger.LogError(e, "Error deleting host with id:{Id}", hostRecordId);
        }
    }
}