using Application.Features.Companies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Companies.Commands.Update;

public class UpdateCompanyCommand : IRequest<UpdatedCompanyResponse>
{
    public int Id { get; set; }
    public string Name { get; set; }

    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, UpdatedCompanyResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _companyRepository;
        private readonly CompanyBusinessRules _companyBusinessRules;

        public UpdateCompanyCommandHandler(IMapper mapper, ICompanyRepository companyRepository,
                                         CompanyBusinessRules companyBusinessRules)
        {
            _mapper = mapper;
            _companyRepository = companyRepository;
            _companyBusinessRules = companyBusinessRules;
        }

        public async Task<UpdatedCompanyResponse> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            Company? company = await _companyRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _companyBusinessRules.CompanyShouldExistWhenSelected(company);
            company = _mapper.Map(request, company);

            await _companyRepository.UpdateAsync(company!);

            UpdatedCompanyResponse response = _mapper.Map<UpdatedCompanyResponse>(company);
            return response;
        }
    }
}