using Application.Features.Exams.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Exams.Queries.GetById;

public class GetByIdExamQuery : IRequest<GetByIdExamResponse>
{
    public int Id { get; set; }

    public class GetByIdExamQueryHandler : IRequestHandler<GetByIdExamQuery, GetByIdExamResponse>
    {
        private readonly IMapper _mapper;
        private readonly IExamRepository _examRepository;
        private readonly ExamBusinessRules _examBusinessRules;

        public GetByIdExamQueryHandler(IMapper mapper, IExamRepository examRepository, ExamBusinessRules examBusinessRules)
        {
            _mapper = mapper;
            _examRepository = examRepository;
            _examBusinessRules = examBusinessRules;
        }

        public async Task<GetByIdExamResponse> Handle(GetByIdExamQuery request, CancellationToken cancellationToken)
        {
            Exam? exam = await _examRepository.GetAsync(predicate: e => e.Id == request.Id, 
                                                        cancellationToken: cancellationToken);
            await _examBusinessRules.ExamShouldExistWhenSelected(exam);

            GetByIdExamResponse response = _mapper.Map<GetByIdExamResponse>(exam);
            return response;
        }
    }
}