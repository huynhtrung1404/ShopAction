namespace ShopAction.Application.Models
{
    public class PagingModel
    {
        public PagingModel()
        {

        }
        public PagingModel(int pageSize, int pageNumber)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
        }
        public int PageSize { get; set; } = 1;
        public int PageNumber { get; set; } = 1;
    }
}
