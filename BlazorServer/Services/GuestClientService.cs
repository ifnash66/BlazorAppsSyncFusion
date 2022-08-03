using System.Net.Mime;
using System.Text;
using System.Text.Json;
using BlazorApps.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorServer.Services;

public class GuestClientService
{
    private readonly HttpClient _httpClient;

    public GuestClientService(HttpClient httpClient)
    {
        _httpClient = httpClient;
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
            return null;
        }
    }
}