using Application.Products.Commands.CreateProduct;
using Application.Products.Commands.UpdateProduct;
using HttpModels.Products.Command.Create;
using HttpModels.Products.Command.Update;

namespace WebApi.Mapping
{
    public interface IMapper
    {
        CreateProductCommand Map(CreateProductRequest request);
        UpdateAllProductCommand Map(UpdateAllProductRequest request);
    }
}
