using Application.Features.Classes.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Classes;

public class ClassesManager : IClassesService
{
    private readonly IClassRepository _classRepository;
    private readonly ClassBusinessRules _classBusinessRules;

    public ClassesManager(IClassRepository classRepository, ClassBusinessRules classBusinessRules)
    {
        _classRepository = classRepository;
        _classBusinessRules = classBusinessRules;
    }

    public async Task<Class?> GetAsync(
        Expression<Func<Class, bool>> predicate,
        Func<IQueryable<Class>, IIncludableQueryable<Class, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Class? class = await _classRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return class;
    }

    public async Task<IPaginate<Class>?> GetListAsync(
        Expression<Func<Class, bool>>? predicate = null,
        Func<IQueryable<Class>, IOrderedQueryable<Class>>? orderBy = null,
        Func<IQueryable<Class>, IIncludableQueryable<Class, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Class> classList = await _classRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return classList;
    }

    public async Task<Class> AddAsync(Class class)
    {
        Class addedClass = await _classRepository.AddAsync(class);

        return addedClass;
    }

    public async Task<Class> UpdateAsync(Class class)
    {
        Class updatedClass = await _classRepository.UpdateAsync(class);

        return updatedClass;
    }

    public async Task<Class> DeleteAsync(Class class, bool permanent = false)
    {
        Class deletedClass = await _classRepository.DeleteAsync(class);

        return deletedClass;
    }
}
