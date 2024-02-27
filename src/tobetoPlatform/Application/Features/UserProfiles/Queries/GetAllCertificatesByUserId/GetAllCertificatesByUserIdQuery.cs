using Application.Features.UserProfiles.Queries.GetAllEducationsByUserId;
using Application.Features.UserProfiles.Rules;
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

namespace Application.Features.UserProfiles.Queries.GetAllCertificatesByUserId;
public class GetAllCertificatesByUserIdQuery:IRequest<GetAllCertificatesByUserIdResponse>
{
    public int Id { get; set; }

    public class GetAllCertificatesByUserIdQueryHandler : IRequestHandler<GetAllCertificatesByUserIdQuery, GetAllCertificatesByUserIdResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly UserProfileBusinessRules _userProfileBusinessRules;

        public GetAllCertificatesByUserIdQueryHandler(IMapper mapper, IUserProfileRepository userProfileRepository, UserProfileBusinessRules userProfileBusinessRules)
        {
            _mapper = mapper;
            _userProfileRepository = userProfileRepository;
            _userProfileBusinessRules = userProfileBusinessRules;
        }

        public async Task<GetAllCertificatesByUserIdResponse> Handle(GetAllCertificatesByUserIdQuery request, CancellationToken cancellationToken)
        {
            UserProfile? userProfile = await _userProfileRepository.GetAsync(
                predicate: ps => ps.UserId == request.Id,
                include: ps => ps.Include(x => x.Certificates),
                cancellationToken: cancellationToken);

            await _userProfileBusinessRules.UserProfileShouldExistWhenSelected(userProfile);

            GetAllCertificatesByUserIdResponse response = _mapper.Map<GetAllCertificatesByUserIdResponse>(userProfile);
            return response;
        }
    }
}
