using Application.Features.LessonVideoDetailVideoDetailCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.LessonVideoDetailVideoDetailCategories.Queries.GetById;

public class GetByIdLessonVideoDetailVideoDetailCategoryQuery : IRequest<GetByIdLessonVideoDetailVideoDetailCategoryResponse>
{
    public int Id { get; set; }

    public class GetByIdLessonVideoDetailVideoDetailCategoryQueryHandler : IRequestHandler<GetByIdLessonVideoDetailVideoDetailCategoryQuery, GetByIdLessonVideoDetailVideoDetailCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILessonVideoDetailVideoDetailCategoryRepository _lessonVideoDetailVideoDetailCategoryRepository;
        private readonly LessonVideoDetailVideoDetailCategoryBusinessRules _lessonVideoDetailVideoDetailCategoryBusinessRules;

        public GetByIdLessonVideoDetailVideoDetailCategoryQueryHandler(IMapper mapper, ILessonVideoDetailVideoDetailCategoryRepository lessonVideoDetailVideoDetailCategoryRepository, LessonVideoDetailVideoDetailCategoryBusinessRules lessonVideoDetailVideoDetailCategoryBusinessRules)
        {
            _mapper = mapper;
            _lessonVideoDetailVideoDetailCategoryRepository = lessonVideoDetailVideoDetailCategoryRepository;
            _lessonVideoDetailVideoDetailCategoryBusinessRules = lessonVideoDetailVideoDetailCategoryBusinessRules;
        }

        public async Task<GetByIdLessonVideoDetailVideoDetailCategoryResponse> Handle(GetByIdLessonVideoDetailVideoDetailCategoryQuery request, CancellationToken cancellationToken)
        {
            LessonVideoDetailVideoDetailCategory? lessonVideoDetailVideoDetailCategory = await _lessonVideoDetailVideoDetailCategoryRepository.GetAsync(predicate: lvdvdc => lvdvdc.Id == request.Id, cancellationToken: cancellationToken);
            await _lessonVideoDetailVideoDetailCategoryBusinessRules.LessonVideoDetailVideoDetailCategoryShouldExistWhenSelected(lessonVideoDetailVideoDetailCategory);

            GetByIdLessonVideoDetailVideoDetailCategoryResponse response = _mapper.Map<GetByIdLessonVideoDetailVideoDetailCategoryResponse>(lessonVideoDetailVideoDetailCategory);
            return response;
        }
    }
}