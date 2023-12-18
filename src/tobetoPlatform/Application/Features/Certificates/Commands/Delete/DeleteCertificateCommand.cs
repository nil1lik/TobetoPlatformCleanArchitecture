using Application.Features.Certificates.Constants;
using Application.Features.Certificates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Certificates.Commands.Delete;

public class DeleteCertificateCommand : IRequest<DeletedCertificateResponse>
{
    public int Id { get; set; }

    public class DeleteCertificateCommandHandler : IRequestHandler<DeleteCertificateCommand, DeletedCertificateResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICertificateRepository _certificateRepository;
        private readonly CertificateBusinessRules _certificateBusinessRules;

        public DeleteCertificateCommandHandler(IMapper mapper, ICertificateRepository certificateRepository,
                                         CertificateBusinessRules certificateBusinessRules)
        {
            _mapper = mapper;
            _certificateRepository = certificateRepository;
            _certificateBusinessRules = certificateBusinessRules;
        }

        public async Task<DeletedCertificateResponse> Handle(DeleteCertificateCommand request, CancellationToken cancellationToken)
        {
            Certificate? certificate = await _certificateRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _certificateBusinessRules.CertificateShouldExistWhenSelected(certificate);

            await _certificateRepository.DeleteAsync(certificate!);

            DeletedCertificateResponse response = _mapper.Map<DeletedCertificateResponse>(certificate);
            return response;
        }
    }
}