using System.ComponentModel.DataAnnotations;
using RecipeBook.Data.Models;

namespace RecipeBook.Business.Models;

public class IngredientDTO
{
    public long Id { get; set; }

    [Required]
    [MinLength(3)]
    public string Name { get; set; }

    [Required]
    [Range(0, 1000)]
    public int Quantity { get; set; }

    [RegularExpression("^(kg|g|l|ml|pcs)$")]
    public string Measure { get; set; }

    public IngredientDTO(string name, int quantity, string measure)
    {
        Name = name;
        Quantity = quantity;
        Measure = measure;
    }

    public static Ingredient mapIngredientModel(IngredientDTO model)
    {
        return new Ingredient(model.Name, model.Quantity, model.Measure);
    }
}
