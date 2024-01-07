using Application.Features.EducationAboutCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.EducationAboutCategories.Commands.Update;

public class UpdateEducationAboutCategoryCommand : IRequest<UpdatedEducationAboutCategoryResponse>
{
    public int Id { get; set; }
    public string Name { get; set; }

    public class UpdateEducationAboutCategoryCommandHandler : IRequestHandler<UpdateEducationAboutCategoryCommand, UpdatedEducationAboutCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEducationAboutCategoryRepository _educationAboutCategoryRepository;
        private readonly EducationAboutCategoryBusinessRules _educationAboutCategoryBusinessRules;

        public UpdateEducationAboutCategoryCommandHandler(IMapper mapper, IEducationAboutCategoryRepository educationAboutCategoryRepository,
                                         EducationAboutCategoryBusinessRules educationAboutCategoryBusinessRules)
        {
            _mapper = mapper;
            _educationAboutCategoryRepository = educationAboutCategoryRepository;
            _educationAboutCategoryBusinessRules = educationAboutCategoryBusinessRules;
        }

        public async Task<UpdatedEducationAboutCategoryResponse> Handle(UpdateEducationAboutCategoryCommand request, CancellationToken cancellationToken)
        {
            EducationAboutCategory? educationAboutCategory = await _educationAboutCategoryRepository.GetAsync(predicate: eac => eac.Id == request.Id, cancellationToken: cancellationToken);
            await _educationAboutCategoryBusinessRules.EducationAboutCategoryShouldExistWhenSelected(educationAboutCategory);
            educationAboutCategory = _mapper.Map(request, educationAboutCategory);

            await _educationAboutCategoryRepository.UpdateAsync(educationAboutCategory!);

            UpdatedEducationAboutCategoryResponse response = _mapper.Map<UpdatedEducationAboutCategoryResponse>(educationAboutCategory);
            return response;
        }
    }
}