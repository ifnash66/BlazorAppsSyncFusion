using AutoMapper;
using BlazorApps.Shared.Models;

namespace BlazorServer.MappingProfiles;

public class HostMappingProfile: Profile
{
    public HostMappingProfile()
    {
        CreateMap<HostRecord, HostRecordDTO>();
        CreateMap<HostRecordDTO, HostRecord>();
    }
}