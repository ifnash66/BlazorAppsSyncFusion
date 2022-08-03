using System.Net.Mime;
using System.Text;
using System.Text.Json;
using BlazorServer.Data.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BlazorServer.Services;

public class GuestClientService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<GuestClientService> _logger;

    public GuestClientService(HttpClient httpClient, ILogger<GuestClientService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<GuestRecord?> Get(int id)
    {
        try
        {
            var guest = await _httpClient.GetFromJsonAsync<GuestRecord>($"GetGuest/{id}");
            return guest;
        }
        catch (HttpRequestException e)
        {
            _logger.LogError(e, "Error getting guest with id:{Id}", id);
            return null;
        }
    }
    
    public async Task<IEnumerable<GuestRecord>?> GetAll()
    {
        try
        {
            var guests = await _httpClient.GetFromJsonAsync<IEnumerable<GuestRecord>>("GetGuests");
            return guests;
        }
        catch (HttpRequestException e)
        {
            _logger.LogError(e, "Error getting guests");
            return null;
        }
    }

    public async Task AddGuest(GuestRecord guestRecord)
    {
        try
        {
            await _httpClient.PostAsJsonAsync("AddGuest", guestRecord);
        }
        catch (HttpRequestException e)
        {
            _logger.LogError(e, "Error adding guest for: {@Guest}", guestRecord);
        }
    }
    
    public async Task UpdateGuest(int guestRecordId, GuestRecord guestRecord)
    {
        try
        {
            await _httpClient.PutAsJsonAsync($"UpdateGuest/{guestRecordId}", guestRecord);
        }
        catch (HttpRequestException e)
        {
            _logger.LogError(e, "Error updating guest with id:{Id} for guest:{@Guest}", guestRecordId, guestRecord);
        }
    }
    
    public async Task DeleteGuest(int guestRecordId)
    {
        try
        {
            await _httpClient.DeleteAsync($"DeleteGuest/{guestRecordId}");
        }
        catch (HttpRequestException e)
        {
            _logger.LogError(e, "Error deleting guest with id:{Id}", guestRecordId);
        }
    }
    
    public async Task<IEnumerable<Gender>?> GetGenderList()
    {
        try
        {
            var genderList = await _httpClient.GetFromJsonAsync<IEnumerable<Gender>>("GetGenderList");
            return genderList;
        }
        catch (HttpRequestException e)
        {
            _logger.LogError(e, "Error getting gender list");
            return null;
        }
    }
}