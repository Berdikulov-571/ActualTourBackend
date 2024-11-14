using MainTravel.Application.UseCases.Companies.Commands;
using MainTravel.Application.UseCases.Companies.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MainTravel.Api.Controllers
{
    [ApiController]
    [Route("api/company/")]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync([FromForm] CreateCompanyCommand command)
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
                    return StatusCode(500, "An error occurred while creating the company");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync([FromForm] UpdateCompanyCommand command)
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
                    return StatusCode(500, "An error occurred while updating the company");
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
                var response = await _mediator.Send(new DeleteCompanyCommand() { Id = id});
                if (response)
                {
                    return Ok(response);
                }
                else
                {
                    return StatusCode(500, "An error occurred while deleting the company");
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
            try
            {
                var response = await _mediator.Send(new GetAllCompaniesQuery());

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("id={id}")]
        public async ValueTask<IActionResult> GetAllAsync(long id)
        {
            try
            {
                var response = await _mediator.Send(new GetCompanyByIdQuery() { Id = id });

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}