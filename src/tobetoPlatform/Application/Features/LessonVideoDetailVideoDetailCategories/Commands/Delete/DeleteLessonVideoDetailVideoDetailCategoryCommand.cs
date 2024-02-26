using Application.Features.LessonVideoDetailVideoDetailCategories.Constants;
using Application.Features.LessonVideoDetailVideoDetailCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.LessonVideoDetailVideoDetailCategories.Commands.Delete;

public class DeleteLessonVideoDetailVideoDetailCategoryCommand : IRequest<DeletedLessonVideoDetailVideoDetailCategoryResponse>
{
    public int Id { get; set; }

    public class DeleteLessonVideoDetailVideoDetailCategoryCommandHandler : IRequestHandler<DeleteLessonVideoDetailVideoDetailCategoryCommand, DeletedLessonVideoDetailVideoDetailCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILessonVideoDetailVideoDetailCategoryRepository _lessonVideoDetailVideoDetailCategoryRepository;
        private readonly LessonVideoDetailVideoDetailCategoryBusinessRules _lessonVideoDetailVideoDetailCategoryBusinessRules;

        public DeleteLessonVideoDetailVideoDetailCategoryCommandHandler(IMapper mapper, ILessonVideoDetailVideoDetailCategoryRepository lessonVideoDetailVideoDetailCategoryRepository,
                                         LessonVideoDetailVideoDetailCategoryBusinessRules lessonVideoDetailVideoDetailCategoryBusinessRules)
        {
            _mapper = mapper;
            _lessonVideoDetailVideoDetailCategoryRepository = lessonVideoDetailVideoDetailCategoryRepository;
            _lessonVideoDetailVideoDetailCategoryBusinessRules = lessonVideoDetailVideoDetailCategoryBusinessRules;
        }

        public async Task<DeletedLessonVideoDetailVideoDetailCategoryResponse> Handle(DeleteLessonVideoDetailVideoDetailCategoryCommand request, CancellationToken cancellationToken)
        {
            LessonVideoDetailVideoDetailCategory? lessonVideoDetailVideoDetailCategory = await _lessonVideoDetailVideoDetailCategoryRepository.GetAsync(predicate: lvdvdc => lvdvdc.Id == request.Id, cancellationToken: cancellationToken);
            await _lessonVideoDetailVideoDetailCategoryBusinessRules.LessonVideoDetailVideoDetailCategoryShouldExistWhenSelected(lessonVideoDetailVideoDetailCategory);

            await _lessonVideoDetailVideoDetailCategoryRepository.DeleteAsync(lessonVideoDetailVideoDetailCategory!);

            DeletedLessonVideoDetailVideoDetailCategoryResponse response = _mapper.Map<DeletedLessonVideoDetailVideoDetailCategoryResponse>(lessonVideoDetailVideoDetailCategory);
            return response;
        }
    }
}