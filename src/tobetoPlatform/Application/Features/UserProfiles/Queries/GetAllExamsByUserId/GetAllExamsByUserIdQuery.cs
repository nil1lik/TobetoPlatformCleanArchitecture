using Application.Features.UserProfiles.Queries.GetAllCertificatesByUserId;
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

namespace Application.Features.UserProfiles.Queries.GetAllExamsByUserId;
public class GetAllExamsByUserIdQuery:IRequest<GetAllExamsByUserIdResponse>
{
    public int Id { get; set; }

    public class GetAllExamsByUserIdQueryHandler : IRequestHandler<GetAllExamsByUserIdQuery, GetAllExamsByUserIdResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly UserProfileBusinessRules _userProfileBusinessRules;

        public GetAllExamsByUserIdQueryHandler(IMapper mapper, IUserProfileRepository userProfileRepository, UserProfileBusinessRules userProfileBusinessRules)
        {
            _mapper = mapper;
            _userProfileRepository = userProfileRepository;
            _userProfileBusinessRules = userProfileBusinessRules;
        }

        public async Task<GetAllExamsByUserIdResponse> Handle(GetAllExamsByUserIdQuery request, CancellationToken cancellationToken)
        {
            UserProfile? userProfile = await _userProfileRepository.GetAsync(
                predicate: ps => ps.UserId == request.Id,
                include: ps => ps.Include(x => x.ProfileExams).ThenInclude(x=>x.Exam),
                cancellationToken: cancellationToken);

            await _userProfileBusinessRules.UserProfileShouldExistWhenSelected(userProfile);

            GetAllExamsByUserIdResponse response = _mapper.Map<GetAllExamsByUserIdResponse>(userProfile);
            return response;
        }
    }
}
