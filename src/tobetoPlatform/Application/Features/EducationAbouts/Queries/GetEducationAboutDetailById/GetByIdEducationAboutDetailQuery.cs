using Application.Features.EducationAbouts.Queries.GetById;
using Application.Features.EducationAbouts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.EducationAbouts.Queries.EducationAboutDetailById;
public class GetByIdEducationAboutDetailQuery:IRequest<GetByIdEducationAboutDetailDto>
{
    public int Id { get; set; }

    public class GetEducationAboutDetailQueryHandler : IRequestHandler<GetByIdEducationAboutDetailQuery, GetByIdEducationAboutDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly IEducationAboutRepository _educationAboutRepository;
        private readonly EducationAboutBusinessRules _educationAboutBusinessRules;

        public GetEducationAboutDetailQueryHandler(IMapper mapper, IEducationAboutRepository educationAboutRepository, EducationAboutBusinessRules educationAboutBusinessRules)
        {
            _mapper = mapper;
            _educationAboutRepository = educationAboutRepository;
            _educationAboutBusinessRules = educationAboutBusinessRules;
        }

        public async Task<GetByIdEducationAboutDetailDto> Handle(GetByIdEducationAboutDetailQuery request, CancellationToken cancellationToken)
        {
            EducationAbout? educationAbout = await _educationAboutRepository.GetAsync(predicate: ea => ea.Id == request.Id, 
                include: c=> c.Include(c=> c.Company).
                               Include(c=> c.EducationAboutCategory),        
                cancellationToken: cancellationToken);
            await _educationAboutBusinessRules.EducationAboutShouldExistWhenSelected(educationAbout);

            GetByIdEducationAboutDetailDto response = _mapper.Map<GetByIdEducationAboutDetailDto>(educationAbout);
            return response;
        }
    }
}
