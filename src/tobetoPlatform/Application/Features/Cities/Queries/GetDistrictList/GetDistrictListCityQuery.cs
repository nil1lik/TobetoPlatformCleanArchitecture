using Application.Features.Cities.Queries.GetList;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cities.Queries.GetDistrictListByCityId;
public class GetDistrictListCityQuery:IRequest<GetListResponse<GetDistrictListCityListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetDistrictListCityHandler:IRequestHandler<GetDistrictListCityQuery, GetListResponse<GetDistrictListCityListItemDto>>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public GetDistrictListCityHandler(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetDistrictListCityListItemDto>> Handle(GetDistrictListCityQuery request, CancellationToken cancellationToken)
        {
            IPaginate<City> cities = await _cityRepository.GetListAsync(
                include: p => p.Include(p => p.Districts),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetDistrictListCityListItemDto> response = _mapper.Map<GetListResponse<GetDistrictListCityListItemDto>>(cities);
            return response;
        }
    }
}
