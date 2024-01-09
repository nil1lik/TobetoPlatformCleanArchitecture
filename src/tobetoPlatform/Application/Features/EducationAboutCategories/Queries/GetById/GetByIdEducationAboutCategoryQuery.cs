using Application.Features.EducationAboutCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.EducationAboutCategories.Queries.GetById;

public class GetByIdEducationAboutCategoryQuery : IRequest<GetByIdEducationAboutCategoryResponse>
{
    public int Id { get; set; }

    public class GetByIdEducationAboutCategoryQueryHandler : IRequestHandler<GetByIdEducationAboutCategoryQuery, GetByIdEducationAboutCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEducationAboutCategoryRepository _educationAboutCategoryRepository;
        private readonly EducationAboutCategoryBusinessRules _educationAboutCategoryBusinessRules;

        public GetByIdEducationAboutCategoryQueryHandler(IMapper mapper, IEducationAboutCategoryRepository educationAboutCategoryRepository, EducationAboutCategoryBusinessRules educationAboutCategoryBusinessRules)
        {
            _mapper = mapper;
            _educationAboutCategoryRepository = educationAboutCategoryRepository;
            _educationAboutCategoryBusinessRules = educationAboutCategoryBusinessRules;
        }

        public async Task<GetByIdEducationAboutCategoryResponse> Handle(GetByIdEducationAboutCategoryQuery request, CancellationToken cancellationToken)
        {
            EducationAboutCategory? educationAboutCategory = await _educationAboutCategoryRepository.GetAsync(predicate: eac => eac.Id == request.Id, cancellationToken: cancellationToken);
            await _educationAboutCategoryBusinessRules.EducationAboutCategoryShouldExistWhenSelected(educationAboutCategory);

            GetByIdEducationAboutCategoryResponse response = _mapper.Map<GetByIdEducationAboutCategoryResponse>(educationAboutCategory);
            return response;
        }
    }
}