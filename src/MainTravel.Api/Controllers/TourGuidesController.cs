using MainTravel.Application.UseCases.TourGuides.Commands;
using MainTravel.Application.UseCases.TourGuides.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MainTravel.Api.Controllers
{
    [ApiController]
    [Route("api/tourGuides/")]
    public class TourGuidesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TourGuidesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync([FromForm] CreateTourGuideCommand command)
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
                    return StatusCode(500, "An error occurred while creating the TourGuide");
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
                var response = await _mediator.Send(new DeleteTourGuideCommand() { Id = id });
                if (response)
                {
                    return Ok(response);
                }
                else
                {
                    return StatusCode(500, "An error occurred while deleting the TopGuide");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync([FromForm] UpdateTourGuideCommand command)
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
                    return StatusCode(500, "An error occurred while updating the TourGuide");
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
            var response = await _mediator.Send(new GetAllTourGuidesQuery());

            return Ok(response);
        }

        [HttpGet("id={id}")]
        public async ValueTask<IActionResult> GetByIdAsync(long id)
        {
            var response = await _mediator.Send(new GetTourGuideByIdQuery() { Id = id });

            return Ok(response);
        }
    }
}