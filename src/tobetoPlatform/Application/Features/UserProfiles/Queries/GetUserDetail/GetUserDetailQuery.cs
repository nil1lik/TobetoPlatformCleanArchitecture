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

namespace Application.Features.UserProfiles.Queries.GetUserDetail;
public class GetUserDetailQuery : IRequest<GetUserDetailDto>
{
    public int Id { get; set; }

    public class GetUserDetailQueryHandler : IRequestHandler<GetUserDetailQuery, GetUserDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly UserProfileBusinessRules _userProfileBusinessRules;

        public GetUserDetailQueryHandler(IMapper mapper, IUserProfileRepository userProfileRepository, UserProfileBusinessRules userProfileBusinessRules)
        {
            _mapper = mapper;
            _userProfileRepository = userProfileRepository;
            _userProfileBusinessRules = userProfileBusinessRules;
        }

        public async Task<GetUserDetailDto> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
        {
            UserProfile? userProfile = await _userProfileRepository.GetAsync(
                predicate: up => up.Id == request.Id,
                include: up => up.Include(up => up.User).Include(up=>up.City).Include(up=> up.District),
                cancellationToken: cancellationToken);
            await _userProfileBusinessRules.UserProfileShouldExistWhenSelected(userProfile);

            GetUserDetailDto response = _mapper.Map<GetUserDetailDto>(userProfile);
            return response;
        }
    }
}