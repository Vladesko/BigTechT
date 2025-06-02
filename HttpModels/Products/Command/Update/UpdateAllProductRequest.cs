using System.ComponentModel.DataAnnotations;

namespace HttpModels.Products.Command.Update
{
    public record UpdateAllProductRequest(
        int Id,
        [Required]
        string Name,
        [Required]
        decimal Price
        );
}
