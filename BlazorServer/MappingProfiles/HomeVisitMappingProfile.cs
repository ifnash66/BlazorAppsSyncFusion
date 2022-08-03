using AutoMapper;
using BlazorServer.Data.Models.Domain;
using BlazorServer.Data.Models.DTOs;

namespace BlazorServer.MappingProfiles;

public class HomeVisitMappingProfile : Profile
{
    public HomeVisitMappingProfile()
    {
        CreateMap<HomeVisitRecord, HomeVisitRecordDTO>();
        CreateMap<HomeVisitRecordDTO, HomeVisitRecord>();
    }
}