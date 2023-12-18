using Application.Features.EducationAbouts.Constants;
using Application.Features.EducationAbouts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.EducationAbouts.Commands.Delete;

public class DeleteEducationAboutCommand : IRequest<DeletedEducationAboutResponse>
{
    public int Id { get; set; }

    public class DeleteEducationAboutCommandHandler : IRequestHandler<DeleteEducationAboutCommand, DeletedEducationAboutResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEducationAboutRepository _educationAboutRepository;
        private readonly EducationAboutBusinessRules _educationAboutBusinessRules;

        public DeleteEducationAboutCommandHandler(IMapper mapper, IEducationAboutRepository educationAboutRepository,
                                         EducationAboutBusinessRules educationAboutBusinessRules)
        {
            _mapper = mapper;
            _educationAboutRepository = educationAboutRepository;
            _educationAboutBusinessRules = educationAboutBusinessRules;
        }

        public async Task<DeletedEducationAboutResponse> Handle(DeleteEducationAboutCommand request, CancellationToken cancellationToken)
        {
            EducationAbout? educationAbout = await _educationAboutRepository.GetAsync(predicate: ea => ea.Id == request.Id, cancellationToken: cancellationToken);
            await _educationAboutBusinessRules.EducationAboutShouldExistWhenSelected(educationAbout);

            await _educationAboutRepository.DeleteAsync(educationAbout!);

            DeletedEducationAboutResponse response = _mapper.Map<DeletedEducationAboutResponse>(educationAbout);
            return response;
        }
    }
}