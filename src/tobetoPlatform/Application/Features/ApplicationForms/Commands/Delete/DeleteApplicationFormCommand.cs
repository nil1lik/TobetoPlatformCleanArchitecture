using Application.Features.ApplicationForms.Constants;
using Application.Features.ApplicationForms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ApplicationForms.Commands.Delete;

public class DeleteApplicationFormCommand : IRequest<DeletedApplicationFormResponse>
{
    public int Id { get; set; }

    public class DeleteApplicationFormCommandHandler : IRequestHandler<DeleteApplicationFormCommand, DeletedApplicationFormResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationFormRepository _applicationFormRepository;
        private readonly ApplicationFormBusinessRules _applicationFormBusinessRules;

        public DeleteApplicationFormCommandHandler(IMapper mapper, IApplicationFormRepository applicationFormRepository,
                                         ApplicationFormBusinessRules applicationFormBusinessRules)
        {
            _mapper = mapper;
            _applicationFormRepository = applicationFormRepository;
            _applicationFormBusinessRules = applicationFormBusinessRules;
        }

        public async Task<DeletedApplicationFormResponse> Handle(DeleteApplicationFormCommand request, CancellationToken cancellationToken)
        {
            ApplicationForm? applicationForm = await _applicationFormRepository.GetAsync(predicate: af => af.Id == request.Id, cancellationToken: cancellationToken);
            await _applicationFormBusinessRules.ApplicationFormShouldExistWhenSelected(applicationForm);

            await _applicationFormRepository.DeleteAsync(applicationForm!);

            DeletedApplicationFormResponse response = _mapper.Map<DeletedApplicationFormResponse>(applicationForm);
            return response;
        }
    }
}