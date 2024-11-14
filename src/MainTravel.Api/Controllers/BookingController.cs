using MainTravel.Application.Common.Helpers;
using MainTravel.Application.Common.Paginations;
using MainTravel.Application.UseCases.Bookings.Commands;
using MainTravel.Application.UseCases.Bookings.Queries;
using MainTravel.Domain.DTOs.Bookings;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MainTravel.Api.Controllers
{
    [ApiController]
    [Route("api/booking/")]
    public class BookingController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly int _maxPageSize = 10;

        public BookingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("count")]
        public async ValueTask<IActionResult> GetCount()
        {
            long response = await _mediator.Send(new GetCountBookingQuery());

            return Ok(response);
        }

        [HttpGet("filter")]
        public async Task<ActionResult<PaginatedList<BookingResponse>>> GetUsers([FromQuery] GetBookingPaginateSearchFilterQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync([FromForm] CreateBookingCommand command)
        {
            try
            {
                var response = await _mediator.Send(command);
                if (response)
                {
                    return Ok(response);
                }
                else
                {
                    return StatusCode(500, "An error occurred while creating the booking");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("id={id}")]
        public async ValueTask<IActionResult> DeleteAsync(long id)
        {
            try
            {
                var response = await _mediator.Send(new DeleteBookingCommand() { Id = id });
                if (response)
                {
                    return Ok(response);
                }
                else
                {
                    return StatusCode(500, "An error occurred while deleting the booking");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync([FromQuery] int page = 1)
        {
            try
            {
                var response = await _mediator
                    .Send(new GetAllBookingQuery()
                    {
                        Params = new PaginationParams(page, _maxPageSize)
                    });

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}