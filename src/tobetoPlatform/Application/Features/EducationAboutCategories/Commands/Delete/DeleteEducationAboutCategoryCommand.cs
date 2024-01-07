using Application.Features.EducationAboutCategories.Constants;
using Application.Features.EducationAboutCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.EducationAboutCategories.Commands.Delete;

public class DeleteEducationAboutCategoryCommand : IRequest<DeletedEducationAboutCategoryResponse>
{
    public int Id { get; set; }

    public class DeleteEducationAboutCategoryCommandHandler : IRequestHandler<DeleteEducationAboutCategoryCommand, DeletedEducationAboutCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEducationAboutCategoryRepository _educationAboutCategoryRepository;
        private readonly EducationAboutCategoryBusinessRules _educationAboutCategoryBusinessRules;

        public DeleteEducationAboutCategoryCommandHandler(IMapper mapper, IEducationAboutCategoryRepository educationAboutCategoryRepository,
                                         EducationAboutCategoryBusinessRules educationAboutCategoryBusinessRules)
        {
            _mapper = mapper;
            _educationAboutCategoryRepository = educationAboutCategoryRepository;
            _educationAboutCategoryBusinessRules = educationAboutCategoryBusinessRules;
        }

        public async Task<DeletedEducationAboutCategoryResponse> Handle(DeleteEducationAboutCategoryCommand request, CancellationToken cancellationToken)
        {
            EducationAboutCategory? educationAboutCategory = await _educationAboutCategoryRepository.GetAsync(predicate: eac => eac.Id == request.Id, cancellationToken: cancellationToken);
            await _educationAboutCategoryBusinessRules.EducationAboutCategoryShouldExistWhenSelected(educationAboutCategory);

            await _educationAboutCategoryRepository.DeleteAsync(educationAboutCategory!);

            DeletedEducationAboutCategoryResponse response = _mapper.Map<DeletedEducationAboutCategoryResponse>(educationAboutCategory);
            return response;
        }
    }
}