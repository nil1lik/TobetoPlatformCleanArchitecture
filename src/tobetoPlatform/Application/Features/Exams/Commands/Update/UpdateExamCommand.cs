using Application.Features.Exams.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Exams.Commands.Update;

public class UpdateExamCommand : IRequest<UpdatedExamResponse>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Duration { get; set; }
    public int QuestionCount { get; set; }
    public bool IsCompleted { get; set; }

    public class UpdateExamCommandHandler : IRequestHandler<UpdateExamCommand, UpdatedExamResponse>
    {
        private readonly IMapper _mapper;
        private readonly IExamRepository _examRepository;
        private readonly ExamBusinessRules _examBusinessRules;

        public UpdateExamCommandHandler(IMapper mapper, IExamRepository examRepository,
                                         ExamBusinessRules examBusinessRules)
        {
            _mapper = mapper;
            _examRepository = examRepository;
            _examBusinessRules = examBusinessRules;
        }

        public async Task<UpdatedExamResponse> Handle(UpdateExamCommand request, CancellationToken cancellationToken)
        {
            Exam? exam = await _examRepository.GetAsync(predicate: e => e.Id == request.Id, cancellationToken: cancellationToken);
            await _examBusinessRules.ExamShouldExistWhenSelected(exam);
            exam = _mapper.Map(request, exam);

            await _examRepository.UpdateAsync(exam!);

            UpdatedExamResponse response = _mapper.Map<UpdatedExamResponse>(exam);
            return response;
        }
    }
}