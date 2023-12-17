using Application.Features.Countries.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Countries.Commands.Create;

public class CreateCountryCommand : IRequest<CreatedCountryResponse>
{
    public string Name { get; set; }

    public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, CreatedCountryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICountryRepository _countryRepository;
        private readonly CountryBusinessRules _countryBusinessRules;

        public CreateCountryCommandHandler(IMapper mapper, ICountryRepository countryRepository,
                                         CountryBusinessRules countryBusinessRules)
        {
            _mapper = mapper;
            _countryRepository = countryRepository;
            _countryBusinessRules = countryBusinessRules;
        }

        public async Task<CreatedCountryResponse> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            Country country = _mapper.Map<Country>(request);

            await _countryRepository.AddAsync(country);

            CreatedCountryResponse response = _mapper.Map<CreatedCountryResponse>(country);
            return response;
        }
    }
}