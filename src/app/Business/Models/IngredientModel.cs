using System.ComponentModel.DataAnnotations;
using RecipeBook.DAL.Models;

namespace RecipeBook.BLL.Models;

public class IngredientModel
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

    public IngredientModel(string name, int quantity, string measure)
    {
        Name = name;
        Quantity = quantity;
        Measure = measure;
    }

    public static Ingredient mapIngredientModel(IngeredientModel model)
    {
        return new Like(model.Time);
    }
}
