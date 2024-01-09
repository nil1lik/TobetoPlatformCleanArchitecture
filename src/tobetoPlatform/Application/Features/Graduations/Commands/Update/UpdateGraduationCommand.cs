using Application.Features.Graduations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Graduations.Commands.Update;

public class UpdateGraduationCommand : IRequest<UpdatedGraduationResponse>
{
    public int Id { get; set; }
    public string Degree { get; set; }
    public string UniversityName { get; set; }
    public string Department { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime GraduationDate { get; set; }

    public class UpdateGraduationCommandHandler : IRequestHandler<UpdateGraduationCommand, UpdatedGraduationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGraduationRepository _graduationRepository;
        private readonly GraduationBusinessRules _graduationBusinessRules;

        public UpdateGraduationCommandHandler(IMapper mapper, IGraduationRepository graduationRepository,
                                         GraduationBusinessRules graduationBusinessRules)
        {
            _mapper = mapper;
            _graduationRepository = graduationRepository;
            _graduationBusinessRules = graduationBusinessRules;
        }

        public async Task<UpdatedGraduationResponse> Handle(UpdateGraduationCommand request, CancellationToken cancellationToken)
        {
            Graduation? graduation = await _graduationRepository.GetAsync(predicate: g => g.Id == request.Id, cancellationToken: cancellationToken);
            await _graduationBusinessRules.GraduationShouldExistWhenSelected(graduation);
            graduation = _mapper.Map(request, graduation);

            await _graduationRepository.UpdateAsync(graduation!);

            UpdatedGraduationResponse response = _mapper.Map<UpdatedGraduationResponse>(graduation);
            return response;
        }
    }
}