namespace ShopAction.Application.Common.Models;

public sealed class PagedResult<T>
{
    public IReadOnlyList<T> Items { get; init; }
    public int TotalCount { get; init; }
    public int PageNumber { get; init; }
    public int PageSize { get; init; }

    public int TotalPage => PageSize <= 0 ? 0 : (TotalCount + PageSize - 1) / PageSize;
    public bool HasPrevious => PageNumber > 1;
    public bool HasNext => PageNumber < TotalPage;
    public bool IsEmpty => TotalCount == 0;

    public PagedResult(IReadOnlyList<T> items, int totalCount, int pageNumber, int pageSize)
    {
        if (pageNumber < 1) throw new ArgumentOutOfRangeException(nameof(pageNumber));
        if (pageSize is < 1 or > 100) throw new ArgumentOutOfRangeException(nameof(pageSize));
        if (totalCount < 0) throw new ArgumentOutOfRangeException(nameof(totalCount));

        Items = items;
        TotalCount = totalCount;
        PageNumber = pageNumber;
        PageSize = pageSize;
    }

    public static PagedResult<T> Empty(int pageNumber, int pageSize)
        => new(Array.Empty<T>(), 0, pageNumber, pageSize);
}