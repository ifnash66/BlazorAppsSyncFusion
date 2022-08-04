using AutoMapper;
using BlazorServer.Data.Models.Domain;
using BlazorServer.Data.Models.DTOs;

namespace BlazorServer.MappingProfiles;

public class GuestChildMappingProfile : Profile
{
    public GuestChildMappingProfile()
    {
        CreateMap<GuestChild, GuestChildDTO>();
        CreateMap<GuestChildDTO, GuestChild>();
    }
}