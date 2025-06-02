using Application.Products.Commands.DeleteProduct;
using Application.Products.Queries.GetProductById;
using HttpModels.Products.Command.Create;
using HttpModels.Products.Command.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Mapping;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;
        public ProductsController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductRequest request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _sender.Send(_mapper.Map(request), cancellationToken);
            return Ok(result.Value);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var query = new GetProductByIdQuery(id);
            var result = await _sender.Send(query, cancellationToken);
            return Ok(result.Value);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAllProductRequest request, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(_mapper.Map(request), cancellationToken);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var command = new DeleteProductCommand(id);
            var result = await _sender.Send(command, cancellationToken);
            return Ok(result);
        }
    }
}
