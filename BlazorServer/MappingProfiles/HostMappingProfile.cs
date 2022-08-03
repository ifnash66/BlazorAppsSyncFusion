using AutoMapper;
using BlazorServer.Data.Models.Domain;
using BlazorServer.Data.Models.DTOs;

namespace BlazorServer.MappingProfiles;

public class HostMappingProfile: Profile
{
    public HostMappingProfile()
    {
        CreateMap<HostRecord, HostRecordDTO>();
        CreateMap<HostRecordDTO, HostRecord>();
    }
}