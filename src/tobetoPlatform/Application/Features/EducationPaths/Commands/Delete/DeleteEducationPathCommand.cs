using Application.Features.EducationPaths.Constants;
using Application.Features.EducationPaths.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.EducationPaths.Commands.Delete;

public class DeleteEducationPathCommand : IRequest<DeletedEducationPathResponse>
{
    public int Id { get; set; }

    public class DeleteEducationPathCommandHandler : IRequestHandler<DeleteEducationPathCommand, DeletedEducationPathResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEducationPathRepository _educationPathRepository;
        private readonly EducationPathBusinessRules _educationPathBusinessRules;

        public DeleteEducationPathCommandHandler(IMapper mapper, IEducationPathRepository educationPathRepository,
                                         EducationPathBusinessRules educationPathBusinessRules)
        {
            _mapper = mapper;
            _educationPathRepository = educationPathRepository;
            _educationPathBusinessRules = educationPathBusinessRules;
        }

        public async Task<DeletedEducationPathResponse> Handle(DeleteEducationPathCommand request, CancellationToken cancellationToken)
        {
            EducationPath? educationPath = await _educationPathRepository.GetAsync(predicate: ep => ep.Id == request.Id, cancellationToken: cancellationToken);
            await _educationPathBusinessRules.EducationPathShouldExistWhenSelected(educationPath);

            await _educationPathRepository.DeleteAsync(educationPath!);

            DeletedEducationPathResponse response = _mapper.Map<DeletedEducationPathResponse>(educationPath);
            return response;
        }
    }
}