using Application.Features.ApplicationForms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ApplicationForms.Commands.Update;

public class UpdateApplicationFormCommand : IRequest<UpdatedApplicationFormResponse>
{
    public int Id { get; set; }
    public int ProfileDocumentFormId { get; set; }
    public int ProfileApplicationFormId { get; set; }
    public string Name { get; set; }

    public class UpdateApplicationFormCommandHandler : IRequestHandler<UpdateApplicationFormCommand, UpdatedApplicationFormResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationFormRepository _applicationFormRepository;
        private readonly ApplicationFormBusinessRules _applicationFormBusinessRules;

        public UpdateApplicationFormCommandHandler(IMapper mapper, IApplicationFormRepository applicationFormRepository,
                                         ApplicationFormBusinessRules applicationFormBusinessRules)
        {
            _mapper = mapper;
            _applicationFormRepository = applicationFormRepository;
            _applicationFormBusinessRules = applicationFormBusinessRules;
        }

        public async Task<UpdatedApplicationFormResponse> Handle(UpdateApplicationFormCommand request, CancellationToken cancellationToken)
        {
            ApplicationForm? applicationForm = await _applicationFormRepository.GetAsync(predicate: af => af.Id == request.Id, cancellationToken: cancellationToken);
            await _applicationFormBusinessRules.ApplicationFormShouldExistWhenSelected(applicationForm);
            applicationForm = _mapper.Map(request, applicationForm);

            await _applicationFormRepository.UpdateAsync(applicationForm!);

            UpdatedApplicationFormResponse response = _mapper.Map<UpdatedApplicationFormResponse>(applicationForm);
            return response;
        }
    }
}