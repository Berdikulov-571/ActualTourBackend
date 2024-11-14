using MainTravel.Application.UseCases.TourGuides.Queries;
using MainTravel.Application.UseCases.Tours.Commands;
using MainTravel.Application.UseCases.Tours.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MainTravel.Api.Controllers
{
    [ApiController]
    [Route("api/tour/")]
    public class TourController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TourController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync([FromForm] CreateTourCommand command)
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
                    return StatusCode(500, "An error occurred while creating the tour");
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
                var response = await _mediator.Send(new DeleteTourCommand() { Id = id });
                if (response)
                {
                    return Ok(response);
                }
                else
                {
                    return StatusCode(500, "An error occurred while deleting the tour");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync([FromForm] UpdateTourCommand command)
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
                    return StatusCode(500, "An error occurred while updating the tour");
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
            var response = await _mediator.Send(new GetAllToursQuery());

            return Ok(response);
        }

        [HttpGet("id={id}")]
        public async ValueTask<IActionResult> GetByIdAsync(long id)
        {
            var response = await _mediator.Send(new GetTourByIdQuery() { Id = id });

            return Ok(response);
        }
    }
}