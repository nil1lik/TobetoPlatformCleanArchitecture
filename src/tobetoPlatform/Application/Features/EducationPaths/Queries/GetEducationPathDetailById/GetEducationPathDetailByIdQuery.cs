using Application.Features.EducationPaths.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
namespace Application.Features.EducationPaths.Queries.GetEducationPathDetailById
{
    public class GetEducationPathDetailByIdQuery : IRequest<GetEducationPathDetailByIdDto>
    {
        public int Id { get; set; }
        public class GetEducationPathDetailByIdQueryHandler : IRequestHandler<GetEducationPathDetailByIdQuery, GetEducationPathDetailByIdDto>
        {
            private readonly IMapper _mapper;
            private readonly IEducationPathRepository _educationPathRepository;
            private readonly EducationPathBusinessRules _educationPathBusinessRules;

            public GetEducationPathDetailByIdQueryHandler(IMapper mapper, IEducationPathRepository educationPathRepository, EducationPathBusinessRules educationPathBusinessRules)
            {
                _mapper = mapper;
                _educationPathRepository = educationPathRepository;
                _educationPathBusinessRules = educationPathBusinessRules;
            }

            public async Task<GetEducationPathDetailByIdDto> Handle(GetEducationPathDetailByIdQuery request, CancellationToken cancellationToken)
            {
                EducationPath? educationPath = await _educationPathRepository.GetAsync(predicate: ep => ep.Id == request.Id,
                    include: c => c.Include(c => c.EducationAdmiration).
                             Include(c => c.EducationAbout),
                    cancellationToken: cancellationToken);
                await _educationPathBusinessRules.EducationPathShouldExistWhenSelected(educationPath);
                GetEducationPathDetailByIdDto response = _mapper.Map<GetEducationPathDetailByIdDto>(educationPath);
                return response;
            }
        }
    }
}

