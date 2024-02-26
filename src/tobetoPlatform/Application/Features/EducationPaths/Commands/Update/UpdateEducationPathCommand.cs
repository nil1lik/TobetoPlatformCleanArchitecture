using Application.Features.EducationPaths.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.EducationPaths.Commands.Update;

public class UpdateEducationPathCommand : IRequest<UpdatedEducationPathResponse>
{
    public int Id { get; set; }
    public int EducationAdmirationId { get; set; }
    public int EducationAboutId { get; set; }
    public int TimeSpentId { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }

    public class UpdateEducationPathCommandHandler : IRequestHandler<UpdateEducationPathCommand, UpdatedEducationPathResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEducationPathRepository _educationPathRepository;
        private readonly EducationPathBusinessRules _educationPathBusinessRules;

        public UpdateEducationPathCommandHandler(IMapper mapper, IEducationPathRepository educationPathRepository,
                                         EducationPathBusinessRules educationPathBusinessRules)
        {
            _mapper = mapper;
            _educationPathRepository = educationPathRepository;
            _educationPathBusinessRules = educationPathBusinessRules;
        }

        public async Task<UpdatedEducationPathResponse> Handle(UpdateEducationPathCommand request, CancellationToken cancellationToken)
        {
            EducationPath? educationPath = await _educationPathRepository.GetAsync(predicate: ep => ep.Id == request.Id, cancellationToken: cancellationToken);
            await _educationPathBusinessRules.EducationPathShouldExistWhenSelected(educationPath);
            educationPath = _mapper.Map(request, educationPath);

            await _educationPathRepository.UpdateAsync(educationPath!);

            UpdatedEducationPathResponse response = _mapper.Map<UpdatedEducationPathResponse>(educationPath);
            return response;
        }
    }
}