using Application.Features.UserProfiles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
namespace Application.Features.UserProfiles.Queries.GetAsyncsLessonByUserId
{
    public class GetAsyncsLessonByUserIdQuery : IRequest<GetAsyncsLessonByUserIdResponse>
    {
        public int Id { get; set; }

        public class GetAsyncsLessonByUserIdQueryHandler : IRequestHandler<GetAsyncsLessonByUserIdQuery, GetAsyncsLessonByUserIdResponse>
        {
            private readonly IMapper _mapper;
            private readonly IUserProfileRepository _userProfileRepository;
            private readonly UserProfileBusinessRules _userProfileBusinessRules;

            public GetAsyncsLessonByUserIdQueryHandler(IMapper mapper, IUserProfileRepository userProfileRepository, UserProfileBusinessRules userProfileBusinessRules)
            {
                _mapper = mapper;
                _userProfileRepository = userProfileRepository;
                _userProfileBusinessRules = userProfileBusinessRules;
            }

            public async Task<GetAsyncsLessonByUserIdResponse> Handle(GetAsyncsLessonByUserIdQuery request, CancellationToken cancellationToken)
            {
                UserProfile? userProfile = await _userProfileRepository.GetAsync(
                predicate: up => up.UserId == request.Id,
                include: ps => ps.Include(x => x.ProfileLessons).ThenInclude(x => x.AsyncLesson),
                cancellationToken: cancellationToken);
                await _userProfileBusinessRules.UserProfileShouldExistWhenSelected(userProfile);

                GetAsyncsLessonByUserIdResponse response = _mapper.Map<GetAsyncsLessonByUserIdResponse>(userProfile);
                return response;
            }
        }
    }
}

