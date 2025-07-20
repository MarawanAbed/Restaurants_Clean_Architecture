
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Common
{
    public class PageResult<T>
    {

        public IEnumerable<T> Items { get; set; }
        public int TotalPages { get; set; }
        public int TotalItemsCount { get; set; }
        public int ItemFrom { get; set; }
        public int ItemTo { get; set; }

        public PageResult(IEnumerable<T> items, int totalCount, int pageSize, int pageNubmer)
        {
            Items = items;
            TotalItemsCount = totalCount;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            ItemFrom = (pageNubmer - 1) * pageSize + 1;
            ItemTo = ItemFrom + pageSize - 1;

        }

    }
    //we gonna replace Ienumerable with PageResult in the GetAllRestaurantsQueryHandler
}
