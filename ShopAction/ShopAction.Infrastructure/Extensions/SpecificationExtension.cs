using System.Linq;
using Microsoft.EntityFrameworkCore;
using ShopAction.Domain.Interfaces;

namespace ShopAction.Infrastructure.Extensions;

public static class SpecificationExtension
{
    /// <summary>
    /// Áp dụng specification vào IQueryable. Mặc định áp dụng paging.
    /// </summary>
    public static IQueryable<T> ApplySpecification<T>(
        this IQueryable<T> query,
        ISpecification<T> spec) where T : class
    {
        query = query.Where(spec.Criteria);

        // 2. INCLUDES — dùng string-based include cho cả ThenInclude
        foreach (var include in spec.Includes)
            query = query.Include(include);

        foreach (var includeString in spec.IncludeStrings)
            query = query.Include(includeString);

        // 3. ORDER BY — bắt buộc trước Skip/Take
        if (spec.OrderBy is not null)
            query = query.OrderBy(spec.OrderBy);
        else if (spec.OrderByDescending is not null)
            query = query.OrderByDescending(spec.OrderByDescending);
        // KHÔNG default OrderBy — để repository tự xử lý nếu cần

        // 4. PAGING — chỉ khi được yêu cầu
        if (spec.IsPagingEnabled)
        {
            query = query.Skip((spec.CurrentPage - 1) * spec.PageSize).Take(spec.PageSize);
        }

        return query;
    }

    /// <summary>
    /// Áp dụng spec cho count query — BỎ QUA paging và includes.
    /// Chỉ giữ Where để đếm đúng tổng số.
    /// </summary>
    public static IQueryable<T> ApplySpecificationForCount<T>(
        this IQueryable<T> query,
        ISpecification<T> spec) where T : class
    {
        query = query.Where(spec.Criteria);

        return query;
    }
}