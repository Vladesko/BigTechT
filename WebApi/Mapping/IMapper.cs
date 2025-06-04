using Application.Products.Commands.CreateProduct;
using Application.Products.Commands.UpdateProduct;
using HttpModels.Products.Command.Create;
using HttpModels.Products.Command.Update;

namespace WebApi.Mapping
{
    public interface IMapper
    {
        /// <summary>
        /// Map from create request model to create command model
        /// </summary>
        /// <param name="request">Request to create from frontend</param>
        /// <returns>Create command model</returns>
        CreateProductCommand Map(CreateProductRequest request);
        /// <summary>
        /// Map from update all product request to update all product command model
        /// </summary>
        /// <param name="request">Request to update all from frontend</param>
        /// <returns>Update all command model</returns>
        UpdateAllProductCommand Map(UpdateAllProductRequest request);
    }
}
