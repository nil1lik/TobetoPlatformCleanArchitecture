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
public class GetExamResultDetailQuery : IRequest<GetExamResultDetailDTO>
{
    public int Id { get; set; }

    public class GetByIdExamResultQueryHandler : IRequestHandler<GetExamResultDetailQuery, GetExamResultDetailDTO>
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

        public async Task<GetExamResultDetailDTO> Handle(GetExamResultDetailQuery request, CancellationToken cancellationToken)
        {
            Exam? exam = await _examRepository.GetAsync(predicate: e => e.Id == request.Id,
                                                        include: p => p.Include(p => p.ExamResult),
                                                        cancellationToken: cancellationToken);
            await _examBusinessRules.ExamShouldExistWhenSelected(exam);

            GetExamResultDetailDTO response = _mapper.Map<GetExamResultDetailDTO>(exam);
            return response;
        }
    }
}
