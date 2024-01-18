using Application.Features.Cities.Queries.GetById;
using Application.Features.Cities.Queries.GetDistrictById;
using Application.Features.Cities.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cities.Queries.GetDistrictByCityId;
public class GetDistrictByIdCityQuery : IRequest<GetDistrictByIdCityResponse>
{
    public int Id { get; set; }

    public class GetDistrictByIdCityHandler : IRequestHandler<GetDistrictByIdCityQuery, GetDistrictByIdCityResponse>
    {

        private readonly IMapper _mapper;
        private readonly ICityRepository _cityRepository;
        private readonly CityBusinessRules _cityBusinessRules;

        public GetDistrictByIdCityHandler(IMapper mapper, ICityRepository cityRepository, CityBusinessRules cityBusinessRules)
        {
            _mapper = mapper;
            _cityRepository = cityRepository;
            _cityBusinessRules = cityBusinessRules;
        }

        public async Task<GetDistrictByIdCityResponse> Handle(GetDistrictByIdCityQuery request, CancellationToken cancellationToken)
        {
            City? city = await _cityRepository.GetAsync(predicate: c => c.Id == request.Id,
                include: p => p.Include(p => p.Districts),
                    cancellationToken: cancellationToken);
            await _cityBusinessRules.CityShouldExistWhenSelected(city);

            GetDistrictByIdCityResponse response = _mapper.Map<GetDistrictByIdCityResponse>(city);
            return response;
        }
    }

}
