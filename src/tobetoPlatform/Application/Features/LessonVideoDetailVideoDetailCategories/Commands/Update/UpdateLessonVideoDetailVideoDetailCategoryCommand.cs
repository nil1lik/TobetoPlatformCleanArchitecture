using Application.Features.LessonVideoDetailVideoDetailCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.LessonVideoDetailVideoDetailCategories.Commands.Update;

public class UpdateLessonVideoDetailVideoDetailCategoryCommand : IRequest<UpdatedLessonVideoDetailVideoDetailCategoryResponse>
{
    public int Id { get; set; }
    public int LessonVideoDetailId { get; set; }
    public int VideoDetailCategoryId { get; set; }

    public class UpdateLessonVideoDetailVideoDetailCategoryCommandHandler : IRequestHandler<UpdateLessonVideoDetailVideoDetailCategoryCommand, UpdatedLessonVideoDetailVideoDetailCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILessonVideoDetailVideoDetailCategoryRepository _lessonVideoDetailVideoDetailCategoryRepository;
        private readonly LessonVideoDetailVideoDetailCategoryBusinessRules _lessonVideoDetailVideoDetailCategoryBusinessRules;

        public UpdateLessonVideoDetailVideoDetailCategoryCommandHandler(IMapper mapper, ILessonVideoDetailVideoDetailCategoryRepository lessonVideoDetailVideoDetailCategoryRepository,
                                         LessonVideoDetailVideoDetailCategoryBusinessRules lessonVideoDetailVideoDetailCategoryBusinessRules)
        {
            _mapper = mapper;
            _lessonVideoDetailVideoDetailCategoryRepository = lessonVideoDetailVideoDetailCategoryRepository;
            _lessonVideoDetailVideoDetailCategoryBusinessRules = lessonVideoDetailVideoDetailCategoryBusinessRules;
        }

        public async Task<UpdatedLessonVideoDetailVideoDetailCategoryResponse> Handle(UpdateLessonVideoDetailVideoDetailCategoryCommand request, CancellationToken cancellationToken)
        {
            LessonVideoDetailVideoDetailCategory? lessonVideoDetailVideoDetailCategory = await _lessonVideoDetailVideoDetailCategoryRepository.GetAsync(predicate: lvdvdc => lvdvdc.Id == request.Id, cancellationToken: cancellationToken);
            await _lessonVideoDetailVideoDetailCategoryBusinessRules.LessonVideoDetailVideoDetailCategoryShouldExistWhenSelected(lessonVideoDetailVideoDetailCategory);
            lessonVideoDetailVideoDetailCategory = _mapper.Map(request, lessonVideoDetailVideoDetailCategory);

            await _lessonVideoDetailVideoDetailCategoryRepository.UpdateAsync(lessonVideoDetailVideoDetailCategory!);

            UpdatedLessonVideoDetailVideoDetailCategoryResponse response = _mapper.Map<UpdatedLessonVideoDetailVideoDetailCategoryResponse>(lessonVideoDetailVideoDetailCategory);
            return response;
        }
    }
}