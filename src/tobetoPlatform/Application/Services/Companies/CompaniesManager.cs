using Application.Features.Companies.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Companies;

public class CompaniesManager : ICompaniesService
{
    private readonly ICompanyRepository _companyRepository;
    private readonly CompanyBusinessRules _companyBusinessRules;

    public CompaniesManager(ICompanyRepository companyRepository, CompanyBusinessRules companyBusinessRules)
    {
        _companyRepository = companyRepository;
        _companyBusinessRules = companyBusinessRules;
    }

    public async Task<Company?> GetAsync(
        Expression<Func<Company, bool>> predicate,
        Func<IQueryable<Company>, IIncludableQueryable<Company, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Company? company = await _companyRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return company;
    }

    public async Task<IPaginate<Company>?> GetListAsync(
        Expression<Func<Company, bool>>? predicate = null,
        Func<IQueryable<Company>, IOrderedQueryable<Company>>? orderBy = null,
        Func<IQueryable<Company>, IIncludableQueryable<Company, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Company> companyList = await _companyRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return companyList;
    }

    public async Task<Company> AddAsync(Company company)
    {
        Company addedCompany = await _companyRepository.AddAsync(company);

        return addedCompany;
    }

    public async Task<Company> UpdateAsync(Company company)
    {
        Company updatedCompany = await _companyRepository.UpdateAsync(company);

        return updatedCompany;
    }

    public async Task<Company> DeleteAsync(Company company, bool permanent = false)
    {
        Company deletedCompany = await _companyRepository.DeleteAsync(company);

        return deletedCompany;
    }
}
