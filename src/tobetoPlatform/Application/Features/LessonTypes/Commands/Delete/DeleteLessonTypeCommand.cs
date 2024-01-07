using Application.Features.LessonTypes.Constants;
using Application.Features.LessonTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.LessonTypes.Commands.Delete;

public class DeleteLessonTypeCommand : IRequest<DeletedLessonTypeResponse>
{
    public int Id { get; set; }

    public class DeleteLessonTypeCommandHandler : IRequestHandler<DeleteLessonTypeCommand, DeletedLessonTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILessonTypeRepository _lessonTypeRepository;
        private readonly LessonTypeBusinessRules _lessonTypeBusinessRules;

        public DeleteLessonTypeCommandHandler(IMapper mapper, ILessonTypeRepository lessonTypeRepository,
                                         LessonTypeBusinessRules lessonTypeBusinessRules)
        {
            _mapper = mapper;
            _lessonTypeRepository = lessonTypeRepository;
            _lessonTypeBusinessRules = lessonTypeBusinessRules;
        }

        public async Task<DeletedLessonTypeResponse> Handle(DeleteLessonTypeCommand request, CancellationToken cancellationToken)
        {
            LessonType? lessonType = await _lessonTypeRepository.GetAsync(predicate: lt => lt.Id == request.Id, cancellationToken: cancellationToken);
            await _lessonTypeBusinessRules.LessonTypeShouldExistWhenSelected(lessonType);

            await _lessonTypeRepository.DeleteAsync(lessonType!);

            DeletedLessonTypeResponse response = _mapper.Map<DeletedLessonTypeResponse>(lessonType);
            return response;
        }
    }
}