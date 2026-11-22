using ShopAction.Application.Specifications;
using ShopAction.Domain.Entities.Users;

namespace ShopAction.Application.Features.Users;

public class UserSpecification : BaseSpecification<User>
{
    public UserSpecification(int pageSize, int pageNumber) : base(x => x.IsActive)
    {
        ApplyPaging(pageNumber, pageSize);
    }
}