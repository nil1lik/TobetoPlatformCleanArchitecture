using Application.Features.ProfileLessons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProfileLessons.Queries.GetById;

public class GetByIdProfileLessonQuery : IRequest<GetByIdProfileLessonResponse>
{
    public int Id { get; set; }

    public class GetByIdProfileLessonQueryHandler : IRequestHandler<GetByIdProfileLessonQuery, GetByIdProfileLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileLessonRepository _profileLessonRepository;
        private readonly ProfileLessonBusinessRules _profileLessonBusinessRules;

        public GetByIdProfileLessonQueryHandler(IMapper mapper, IProfileLessonRepository profileLessonRepository, ProfileLessonBusinessRules profileLessonBusinessRules)
        {
            _mapper = mapper;
            _profileLessonRepository = profileLessonRepository;
            _profileLessonBusinessRules = profileLessonBusinessRules;
        }

        public async Task<GetByIdProfileLessonResponse> Handle(GetByIdProfileLessonQuery request, CancellationToken cancellationToken)
        {
            ProfileLesson? profileLesson = await _profileLessonRepository.GetAsync(predicate: pl => pl.Id == request.Id, cancellationToken: cancellationToken);
            await _profileLessonBusinessRules.ProfileLessonShouldExistWhenSelected(profileLesson);

            GetByIdProfileLessonResponse response = _mapper.Map<GetByIdProfileLessonResponse>(profileLesson);
            return response;
        }
    }
}