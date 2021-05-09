using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nairobi.Application.Commands;
using Nairobi.Application.Requests;
using Nairobi.Dtos;
using Nairobi.Dtos.Core;

namespace Nairobi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ProductDto>),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ServiceResult>),StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new GetProductsRequest());
            if (!response.HasError)
            {
                return Ok(response.Data);
            }

            return BadRequest(response.Errors);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ServiceResult>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(string id)
        {
            var response = await _mediator.Send(new GetProductByIdRequest{Id = id});
            if (!response.HasError)
            {
                return Ok(response.Data);
            }

            return BadRequest(response.Errors);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProductDto),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ServiceResult>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateProductCommand createProductCommand)
        {
            var response = await _mediator.Send(createProductCommand);
            if (!response.HasError)
            {
                return Ok(response.Data);
            }

            return BadRequest(response.Errors);
        }

        [HttpPut]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ServiceResult>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(UpdateProductCommand updateProductCommand)
        {
            var response = await _mediator.Send(updateProductCommand);
            if (!response.HasError)
            {
                return Ok(response.Data);
            }

            return BadRequest(response.Errors);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(NoContentResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ServiceResult>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _mediator.Send(new DeleteProductCommand() { Id = id });
            if (!response.HasError)
            {
                return Ok(response.Data);
            }

            return NotFound(response.Errors);
        }
    }
}
