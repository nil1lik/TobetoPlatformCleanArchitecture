using Application.Features.Cities.Constants;
using Application.Features.Cities.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Cities.Commands.Delete;

public class DeleteCityCommand : IRequest<DeletedCityResponse>
{
    public int Id { get; set; }

    public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, DeletedCityResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICityRepository _cityRepository;
        private readonly CityBusinessRules _cityBusinessRules;

        public DeleteCityCommandHandler(IMapper mapper, ICityRepository cityRepository,
                                         CityBusinessRules cityBusinessRules)
        {
            _mapper = mapper;
            _cityRepository = cityRepository;
            _cityBusinessRules = cityBusinessRules;
        }

        public async Task<DeletedCityResponse> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            City? city = await _cityRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _cityBusinessRules.CityShouldExistWhenSelected(city);

            await _cityRepository.DeleteAsync(city!);

            DeletedCityResponse response = _mapper.Map<DeletedCityResponse>(city);
            return response;
        }
    }
}