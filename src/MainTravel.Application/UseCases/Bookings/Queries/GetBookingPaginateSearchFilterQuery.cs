using MainTravel.Application.Abstractions;
using MainTravel.Application.Common.Helpers;
using MainTravel.Domain.DTOs.Bookings;
using MainTravel.Domain.Entities;
using MediatR;

namespace MainTravel.Application.UseCases.Bookings.Queries
{
    public class GetBookingPaginateSearchFilterQuery : IRequest<PaginatedList<BookingResponse>>
    {
        public string? SearchTerm { get; set; }
        public string? SortBy { get; set; }
        public bool SortDescending { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class GetBookingPaginateSearchFilterQueryHandler : IRequestHandler<GetBookingPaginateSearchFilterQuery, PaginatedList<BookingResponse>>
    {
        private readonly IAppDbContext _context;

        public GetBookingPaginateSearchFilterQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedList<BookingResponse>> Handle(GetBookingPaginateSearchFilterQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Bookings.AsQueryable();

            // Search
            if (!string.IsNullOrEmpty(request.SearchTerm))
            {
                query = query.Where(u =>
                    u.Id.ToString().Contains(request.SearchTerm) ||
                    u.FirstName.Contains(request.SearchTerm) ||
                    u.LastName.Contains(request.SearchTerm) ||
                    u.Email.Contains(request.SearchTerm) ||
                    u.PhoneNumber.Contains(request.SearchTerm));
            }

            if (!string.IsNullOrEmpty(request.SortBy))
            {
                query = request.SortBy switch
                {
                    "FullName" => request.SortDescending ? query.OrderByDescending(u => u.FirstName).ThenByDescending(u => u.LastName)
                    : query.OrderBy(u => u.FirstName).ThenBy(u => u.LastName),
                    "PhoneNumber" => request.SortDescending ? query.OrderByDescending(u => u.PhoneNumber) : query.OrderBy(u => u.PhoneNumber),
                    "Email" => request.SortDescending ? query.OrderByDescending(u => u.Email) : query.OrderBy(u => u.Email),
                    "Humans" => request.SortDescending ? query.OrderByDescending(u => u.Humans) : query.OrderBy(u => u.Humans),
                    "TourId" => request.SortDescending ? query.OrderByDescending(u => u.TourId) : query.OrderBy(u => u.TourId),
                    "CheckInDate" => request.SortDescending ? query.OrderByDescending(u => u.CheckInDate) : query.OrderBy(u => u.CheckInDate),
                    "CheckOutDate" => request.SortDescending ? query.OrderByDescending(u => u.CheckOutDate) : query.OrderBy(u => u.CheckOutDate),
                    //"Likes" => request.SortDescending ? query.OrderByDescending(u => u.Like) : query.OrderBy(u => u.Like),
                    //"LanguageLevel" => request.SortDescending ? query.OrderByDescending(u => u.LanguageLevel) : query.OrderBy(u => u.LanguageLevel),
                    //"Gender" => request.SortDescending ? query.OrderByDescending(u => u.Gender) : query.OrderBy(u => u.Gender),
                    //"IsActive" => request.SortDescending ? query.OrderByDescending(u => u.IsActive) : query.OrderBy(u => u.IsActive),
                    "CreatedAt" => request.SortDescending ? query.OrderByDescending(u => u.CreatedAt) : query.OrderBy(u => u.CreatedAt),
                    _ => query.OrderBy(u => u.Id),
                };
            }

            var userDtos = query.Select(u => new BookingResponse
            {
                Id = u.Id,
                FullName = u.FirstName + " " + u.LastName,
                Email = u.Email,
                Status = u.Status,
                Humans = u.Humans,
                Tour = u.Tour,
                TourId = u.TourId,
                PhoneNumber = u.PhoneNumber,
                CreatedAt = u.CreatedAt,
                CheckOutDate = u.CheckOutDate,
                CheckInDate = u.CheckInDate,
                UpdatedAt = u.UpdatedAt
            }).ToList();

            var paginatedUsers = await PaginatedList<BookingResponse>.CreateAsync(userDtos, request.PageNumber, request.PageSize);

            return paginatedUsers;
        }
    }
}