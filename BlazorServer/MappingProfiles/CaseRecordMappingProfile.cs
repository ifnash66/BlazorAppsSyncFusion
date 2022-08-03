using AutoMapper;
using BlazorServer.Data.Models.Domain;

namespace BlazorServer.MappingProfiles;

public class CaseRecordMappingProfile: Profile
{
    public CaseRecordMappingProfile()
    {
        CreateMap<CaseRecord, CaseRecordDTO>();
        CreateMap<CaseRecordDTO, CaseRecord>();
    }
}