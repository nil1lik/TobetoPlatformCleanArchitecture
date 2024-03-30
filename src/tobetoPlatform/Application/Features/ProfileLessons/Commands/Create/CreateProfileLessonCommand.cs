using Application.Features.ProfileLessons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProfileLessons.Commands.Create;

public class CreateProfileLessonCommand : IRequest<CreatedProfileLessonResponse>
{
    public int UserProfileId { get; set; }
    public int AsyncLessonId { get; set; }
    public bool IsWatched { get; set; }

    public class CreateProfileLessonCommandHandler : IRequestHandler<CreateProfileLessonCommand, CreatedProfileLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileLessonRepository _profileLessonRepository;
        private readonly ProfileLessonBusinessRules _profileLessonBusinessRules;

        public CreateProfileLessonCommandHandler(IMapper mapper, IProfileLessonRepository profileLessonRepository,
                                         ProfileLessonBusinessRules profileLessonBusinessRules)
        {
            _mapper = mapper;
            _profileLessonRepository = profileLessonRepository;
            _profileLessonBusinessRules = profileLessonBusinessRules;
        }

        public async Task<CreatedProfileLessonResponse> Handle(CreateProfileLessonCommand request, CancellationToken cancellationToken)
        {
            ProfileLesson profileLesson = _mapper.Map<ProfileLesson>(request);

            await _profileLessonRepository.AddAsync(profileLesson);

            CreatedProfileLessonResponse response = _mapper.Map<CreatedProfileLessonResponse>(profileLesson);
            return response;
        }
    }
}