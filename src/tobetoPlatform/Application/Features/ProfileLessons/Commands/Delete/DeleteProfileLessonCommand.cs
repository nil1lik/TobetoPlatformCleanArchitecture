using Application.Features.ProfileLessons.Constants;
using Application.Features.ProfileLessons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProfileLessons.Commands.Delete;

public class DeleteProfileLessonCommand : IRequest<DeletedProfileLessonResponse>
{
    public int Id { get; set; }

    public class DeleteProfileLessonCommandHandler : IRequestHandler<DeleteProfileLessonCommand, DeletedProfileLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileLessonRepository _profileLessonRepository;
        private readonly ProfileLessonBusinessRules _profileLessonBusinessRules;

        public DeleteProfileLessonCommandHandler(IMapper mapper, IProfileLessonRepository profileLessonRepository,
                                         ProfileLessonBusinessRules profileLessonBusinessRules)
        {
            _mapper = mapper;
            _profileLessonRepository = profileLessonRepository;
            _profileLessonBusinessRules = profileLessonBusinessRules;
        }

        public async Task<DeletedProfileLessonResponse> Handle(DeleteProfileLessonCommand request, CancellationToken cancellationToken)
        {
            ProfileLesson? profileLesson = await _profileLessonRepository.GetAsync(predicate: pl => pl.Id == request.Id, cancellationToken: cancellationToken);
            await _profileLessonBusinessRules.ProfileLessonShouldExistWhenSelected(profileLesson);

            await _profileLessonRepository.DeleteAsync(profileLesson!);

            DeletedProfileLessonResponse response = _mapper.Map<DeletedProfileLessonResponse>(profileLesson);
            return response;
        }
    }
}