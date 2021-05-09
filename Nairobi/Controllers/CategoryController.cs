using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Http;
using Nairobi.Application.Requests;
using Nairobi.Dtos;
using Nairobi.Dtos.Core;

namespace Nairobi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CategoryDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ServiceResult>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new GetCategoriesRequest());
            if (!response.HasError)
            {
                return Ok(response.Data);
            }

            return BadRequest(response.Errors);
        }
    }
}
