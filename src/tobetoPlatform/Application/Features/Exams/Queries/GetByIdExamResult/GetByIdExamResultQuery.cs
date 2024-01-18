using Amazon.Runtime.Internal;
using Application.Features.Exams.Queries.GetById;
using Application.Features.Exams.Rules;
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

namespace Application.Features.Exams.Queries.GetByIdExamResult;
public class GetByIdExamResultQuery : IRequest<GetByIdExamResultDTO>
{
    public int Id { get; set; }

    public class GetByIdExamResultQueryHandler : IRequestHandler<GetByIdExamResultQuery, GetByIdExamResultDTO>
    {
        private readonly IMapper _mapper;
        private readonly IExamRepository _examRepository;
        private readonly ExamBusinessRules _examBusinessRules;

        public GetByIdExamResultQueryHandler(IMapper mapper, IExamRepository examRepository, ExamBusinessRules examBusinessRules)
        {
            _mapper = mapper;
            _examRepository = examRepository;
            _examBusinessRules = examBusinessRules;
        }

        public async Task<GetByIdExamResultDTO> Handle(GetByIdExamResultQuery request, CancellationToken cancellationToken)
        {
            Exam? exam = await _examRepository.GetAsync(predicate: e => e.Id == request.Id,
                                                        include:p=>p.Include(p=>p.ExamResult),
                                                        cancellationToken: cancellationToken);
            await _examBusinessRules.ExamShouldExistWhenSelected(exam);

            GetByIdExamResultDTO response = _mapper.Map<GetByIdExamResultDTO>(exam);
            return response;
        }
    }
}
