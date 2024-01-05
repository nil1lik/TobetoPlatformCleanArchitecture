using Application.Features.EducationAbouts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.EducationAbouts.Commands.Update;

public class UpdateEducationAboutCommand : IRequest<UpdatedEducationAboutResponse>
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public int EducationAboutCategoryId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public class UpdateEducationAboutCommandHandler : IRequestHandler<UpdateEducationAboutCommand, UpdatedEducationAboutResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEducationAboutRepository _educationAboutRepository;
        private readonly EducationAboutBusinessRules _educationAboutBusinessRules;

        public UpdateEducationAboutCommandHandler(IMapper mapper, IEducationAboutRepository educationAboutRepository,
                                         EducationAboutBusinessRules educationAboutBusinessRules)
        {
            _mapper = mapper;
            _educationAboutRepository = educationAboutRepository;
            _educationAboutBusinessRules = educationAboutBusinessRules;
        }

        public async Task<UpdatedEducationAboutResponse> Handle(UpdateEducationAboutCommand request, CancellationToken cancellationToken)
        {
            EducationAbout? educationAbout = await _educationAboutRepository.GetAsync(predicate: ea => ea.Id == request.Id, cancellationToken: cancellationToken);
            await _educationAboutBusinessRules.EducationAboutShouldExistWhenSelected(educationAbout);
            educationAbout = _mapper.Map(request, educationAbout);

            await _educationAboutRepository.UpdateAsync(educationAbout!);

            UpdatedEducationAboutResponse response = _mapper.Map<UpdatedEducationAboutResponse>(educationAbout);
            return response;
        }
    }
}