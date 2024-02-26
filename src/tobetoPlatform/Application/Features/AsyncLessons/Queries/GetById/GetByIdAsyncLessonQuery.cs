using Application.Features.AsyncLessons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.AsyncLessons.Queries.GetById;

public class GetByIdAsyncLessonQuery : IRequest<GetByIdAsyncLessonResponse>
{
    public int Id { get; set; }

    public class GetByIdAsyncLessonQueryHandler : IRequestHandler<GetByIdAsyncLessonQuery, GetByIdAsyncLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncLessonRepository _asyncLessonRepository;
        private readonly AsyncLessonBusinessRules _asyncLessonBusinessRules;

        public GetByIdAsyncLessonQueryHandler(IMapper mapper, IAsyncLessonRepository asyncLessonRepository, AsyncLessonBusinessRules asyncLessonBusinessRules)
        {
            _mapper = mapper;
            _asyncLessonRepository = asyncLessonRepository;
            _asyncLessonBusinessRules = asyncLessonBusinessRules;
        }

        public async Task<GetByIdAsyncLessonResponse> Handle(GetByIdAsyncLessonQuery request, CancellationToken cancellationToken)
        {
            AsyncLesson? asyncLesson = await _asyncLessonRepository.GetAsync(predicate: al => al.Id == request.Id, cancellationToken: cancellationToken);
            await _asyncLessonBusinessRules.AsyncLessonShouldExistWhenSelected(asyncLesson);

            GetByIdAsyncLessonResponse response = _mapper.Map<GetByIdAsyncLessonResponse>(asyncLesson);
            return response;
        }
    }
}