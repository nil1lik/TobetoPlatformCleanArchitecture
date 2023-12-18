using Application.Features.ApplicationForms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ApplicationForms.Commands.Create;

public class CreateApplicationFormCommand : IRequest<CreatedApplicationFormResponse>
{
    public int ProfileDocumentFormId { get; set; }
    public int ProfileApplicationFormId { get; set; }
    public string Name { get; set; }

    public class CreateApplicationFormCommandHandler : IRequestHandler<CreateApplicationFormCommand, CreatedApplicationFormResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationFormRepository _applicationFormRepository;
        private readonly ApplicationFormBusinessRules _applicationFormBusinessRules;

        public CreateApplicationFormCommandHandler(IMapper mapper, IApplicationFormRepository applicationFormRepository,
                                         ApplicationFormBusinessRules applicationFormBusinessRules)
        {
            _mapper = mapper;
            _applicationFormRepository = applicationFormRepository;
            _applicationFormBusinessRules = applicationFormBusinessRules;
        }

        public async Task<CreatedApplicationFormResponse> Handle(CreateApplicationFormCommand request, CancellationToken cancellationToken)
        {
            ApplicationForm applicationForm = _mapper.Map<ApplicationForm>(request);

            await _applicationFormRepository.AddAsync(applicationForm);

            CreatedApplicationFormResponse response = _mapper.Map<CreatedApplicationFormResponse>(applicationForm);
            return response;
        }
    }
}