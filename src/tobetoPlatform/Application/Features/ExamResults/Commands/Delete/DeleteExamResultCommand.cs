using Application.Features.ExamResults.Constants;
using Application.Features.ExamResults.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ExamResults.Commands.Delete;

public class DeleteExamResultCommand : IRequest<DeletedExamResultResponse>
{
    public int Id { get; set; }

    public class DeleteExamResultCommandHandler : IRequestHandler<DeleteExamResultCommand, DeletedExamResultResponse>
    {
        private readonly IMapper _mapper;
        private readonly IExamResultRepository _examResultRepository;
        private readonly ExamResultBusinessRules _examResultBusinessRules;

        public DeleteExamResultCommandHandler(IMapper mapper, IExamResultRepository examResultRepository,
                                         ExamResultBusinessRules examResultBusinessRules)
        {
            _mapper = mapper;
            _examResultRepository = examResultRepository;
            _examResultBusinessRules = examResultBusinessRules;
        }

        public async Task<DeletedExamResultResponse> Handle(DeleteExamResultCommand request, CancellationToken cancellationToken)
        {
            ExamResult? examResult = await _examResultRepository.GetAsync(predicate: er => er.Id == request.Id, cancellationToken: cancellationToken);
            await _examResultBusinessRules.ExamResultShouldExistWhenSelected(examResult);

            await _examResultRepository.DeleteAsync(examResult!);

            DeletedExamResultResponse response = _mapper.Map<DeletedExamResultResponse>(examResult);
            return response;
        }
    }
}