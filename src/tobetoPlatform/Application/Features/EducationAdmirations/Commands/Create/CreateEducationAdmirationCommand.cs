using Application.Features.EducationAdmirations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.EducationAdmirations.Commands.Create;

public class CreateEducationAdmirationCommand : IRequest<CreatedEducationAdmirationResponse>
{
    public bool IsLiked { get; set; }
    public bool IsFavourited { get; set; }
    public double CompletionRate { get; set; }
    public double EducationPoint { get; set; }

    public class CreateEducationAdmirationCommandHandler : IRequestHandler<CreateEducationAdmirationCommand, CreatedEducationAdmirationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEducationAdmirationRepository _educationAdmirationRepository;
        private readonly EducationAdmirationBusinessRules _educationAdmirationBusinessRules;

        public CreateEducationAdmirationCommandHandler(IMapper mapper, IEducationAdmirationRepository educationAdmirationRepository,
                                         EducationAdmirationBusinessRules educationAdmirationBusinessRules)
        {
            _mapper = mapper;
            _educationAdmirationRepository = educationAdmirationRepository;
            _educationAdmirationBusinessRules = educationAdmirationBusinessRules;
        }

        public async Task<CreatedEducationAdmirationResponse> Handle(CreateEducationAdmirationCommand request, CancellationToken cancellationToken)
        {
            EducationAdmiration educationAdmiration = _mapper.Map<EducationAdmiration>(request);

            await _educationAdmirationRepository.AddAsync(educationAdmiration);

            CreatedEducationAdmirationResponse response = _mapper.Map<CreatedEducationAdmirationResponse>(educationAdmiration);
            return response;
        }
    }
}