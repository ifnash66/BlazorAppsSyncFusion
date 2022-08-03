using AutoMapper;
using BlazorApps.Shared.Models;

namespace BlazorServer.MappingProfiles;

public class GuestMappingProfile : Profile
{
    public GuestMappingProfile()
    {
        CreateMap<GuestRecord, GuestRecordDTO>();
        CreateMap<GuestRecordDTO, GuestRecord>();
    }
}