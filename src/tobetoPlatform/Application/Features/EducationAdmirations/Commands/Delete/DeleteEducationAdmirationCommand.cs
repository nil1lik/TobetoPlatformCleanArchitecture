using Application.Features.EducationAdmirations.Constants;
using Application.Features.EducationAdmirations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.EducationAdmirations.Commands.Delete;

public class DeleteEducationAdmirationCommand : IRequest<DeletedEducationAdmirationResponse>
{
    public int Id { get; set; }

    public class DeleteEducationAdmirationCommandHandler : IRequestHandler<DeleteEducationAdmirationCommand, DeletedEducationAdmirationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEducationAdmirationRepository _educationAdmirationRepository;
        private readonly EducationAdmirationBusinessRules _educationAdmirationBusinessRules;

        public DeleteEducationAdmirationCommandHandler(IMapper mapper, IEducationAdmirationRepository educationAdmirationRepository,
                                         EducationAdmirationBusinessRules educationAdmirationBusinessRules)
        {
            _mapper = mapper;
            _educationAdmirationRepository = educationAdmirationRepository;
            _educationAdmirationBusinessRules = educationAdmirationBusinessRules;
        }

        public async Task<DeletedEducationAdmirationResponse> Handle(DeleteEducationAdmirationCommand request, CancellationToken cancellationToken)
        {
            EducationAdmiration? educationAdmiration = await _educationAdmirationRepository.GetAsync(predicate: ea => ea.Id == request.Id, cancellationToken: cancellationToken);
            await _educationAdmirationBusinessRules.EducationAdmirationShouldExistWhenSelected(educationAdmiration);

            await _educationAdmirationRepository.DeleteAsync(educationAdmiration!);

            DeletedEducationAdmirationResponse response = _mapper.Map<DeletedEducationAdmirationResponse>(educationAdmiration);
            return response;
        }
    }
}