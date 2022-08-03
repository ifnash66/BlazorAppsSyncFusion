using AutoMapper;
using BlazorApps.Shared.Models;

namespace BlazorServer.MappingProfiles;

public class HomeVisitMappingProfile : Profile
{
    public HomeVisitMappingProfile()
    {
        CreateMap<HomeVisitRecord, HomeVisitRecordDTO>();
        CreateMap<HomeVisitRecordDTO, HomeVisitRecord>();
    }
}