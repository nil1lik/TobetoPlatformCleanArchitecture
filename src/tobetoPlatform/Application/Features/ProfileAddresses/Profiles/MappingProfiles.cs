using Application.Features.ProfileAddresses.Commands.Create;
using Application.Features.ProfileAddresses.Commands.Delete;
using Application.Features.ProfileAddresses.Commands.Update;
using Application.Features.ProfileAddresses.Queries.GetById;
using Application.Features.ProfileAddresses.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.ProfileAddresses.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ProfileAddress, CreateProfileAddressCommand>().ReverseMap();
        CreateMap<ProfileAddress, CreatedProfileAddressResponse>().ReverseMap();
        CreateMap<ProfileAddress, UpdateProfileAddressCommand>().ReverseMap();
        CreateMap<ProfileAddress, UpdatedProfileAddressResponse>().
            ForMember(c => c.City, opt => opt.MapFrom(c => c.City.Name)).
            ForMember(c => c.Country, opt => opt.MapFrom(c => c.Country.Name)).
            ForMember(c => c.District, opt => opt.MapFrom(c => c.District.Name))
            .ReverseMap();
        CreateMap<ProfileAddress, DeleteProfileAddressCommand>().ReverseMap();
        CreateMap<ProfileAddress, DeletedProfileAddressResponse>().ReverseMap();
        CreateMap<ProfileAddress, GetByIdProfileAddressResponse>().
            ForMember(c=>c.City,opt=>opt.MapFrom(c=>c.City.Name)).
            ForMember(c => c.Country, opt => opt.MapFrom(c => c.Country.Name)).
            ForMember(c => c.District, opt => opt.MapFrom(c => c.District.Name)).
            ReverseMap();
        CreateMap<ProfileAddress, GetListProfileAddressListItemDto>().ReverseMap();
        CreateMap<IPaginate<ProfileAddress>, GetListResponse<GetListProfileAddressListItemDto>>().ReverseMap();

    }
}