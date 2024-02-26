using Application.Features.ProfileAddresses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProfileAddresses.Commands.Create;

public class CreateProfileAddressCommand : IRequest<CreatedProfileAddressResponse>
{
    public int UserProfileId { get; set; }
    public int CountryId { get; set; }
    public int CityId { get; set; }
    public int DistrictId { get; set; }
    public string AddressDetail { get; set; }

    public class CreateProfileAddressCommandHandler : IRequestHandler<CreateProfileAddressCommand, CreatedProfileAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileAddressRepository _profileAddressRepository;
        private readonly ProfileAddressBusinessRules _profileAddressBusinessRules;

        public CreateProfileAddressCommandHandler(IMapper mapper, IProfileAddressRepository profileAddressRepository,
                                         ProfileAddressBusinessRules profileAddressBusinessRules)
        {
            _mapper = mapper;
            _profileAddressRepository = profileAddressRepository;
            _profileAddressBusinessRules = profileAddressBusinessRules;
        }

        public async Task<CreatedProfileAddressResponse> Handle(CreateProfileAddressCommand request, CancellationToken cancellationToken)
        {
            ProfileAddress profileAddress = _mapper.Map<ProfileAddress>(request);
            await _profileAddressRepository.AddAsync(profileAddress);

            CreatedProfileAddressResponse response = _mapper.Map<CreatedProfileAddressResponse>(profileAddress);
            return response;
        }
    }
}