using MainTravel.Application.Common.Paginations;
using MainTravel.Application.UseCases.Messages.Commands;
using MainTravel.Application.UseCases.Messages.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MainTravel.Api.Controllers
{
    [ApiController]
    [Route("api/message/")]
    public class MessageController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly int _maxPageSize = 10;

        public MessageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync([FromForm] CreateMessageCommand command)
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
                    return StatusCode(500, "An error occurred while creating the message");
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
                var response = await _mediator.Send(new DeleteMessageCommand() { Id = id });
                if (response)
                {
                    return Ok(response);
                }
                else
                {
                    return StatusCode(500, "An error occurred while deleting the message");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("getAll")]
        public async ValueTask<IActionResult> GetAllAsync([FromQuery] int page)
        {
            var result = await _mediator
                .Send(new GetAllMessagesQuery()
                {
                    Params = new PaginationParams(page, _maxPageSize)
                });

            return Ok(result);
        }

        [HttpGet("query={query}")]
        public async Task<IActionResult> GetMessagePageSizeBySearchQueryAsync(string query = "none")
        {
            var result = await _mediator
                .Send(new GetMessagePageSizeQuery()
                {
                    Query = query,
                    MaxPageSize = _maxPageSize,
                });

            return Ok(result);
        }

        [HttpGet("search={query}/page={page}")]
        public async ValueTask<IActionResult> SearchAsync(string query, int page = 1)
        {
            var response = await _mediator.Send(new SearchMessageQuery()
            {
                Params = new PaginationParams(page, _maxPageSize),
                Query = query
            });

            return Ok(response);
        }
    }
}