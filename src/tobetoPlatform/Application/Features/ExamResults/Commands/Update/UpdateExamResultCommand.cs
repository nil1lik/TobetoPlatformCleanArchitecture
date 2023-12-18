using Application.Features.ExamResults.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ExamResults.Commands.Update;

public class UpdateExamResultCommand : IRequest<UpdatedExamResultResponse>
{
    public int Id { get; set; }
    public int ExamStatusId { get; set; }
    public int Correct { get; set; }
    public int Wrong { get; set; }
    public int Empty { get; set; }
    public int Point { get; set; }

    public class UpdateExamResultCommandHandler : IRequestHandler<UpdateExamResultCommand, UpdatedExamResultResponse>
    {
        private readonly IMapper _mapper;
        private readonly IExamResultRepository _examResultRepository;
        private readonly ExamResultBusinessRules _examResultBusinessRules;

        public UpdateExamResultCommandHandler(IMapper mapper, IExamResultRepository examResultRepository,
                                         ExamResultBusinessRules examResultBusinessRules)
        {
            _mapper = mapper;
            _examResultRepository = examResultRepository;
            _examResultBusinessRules = examResultBusinessRules;
        }

        public async Task<UpdatedExamResultResponse> Handle(UpdateExamResultCommand request, CancellationToken cancellationToken)
        {
            ExamResult? examResult = await _examResultRepository.GetAsync(predicate: er => er.Id == request.Id, cancellationToken: cancellationToken);
            await _examResultBusinessRules.ExamResultShouldExistWhenSelected(examResult);
            examResult = _mapper.Map(request, examResult);

            await _examResultRepository.UpdateAsync(examResult!);

            UpdatedExamResultResponse response = _mapper.Map<UpdatedExamResultResponse>(examResult);
            return response;
        }
    }
}