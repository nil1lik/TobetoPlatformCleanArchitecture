using Amazon.Runtime.Internal;
using Application.Features.AsyncLessons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
namespace Application.Features.AsyncLessons.Queries.GetLessonDetailByAsyncLessonId
{
    public class GetLessonDetailByAsyncLessonIdQuery : IRequest<GetLessonDetailByAsyncLessonIdResponse>
    {
        public int Id { get; set; }

        public class GetLessonDetailByAsyncLessonIdQueryHandler : IRequestHandler<GetLessonDetailByAsyncLessonIdQuery, GetLessonDetailByAsyncLessonIdResponse>
        {
            private readonly IMapper _mapper;
            private readonly IAsyncLessonRepository _asyncLessonRepository;
            private readonly AsyncLessonBusinessRules _asyncLessonBusinessRules;

            public GetLessonDetailByAsyncLessonIdQueryHandler(IMapper mapper, IAsyncLessonRepository asyncLessonRepository, AsyncLessonBusinessRules asyncLessonBusinessRules)
            {
                _mapper = mapper;
                _asyncLessonRepository = asyncLessonRepository;
                _asyncLessonBusinessRules = asyncLessonBusinessRules;
            }

            public async Task<GetLessonDetailByAsyncLessonIdResponse> Handle(GetLessonDetailByAsyncLessonIdQuery request, CancellationToken cancellationToken)
            {
                AsyncLesson? asyncLesson = await _asyncLessonRepository.GetAsync(predicate: al => al.Id == request.Id,
                    include: al => al.Include(al => al.LessonType)
                    .Include(al => al.LessonVideoDetail.VideoLanguage)
                    .Include(al => al.LessonVideoDetail.Company)
                    .Include(al => al.LessonVideoDetail).ThenInclude(al=>al.LessonVideoDetailVideoDetailCategories),

                    //.Include(al => al.LessonVideoDetail.VideoDetailCategories).ThenInclude(al => al.VideoDetailSubcategories),
                    cancellationToken: cancellationToken);
                await _asyncLessonBusinessRules.AsyncLessonShouldExistWhenSelected(asyncLesson);
                GetLessonDetailByAsyncLessonIdResponse response = _mapper.Map<GetLessonDetailByAsyncLessonIdResponse>(asyncLesson);
                return response;

            }
        }
    }
}

