using AutoMapper;
using BlazorServer.Data.Models.Domain;
using BlazorServer.Data.Models.DTOs;

namespace BlazorServer.MappingProfiles;

public class GuestMappingProfile : Profile
{
    public GuestMappingProfile()
    {
        CreateMap<GuestRecord, GuestRecordDTO>();
        CreateMap<GuestRecordDTO, GuestRecord>();
    }
}