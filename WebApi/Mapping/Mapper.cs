using Application.Products.Commands.CreateProduct;
using Application.Products.Commands.UpdateProduct;
using HttpModels.Products.Command.Create;
using HttpModels.Products.Command.Update;

namespace WebApi.Mapping
{
    internal class Mapper : IMapper
    {
        public CreateProductCommand Map(CreateProductRequest request) =>
            new CreateProductCommand(request.Name, request.Price);

        public UpdateAllProductCommand Map(UpdateAllProductRequest request) =>
            new UpdateAllProductCommand(request.Id, request.Name, request.Price);
    }
}
