using Application.Features.ProfileLessons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProfileLessons.Commands.Update;

public class UpdateProfileLessonCommand : IRequest<UpdatedProfileLessonResponse>
{
    //public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int AsyncLessonId { get; set; }
    public bool IsWatched { get; set; }

    public class UpdateProfileLessonCommandHandler : IRequestHandler<UpdateProfileLessonCommand, UpdatedProfileLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileLessonRepository _profileLessonRepository;
        private readonly ProfileLessonBusinessRules _profileLessonBusinessRules;

        public UpdateProfileLessonCommandHandler(IMapper mapper, IProfileLessonRepository profileLessonRepository,
                                         ProfileLessonBusinessRules profileLessonBusinessRules)
        {
            _mapper = mapper;
            _profileLessonRepository = profileLessonRepository;
            _profileLessonBusinessRules = profileLessonBusinessRules;
        }

        public async Task<UpdatedProfileLessonResponse> Handle(UpdateProfileLessonCommand request, CancellationToken cancellationToken)
        {
            ProfileLesson? profileLesson = await _profileLessonRepository.GetAsync(predicate: pl => pl.UserProfileId == request.UserProfileId && pl.AsyncLessonId == request.AsyncLessonId,
                                cancellationToken: cancellationToken);

            //await _profileLessonBusinessRules.ProfileLessonShouldExistWhenSelected(profileLesson);
            if(profileLesson == null)
            {
                profileLesson = new ProfileLesson
                {
                    UserProfileId = request.UserProfileId,
                    AsyncLessonId = request.AsyncLessonId,
                    IsWatched = request.IsWatched
                };
                await _profileLessonRepository.AddAsync(profileLesson);

            }
            else
            {
                profileLesson.IsWatched = request.IsWatched;
                await _profileLessonRepository.UpdateAsync(profileLesson!);
            }
            //profileLesson = _mapper.Map(request, profileLesson);

            UpdatedProfileLessonResponse response = _mapper.Map<UpdatedProfileLessonResponse>(profileLesson);
            return response;
        }
    }
}