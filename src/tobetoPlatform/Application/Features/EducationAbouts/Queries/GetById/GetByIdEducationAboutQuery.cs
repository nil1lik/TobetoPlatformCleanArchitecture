using Application.Features.EducationAbouts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.EducationAbouts.Queries.GetById;

public class GetByIdEducationAboutQuery : IRequest<GetByIdEducationAboutResponse>
{
    public int Id { get; set; }

    public class GetByIdEducationAboutQueryHandler : IRequestHandler<GetByIdEducationAboutQuery, GetByIdEducationAboutResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEducationAboutRepository _educationAboutRepository;
        private readonly EducationAboutBusinessRules _educationAboutBusinessRules;

        public GetByIdEducationAboutQueryHandler(IMapper mapper, IEducationAboutRepository educationAboutRepository, EducationAboutBusinessRules educationAboutBusinessRules)
        {
            _mapper = mapper;
            _educationAboutRepository = educationAboutRepository;
            _educationAboutBusinessRules = educationAboutBusinessRules;
        }

        public async Task<GetByIdEducationAboutResponse> Handle(GetByIdEducationAboutQuery request, CancellationToken cancellationToken)
        {
            EducationAbout? educationAbout = await _educationAboutRepository.GetAsync(predicate: ea => ea.Id == request.Id, cancellationToken: cancellationToken);
            await _educationAboutBusinessRules.EducationAboutShouldExistWhenSelected(educationAbout);

            GetByIdEducationAboutResponse response = _mapper.Map<GetByIdEducationAboutResponse>(educationAbout);
            return response;
        }
    }
}