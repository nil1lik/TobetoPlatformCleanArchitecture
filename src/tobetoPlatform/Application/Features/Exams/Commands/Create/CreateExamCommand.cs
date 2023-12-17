using Application.Features.Exams.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Exams.Commands.Create;

public class CreateExamCommand : IRequest<CreatedExamResponse>
{
    public int ExamResultId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Duration { get; set; }

    public class CreateExamCommandHandler : IRequestHandler<CreateExamCommand, CreatedExamResponse>
    {
        private readonly IMapper _mapper;
        private readonly IExamRepository _examRepository;
        private readonly ExamBusinessRules _examBusinessRules;

        public CreateExamCommandHandler(IMapper mapper, IExamRepository examRepository,
                                         ExamBusinessRules examBusinessRules)
        {
            _mapper = mapper;
            _examRepository = examRepository;
            _examBusinessRules = examBusinessRules;
        }

        public async Task<CreatedExamResponse> Handle(CreateExamCommand request, CancellationToken cancellationToken)
        {
            Exam exam = _mapper.Map<Exam>(request);

            await _examRepository.AddAsync(exam);

            CreatedExamResponse response = _mapper.Map<CreatedExamResponse>(exam);
            return response;
        }
    }
}