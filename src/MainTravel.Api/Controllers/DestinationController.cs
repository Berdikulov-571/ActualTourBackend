using MainTravel.Application.UseCases.Destinations.Commands;
using MainTravel.Application.UseCases.Destinations.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MainTravel.Api.Controllers
{
    [ApiController]
    [Route("api/destination/")]
    public class DestinationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DestinationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync([FromForm] CreateDestinationCommand command)
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
                    return StatusCode(500, "An error occurred while creating the destination");
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
                var response = await _mediator.Send(new DeleteDestinationCommand() { Id = id });
                if (response)
                {
                    return Ok(response);
                }
                else
                {
                    return StatusCode(500, "An error occurred while deleting the destination");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync([FromForm] UpdateDestinationCommand command)
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
                    return StatusCode(500, "An error occurred while updating the destination");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("getAll")]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            var response = await _mediator.Send(new GetAllDestinations());

            return Ok(response);
        }

        [HttpGet("id={id}")]
        public async ValueTask<IActionResult> GetByIdAsync(long id)
        {
            var response = await _mediator.Send(new GetDestinationByIdQuery() { Id = id });

            return Ok(response);
        }
    }
}