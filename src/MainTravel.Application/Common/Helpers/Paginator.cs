using MainTravel.Application.Abstractions;
using MainTravel.Application.Common.Paginations;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace MainTravel.Application.Common.Helpers
{
    public class Paginator : IPaginator
    {
        private readonly IHttpContextAccessor _accessor;
        public Paginator(IHttpContextAccessor httpContextAccessor)
        {
            this._accessor = httpContextAccessor;
        }

        public void Paginate(long itemsCount, PaginationParams @params)
        {
            PaginationData paginationMetaData = new PaginationData();
            paginationMetaData.CurrentPage = @params.PageNumber;
            paginationMetaData.TotalItems = (int)itemsCount;
            paginationMetaData.PageSize = @params.PageSize;

            paginationMetaData.TotalPages = (int)Math.Ceiling((double)itemsCount / @params.PageSize);
            paginationMetaData.HasPrevious = paginationMetaData.CurrentPage > 1;
            paginationMetaData.HasNext = paginationMetaData.CurrentPage < paginationMetaData.TotalPages;

            string jsonContent = JsonConvert.SerializeObject(paginationMetaData);
            _accessor.HttpContext.Response.Headers.Add("X-Pagination", jsonContent);
        }
    }
}