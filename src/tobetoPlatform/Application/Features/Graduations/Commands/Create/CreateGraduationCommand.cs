using Application.Features.Experiences.Constants;
using Application.Features.Graduations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Graduations.Commands.Create;

public class CreateGraduationCommand : IRequest<CreatedGraduationResponse>
{
    public string UserProfileId { get; set; }
    public string Degree { get; set; }
    public string UniversityName { get; set; }
    public string Department { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime GraduationDate { get; set; }

    public class CreateGraduationCommandHandler : IRequestHandler<CreateGraduationCommand, CreatedGraduationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGraduationRepository _graduationRepository;
        private readonly GraduationBusinessRules _graduationBusinessRules;

        public CreateGraduationCommandHandler(IMapper mapper, IGraduationRepository graduationRepository,
                                         GraduationBusinessRules graduationBusinessRules)
        {
            _mapper = mapper;
            _graduationRepository = graduationRepository;
            _graduationBusinessRules = graduationBusinessRules;
        }

        public async Task<CreatedGraduationResponse> Handle(CreateGraduationCommand request, CancellationToken cancellationToken)
        {
            Graduation graduation = _mapper.Map<Graduation>(request);

            await _graduationRepository.AddAsync(graduation);

            CreatedGraduationResponse response = _mapper.Map<CreatedGraduationResponse>(graduation);
            response.Message = ExperiencesValidationMessages.ExperienceSuccessfullyAdded;
            return response;
        }
    }
}