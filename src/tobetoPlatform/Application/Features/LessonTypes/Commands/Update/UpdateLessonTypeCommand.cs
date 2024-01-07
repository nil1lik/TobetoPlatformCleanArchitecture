using Application.Features.LessonTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.LessonTypes.Commands.Update;

public class UpdateLessonTypeCommand : IRequest<UpdatedLessonTypeResponse>
{
    public int Id { get; set; }
    public string Name { get; set; }

    public class UpdateLessonTypeCommandHandler : IRequestHandler<UpdateLessonTypeCommand, UpdatedLessonTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILessonTypeRepository _lessonTypeRepository;
        private readonly LessonTypeBusinessRules _lessonTypeBusinessRules;

        public UpdateLessonTypeCommandHandler(IMapper mapper, ILessonTypeRepository lessonTypeRepository,
                                         LessonTypeBusinessRules lessonTypeBusinessRules)
        {
            _mapper = mapper;
            _lessonTypeRepository = lessonTypeRepository;
            _lessonTypeBusinessRules = lessonTypeBusinessRules;
        }

        public async Task<UpdatedLessonTypeResponse> Handle(UpdateLessonTypeCommand request, CancellationToken cancellationToken)
        {
            LessonType? lessonType = await _lessonTypeRepository.GetAsync(predicate: lt => lt.Id == request.Id, cancellationToken: cancellationToken);
            await _lessonTypeBusinessRules.LessonTypeShouldExistWhenSelected(lessonType);
            lessonType = _mapper.Map(request, lessonType);

            await _lessonTypeRepository.UpdateAsync(lessonType!);

            UpdatedLessonTypeResponse response = _mapper.Map<UpdatedLessonTypeResponse>(lessonType);
            return response;
        }
    }
}