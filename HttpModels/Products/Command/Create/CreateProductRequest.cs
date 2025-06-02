using System.ComponentModel.DataAnnotations;

namespace HttpModels.Products.Command.Create
{
    public record CreateProductRequest(
        [Required] 
        string Name, 
        [Required]  
        decimal Price);
}
