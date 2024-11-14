using MainTravel.Application.Common.Paginations;

namespace MainTravel.Application.Abstractions
{
    public interface IPaginator
    {
        public void Paginate(long itemsCount, PaginationParams @params);
    }
}