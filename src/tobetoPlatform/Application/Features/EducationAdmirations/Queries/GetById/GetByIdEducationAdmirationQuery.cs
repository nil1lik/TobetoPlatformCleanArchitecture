using Application.Features.EducationAdmirations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.EducationAdmirations.Queries.GetById;

public class GetByIdEducationAdmirationQuery : IRequest<GetByIdEducationAdmirationResponse>
{
    public int Id { get; set; }

    public class GetByIdEducationAdmirationQueryHandler : IRequestHandler<GetByIdEducationAdmirationQuery, GetByIdEducationAdmirationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEducationAdmirationRepository _educationAdmirationRepository;
        private readonly EducationAdmirationBusinessRules _educationAdmirationBusinessRules;

        public GetByIdEducationAdmirationQueryHandler(IMapper mapper, IEducationAdmirationRepository educationAdmirationRepository, EducationAdmirationBusinessRules educationAdmirationBusinessRules)
        {
            _mapper = mapper;
            _educationAdmirationRepository = educationAdmirationRepository;
            _educationAdmirationBusinessRules = educationAdmirationBusinessRules;
        }

        public async Task<GetByIdEducationAdmirationResponse> Handle(GetByIdEducationAdmirationQuery request, CancellationToken cancellationToken)
        {
            EducationAdmiration? educationAdmiration = await _educationAdmirationRepository.GetAsync(predicate: ea => ea.Id == request.Id, cancellationToken: cancellationToken);
            await _educationAdmirationBusinessRules.EducationAdmirationShouldExistWhenSelected(educationAdmiration);

            GetByIdEducationAdmirationResponse response = _mapper.Map<GetByIdEducationAdmirationResponse>(educationAdmiration);
            return response;
        }
    }
}