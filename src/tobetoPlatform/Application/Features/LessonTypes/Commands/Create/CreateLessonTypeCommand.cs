using Application.Features.LessonTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.LessonTypes.Commands.Create;

public class CreateLessonTypeCommand : IRequest<CreatedLessonTypeResponse>
{
    public string Name { get; set; }

    public class CreateLessonTypeCommandHandler : IRequestHandler<CreateLessonTypeCommand, CreatedLessonTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILessonTypeRepository _lessonTypeRepository;
        private readonly LessonTypeBusinessRules _lessonTypeBusinessRules;

        public CreateLessonTypeCommandHandler(IMapper mapper, ILessonTypeRepository lessonTypeRepository,
                                         LessonTypeBusinessRules lessonTypeBusinessRules)
        {
            _mapper = mapper;
            _lessonTypeRepository = lessonTypeRepository;
            _lessonTypeBusinessRules = lessonTypeBusinessRules;
        }

        public async Task<CreatedLessonTypeResponse> Handle(CreateLessonTypeCommand request, CancellationToken cancellationToken)
        {
            LessonType lessonType = _mapper.Map<LessonType>(request);

            await _lessonTypeRepository.AddAsync(lessonType);

            CreatedLessonTypeResponse response = _mapper.Map<CreatedLessonTypeResponse>(lessonType);
            return response;
        }
    }
}