using Application.Features.ExamResults.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ExamResults.Queries.GetById;

public class GetByIdExamResultQuery : IRequest<GetByIdExamResultResponse>
{
    public int Id { get; set; }

    public class GetByIdExamResultQueryHandler : IRequestHandler<GetByIdExamResultQuery, GetByIdExamResultResponse>
    {
        private readonly IMapper _mapper;
        private readonly IExamResultRepository _examResultRepository;
        private readonly ExamResultBusinessRules _examResultBusinessRules;

        public GetByIdExamResultQueryHandler(IMapper mapper, IExamResultRepository examResultRepository, ExamResultBusinessRules examResultBusinessRules)
        {
            _mapper = mapper;
            _examResultRepository = examResultRepository;
            _examResultBusinessRules = examResultBusinessRules;
        }

        public async Task<GetByIdExamResultResponse> Handle(GetByIdExamResultQuery request, CancellationToken cancellationToken)
        {
            ExamResult? examResult = await _examResultRepository.GetAsync(predicate: er => er.Id == request.Id, cancellationToken: cancellationToken);
            await _examResultBusinessRules.ExamResultShouldExistWhenSelected(examResult);

            GetByIdExamResultResponse response = _mapper.Map<GetByIdExamResultResponse>(examResult);
            return response;
        }
    }
}