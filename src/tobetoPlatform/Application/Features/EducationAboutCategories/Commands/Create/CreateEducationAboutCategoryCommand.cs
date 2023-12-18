using Application.Features.EducationAboutCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.EducationAboutCategories.Commands.Create;

public class CreateEducationAboutCategoryCommand : IRequest<CreatedEducationAboutCategoryResponse>
{
    public string Name { get; set; }

    public class CreateEducationAboutCategoryCommandHandler : IRequestHandler<CreateEducationAboutCategoryCommand, CreatedEducationAboutCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEducationAboutCategoryRepository _educationAboutCategoryRepository;
        private readonly EducationAboutCategoryBusinessRules _educationAboutCategoryBusinessRules;

        public CreateEducationAboutCategoryCommandHandler(IMapper mapper, IEducationAboutCategoryRepository educationAboutCategoryRepository,
                                         EducationAboutCategoryBusinessRules educationAboutCategoryBusinessRules)
        {
            _mapper = mapper;
            _educationAboutCategoryRepository = educationAboutCategoryRepository;
            _educationAboutCategoryBusinessRules = educationAboutCategoryBusinessRules;
        }

        public async Task<CreatedEducationAboutCategoryResponse> Handle(CreateEducationAboutCategoryCommand request, CancellationToken cancellationToken)
        {
            EducationAboutCategory educationAboutCategory = _mapper.Map<EducationAboutCategory>(request);

            await _educationAboutCategoryRepository.AddAsync(educationAboutCategory);

            CreatedEducationAboutCategoryResponse response = _mapper.Map<CreatedEducationAboutCategoryResponse>(educationAboutCategory);
            return response;
        }
    }
}