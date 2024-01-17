using Application.Features.ProfileAddresses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ProfileAddresses.Queries.GetById;

public class GetByIdProfileAddressQuery : IRequest<GetByIdProfileAddressResponse>
{
    public int Id { get; set; }

    public class GetByIdProfileAddressQueryHandler : IRequestHandler<GetByIdProfileAddressQuery, GetByIdProfileAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileAddressRepository _profileAddressRepository;
        private readonly ProfileAddressBusinessRules _profileAddressBusinessRules;

        public GetByIdProfileAddressQueryHandler(IMapper mapper, IProfileAddressRepository profileAddressRepository, ProfileAddressBusinessRules profileAddressBusinessRules)
        {
            _mapper = mapper;
            _profileAddressRepository = profileAddressRepository;
            _profileAddressBusinessRules = profileAddressBusinessRules;
        }

        public async Task<GetByIdProfileAddressResponse> Handle(GetByIdProfileAddressQuery request, CancellationToken cancellationToken)
        {
            ProfileAddress? profileAddress = await _profileAddressRepository.GetAsync(
                predicate: pa => pa.Id == request.Id, 
                include:p => p.Include(x => x.City),
                cancellationToken: cancellationToken);

            await _profileAddressBusinessRules.ProfileAddressShouldExistWhenSelected(profileAddress);

            GetByIdProfileAddressResponse response = _mapper.Map<GetByIdProfileAddressResponse>(profileAddress);
            return response;
        }
    }
}