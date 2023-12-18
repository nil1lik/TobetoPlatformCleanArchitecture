using Application.Features.EducationAdmirations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.EducationAdmirations.Commands.Update;

public class UpdateEducationAdmirationCommand : IRequest<UpdatedEducationAdmirationResponse>
{
    public int Id { get; set; }
    public bool IsLiked { get; set; }
    public bool IsFavourited { get; set; }
    public double CompletionRate { get; set; }
    public double EducationPoint { get; set; }

    public class UpdateEducationAdmirationCommandHandler : IRequestHandler<UpdateEducationAdmirationCommand, UpdatedEducationAdmirationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEducationAdmirationRepository _educationAdmirationRepository;
        private readonly EducationAdmirationBusinessRules _educationAdmirationBusinessRules;

        public UpdateEducationAdmirationCommandHandler(IMapper mapper, IEducationAdmirationRepository educationAdmirationRepository,
                                         EducationAdmirationBusinessRules educationAdmirationBusinessRules)
        {
            _mapper = mapper;
            _educationAdmirationRepository = educationAdmirationRepository;
            _educationAdmirationBusinessRules = educationAdmirationBusinessRules;
        }

        public async Task<UpdatedEducationAdmirationResponse> Handle(UpdateEducationAdmirationCommand request, CancellationToken cancellationToken)
        {
            EducationAdmiration? educationAdmiration = await _educationAdmirationRepository.GetAsync(predicate: ea => ea.Id == request.Id, cancellationToken: cancellationToken);
            await _educationAdmirationBusinessRules.EducationAdmirationShouldExistWhenSelected(educationAdmiration);
            educationAdmiration = _mapper.Map(request, educationAdmiration);

            await _educationAdmirationRepository.UpdateAsync(educationAdmiration!);

            UpdatedEducationAdmirationResponse response = _mapper.Map<UpdatedEducationAdmirationResponse>(educationAdmiration);
            return response;
        }
    }
}