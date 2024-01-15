using Application.Features.ProfileAddresses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ProfileAddresses.Commands.Update;

public class UpdateProfileAddressCommand : IRequest<UpdatedProfileAddressResponse>
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int CountryId { get; set; }
    public int CityId { get; set; }
    public int DistrictId { get; set; }
    public string AddressDetail { get; set; }

    public class UpdateProfileAddressCommandHandler : IRequestHandler<UpdateProfileAddressCommand, UpdatedProfileAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileAddressRepository _profileAddressRepository;
        private readonly ProfileAddressBusinessRules _profileAddressBusinessRules;

        public UpdateProfileAddressCommandHandler(IMapper mapper, IProfileAddressRepository profileAddressRepository,
                                         ProfileAddressBusinessRules profileAddressBusinessRules)
        {
            _mapper = mapper;
            _profileAddressRepository = profileAddressRepository;
            _profileAddressBusinessRules = profileAddressBusinessRules;
        }

        public async Task<UpdatedProfileAddressResponse> Handle(UpdateProfileAddressCommand request, CancellationToken cancellationToken)
        {
            ProfileAddress? profileAddress = await _profileAddressRepository.GetAsync(predicate: pa => pa.Id == request.Id,
                include: p => p.Include(x => x.City).
                                Include(x => x.Country).
                                Include(x => x.District), cancellationToken: cancellationToken);
            await _profileAddressBusinessRules.ProfileAddressShouldExistWhenSelected(profileAddress);
            profileAddress = _mapper.Map(request, profileAddress);

            await _profileAddressRepository.UpdateAsync(profileAddress!);

            UpdatedProfileAddressResponse response = _mapper.Map<UpdatedProfileAddressResponse>(profileAddress);
            return response;
        }
    }
}