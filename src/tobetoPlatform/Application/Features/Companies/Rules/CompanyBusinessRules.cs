using Application.Features.Companies.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Companies.Rules;

public class CompanyBusinessRules : BaseBusinessRules
{
    private readonly ICompanyRepository _companyRepository;

    public CompanyBusinessRules(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    public Task CompanyShouldExistWhenSelected(Company? company)
    {
        if (company == null)
            throw new BusinessException(CompaniesBusinessMessages.CompanyNotExists);
        return Task.CompletedTask;
    }

    public async Task CompanyIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Company? company = await _companyRepository.GetAsync(
            predicate: c => c.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CompanyShouldExistWhenSelected(company);
    }
}