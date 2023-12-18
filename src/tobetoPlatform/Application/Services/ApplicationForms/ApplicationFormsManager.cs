using Application.Features.ApplicationForms.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ApplicationForms;

public class ApplicationFormsManager : IApplicationFormsService
{
    private readonly IApplicationFormRepository _applicationFormRepository;
    private readonly ApplicationFormBusinessRules _applicationFormBusinessRules;

    public ApplicationFormsManager(IApplicationFormRepository applicationFormRepository, ApplicationFormBusinessRules applicationFormBusinessRules)
    {
        _applicationFormRepository = applicationFormRepository;
        _applicationFormBusinessRules = applicationFormBusinessRules;
    }

    public async Task<ApplicationForm?> GetAsync(
        Expression<Func<ApplicationForm, bool>> predicate,
        Func<IQueryable<ApplicationForm>, IIncludableQueryable<ApplicationForm, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ApplicationForm? applicationForm = await _applicationFormRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return applicationForm;
    }

    public async Task<IPaginate<ApplicationForm>?> GetListAsync(
        Expression<Func<ApplicationForm, bool>>? predicate = null,
        Func<IQueryable<ApplicationForm>, IOrderedQueryable<ApplicationForm>>? orderBy = null,
        Func<IQueryable<ApplicationForm>, IIncludableQueryable<ApplicationForm, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ApplicationForm> applicationFormList = await _applicationFormRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return applicationFormList;
    }

    public async Task<ApplicationForm> AddAsync(ApplicationForm applicationForm)
    {
        ApplicationForm addedApplicationForm = await _applicationFormRepository.AddAsync(applicationForm);

        return addedApplicationForm;
    }

    public async Task<ApplicationForm> UpdateAsync(ApplicationForm applicationForm)
    {
        ApplicationForm updatedApplicationForm = await _applicationFormRepository.UpdateAsync(applicationForm);

        return updatedApplicationForm;
    }

    public async Task<ApplicationForm> DeleteAsync(ApplicationForm applicationForm, bool permanent = false)
    {
        ApplicationForm deletedApplicationForm = await _applicationFormRepository.DeleteAsync(applicationForm);

        return deletedApplicationForm;
    }
}
