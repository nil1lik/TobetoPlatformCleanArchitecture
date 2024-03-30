using Amazon.Runtime.Internal;
using Application.Features.UserProfiles.Queries.GetAllAdmirationsByUserId;
using Application.Features.UserProfiles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
namespace Application.Features.UserProfiles.Queries.GetAllAdmirationsByUserId
{
    public class GetAllAdmirationsByUserIdQuery : IRequest<GetAllAdmirationsByUserIdResponse>
    {
        public int Id { get; set; }

        public class GetAllAdmirationsByUserIdQueryHandler : IRequestHandler<GetAllAdmirationsByUserIdQuery, GetAllAdmirationsByUserIdResponse>
        {
            private readonly IMapper _mapper;
            private readonly IUserProfileRepository _userProfileRepository;
            private readonly UserProfileBusinessRules _userProfileBusinessRules;

            public GetAllAdmirationsByUserIdQueryHandler(IMapper mapper, IUserProfileRepository userProfileRepository, UserProfileBusinessRules userProfileBusinessRules)
            {
                _mapper = mapper;
                _userProfileRepository = userProfileRepository;
                _userProfileBusinessRules = userProfileBusinessRules;
            }

            public async Task<GetAllAdmirationsByUserIdResponse> Handle(GetAllAdmirationsByUserIdQuery request, CancellationToken cancellationToken)
            {
                UserProfile? userProfile = await _userProfileRepository.GetAsync(
                predicate: up => up.UserId == request.Id,
                include: pa => pa.Include(x => x.ProfileAdmirations).ThenInclude(x => x.EducationAdmiration)
                .Include(x => x.ProfileAdmirations).ThenInclude(x => x.EducationPath),
                cancellationToken: cancellationToken);


                GetAllAdmirationsByUserIdResponse response = _mapper.Map<GetAllAdmirationsByUserIdResponse>(userProfile);
                return response;
            }
        }
    }
}




