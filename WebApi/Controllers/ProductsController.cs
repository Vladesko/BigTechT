using Application.Products.Commands.DeleteProduct;
using Application.Products.Queries.GetAll;
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
        private readonly ISender _sender; //Need for send command or query to MediatR
        private readonly IMapper _mapper; //Need for map from requsts to commands or queries
        public ProductsController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }
        /// <summary>
        /// Create new product
        /// </summary>
        /// <param name="request">Request for create product</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductRequest request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var result = await _sender.Send(_mapper.Map(request), cancellationToken);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok(result.Value); //Value is id of created product
        }
        /// <summary>
        /// Get product by id
        /// </summary>
        /// <param name="id">id as int</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var query = new GetProductByIdQuery(id);
            var result = await _sender.Send(query, cancellationToken);

            if(result.IsFailure)
                return BadRequest(result.Error);

            return Ok(result.Value); //Value is a product with all parametrs
        }
        /// <summary>
        /// Get all products 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var query = new GetAllProductQuery();
            var result = await _sender.Send(query, cancellationToken);

            if(result.IsFailure)
                return BadRequest(result.Error);

            return Ok(result.Value); //Collection of products
        }
        /// <summary>
        /// Update all parametrs in product by id
        /// </summary>
        /// <param name="request">Parametrs and id of product</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAllProductRequest request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _sender.Send(_mapper.Map(request), cancellationToken);

            if(result.IsFailure)
                return BadRequest(result.Error);

            return Ok(result);
        }
        /// <summary>
        /// Delete product by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var command = new DeleteProductCommand(id);
            var result = await _sender.Send(command, cancellationToken);
           
            if(result.IsFailure) 
                return BadRequest(result.Error);

            return Ok(result);
        }
    }
}
