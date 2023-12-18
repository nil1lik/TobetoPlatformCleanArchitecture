using Application.Features.EducationPaths.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.EducationPaths;

public class EducationPathsManager : IEducationPathsService
{
    private readonly IEducationPathRepository _educationPathRepository;
    private readonly EducationPathBusinessRules _educationPathBusinessRules;

    public EducationPathsManager(IEducationPathRepository educationPathRepository, EducationPathBusinessRules educationPathBusinessRules)
    {
        _educationPathRepository = educationPathRepository;
        _educationPathBusinessRules = educationPathBusinessRules;
    }

    public async Task<EducationPath?> GetAsync(
        Expression<Func<EducationPath, bool>> predicate,
        Func<IQueryable<EducationPath>, IIncludableQueryable<EducationPath, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        EducationPath? educationPath = await _educationPathRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return educationPath;
    }

    public async Task<IPaginate<EducationPath>?> GetListAsync(
        Expression<Func<EducationPath, bool>>? predicate = null,
        Func<IQueryable<EducationPath>, IOrderedQueryable<EducationPath>>? orderBy = null,
        Func<IQueryable<EducationPath>, IIncludableQueryable<EducationPath, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<EducationPath> educationPathList = await _educationPathRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return educationPathList;
    }

    public async Task<EducationPath> AddAsync(EducationPath educationPath)
    {
        EducationPath addedEducationPath = await _educationPathRepository.AddAsync(educationPath);

        return addedEducationPath;
    }

    public async Task<EducationPath> UpdateAsync(EducationPath educationPath)
    {
        EducationPath updatedEducationPath = await _educationPathRepository.UpdateAsync(educationPath);

        return updatedEducationPath;
    }

    public async Task<EducationPath> DeleteAsync(EducationPath educationPath, bool permanent = false)
    {
        EducationPath deletedEducationPath = await _educationPathRepository.DeleteAsync(educationPath);

        return deletedEducationPath;
    }
}
