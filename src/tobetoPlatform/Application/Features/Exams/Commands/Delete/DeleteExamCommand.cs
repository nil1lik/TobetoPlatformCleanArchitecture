using Application.Features.Exams.Constants;
using Application.Features.Exams.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Exams.Commands.Delete;

public class DeleteExamCommand : IRequest<DeletedExamResponse>
{
    public int Id { get; set; }

    public class DeleteExamCommandHandler : IRequestHandler<DeleteExamCommand, DeletedExamResponse>
    {
        private readonly IMapper _mapper;
        private readonly IExamRepository _examRepository;
        private readonly ExamBusinessRules _examBusinessRules;

        public DeleteExamCommandHandler(IMapper mapper, IExamRepository examRepository,
                                         ExamBusinessRules examBusinessRules)
        {
            _mapper = mapper;
            _examRepository = examRepository;
            _examBusinessRules = examBusinessRules;
        }

        public async Task<DeletedExamResponse> Handle(DeleteExamCommand request, CancellationToken cancellationToken)
        {
            Exam? exam = await _examRepository.GetAsync(predicate: e => e.Id == request.Id, cancellationToken: cancellationToken);
            await _examBusinessRules.ExamShouldExistWhenSelected(exam);

            await _examRepository.DeleteAsync(exam!);

            DeletedExamResponse response = _mapper.Map<DeletedExamResponse>(exam);
            return response;
        }
    }
}