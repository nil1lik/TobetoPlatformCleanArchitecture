using Application.Features.EducationPaths.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.EducationPaths.Commands.Create;

public class CreateEducationPathCommand : IRequest<CreatedEducationPathResponse>
{
    public int EducationAdmirationId { get; set; }
    public int EducationAboutId { get; set; }
    public int TimeSpentId { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }

    public class CreateEducationPathCommandHandler : IRequestHandler<CreateEducationPathCommand, CreatedEducationPathResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEducationPathRepository _educationPathRepository;
        private readonly EducationPathBusinessRules _educationPathBusinessRules;

        public CreateEducationPathCommandHandler(IMapper mapper, IEducationPathRepository educationPathRepository,
                                         EducationPathBusinessRules educationPathBusinessRules)
        {
            _mapper = mapper;
            _educationPathRepository = educationPathRepository;
            _educationPathBusinessRules = educationPathBusinessRules;
        }

        public async Task<CreatedEducationPathResponse> Handle(CreateEducationPathCommand request, CancellationToken cancellationToken)
        {
            EducationPath educationPath = _mapper.Map<EducationPath>(request);

            await _educationPathRepository.AddAsync(educationPath);

            CreatedEducationPathResponse response = _mapper.Map<CreatedEducationPathResponse>(educationPath);
            return response;
        }
    }
}