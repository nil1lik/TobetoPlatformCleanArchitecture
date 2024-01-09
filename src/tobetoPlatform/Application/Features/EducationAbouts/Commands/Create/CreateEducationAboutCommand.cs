using Application.Features.EducationAbouts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.EducationAbouts.Commands.Create;

public class CreateEducationAboutCommand : IRequest<CreatedEducationAboutResponse>
{
    public int CompanyId { get; set; }
    public int EducationAboutCategoryId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public class CreateEducationAboutCommandHandler : IRequestHandler<CreateEducationAboutCommand, CreatedEducationAboutResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEducationAboutRepository _educationAboutRepository;
        private readonly EducationAboutBusinessRules _educationAboutBusinessRules;

        public CreateEducationAboutCommandHandler(IMapper mapper, IEducationAboutRepository educationAboutRepository,
                                         EducationAboutBusinessRules educationAboutBusinessRules)
        {
            _mapper = mapper;
            _educationAboutRepository = educationAboutRepository;
            _educationAboutBusinessRules = educationAboutBusinessRules;
        }

        public async Task<CreatedEducationAboutResponse> Handle(CreateEducationAboutCommand request, CancellationToken cancellationToken)
        {
            EducationAbout educationAbout = _mapper.Map<EducationAbout>(request);

            await _educationAboutRepository.AddAsync(educationAbout);

            CreatedEducationAboutResponse response = _mapper.Map<CreatedEducationAboutResponse>(educationAbout);
            return response;
        }
    }
}