using Application.Features.LessonVideoDetailVideoDetailCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.LessonVideoDetailVideoDetailCategories.Commands.Create;

public class CreateLessonVideoDetailVideoDetailCategoryCommand : IRequest<CreatedLessonVideoDetailVideoDetailCategoryResponse>
{
    public int LessonVideoDetailId { get; set; }
    public int VideoDetailCategoryId { get; set; }

    public class CreateLessonVideoDetailVideoDetailCategoryCommandHandler : IRequestHandler<CreateLessonVideoDetailVideoDetailCategoryCommand, CreatedLessonVideoDetailVideoDetailCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILessonVideoDetailVideoDetailCategoryRepository _lessonVideoDetailVideoDetailCategoryRepository;
        private readonly LessonVideoDetailVideoDetailCategoryBusinessRules _lessonVideoDetailVideoDetailCategoryBusinessRules;

        public CreateLessonVideoDetailVideoDetailCategoryCommandHandler(IMapper mapper, ILessonVideoDetailVideoDetailCategoryRepository lessonVideoDetailVideoDetailCategoryRepository,
                                         LessonVideoDetailVideoDetailCategoryBusinessRules lessonVideoDetailVideoDetailCategoryBusinessRules)
        {
            _mapper = mapper;
            _lessonVideoDetailVideoDetailCategoryRepository = lessonVideoDetailVideoDetailCategoryRepository;
            _lessonVideoDetailVideoDetailCategoryBusinessRules = lessonVideoDetailVideoDetailCategoryBusinessRules;
        }

        public async Task<CreatedLessonVideoDetailVideoDetailCategoryResponse> Handle(CreateLessonVideoDetailVideoDetailCategoryCommand request, CancellationToken cancellationToken)
        {
            LessonVideoDetailVideoDetailCategory lessonVideoDetailVideoDetailCategory = _mapper.Map<LessonVideoDetailVideoDetailCategory>(request);

            await _lessonVideoDetailVideoDetailCategoryRepository.AddAsync(lessonVideoDetailVideoDetailCategory);

            CreatedLessonVideoDetailVideoDetailCategoryResponse response = _mapper.Map<CreatedLessonVideoDetailVideoDetailCategoryResponse>(lessonVideoDetailVideoDetailCategory);
            return response;
        }
    }
}