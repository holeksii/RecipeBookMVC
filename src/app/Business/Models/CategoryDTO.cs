using System.ComponentModel.DataAnnotations;
using RecipeBook.Data.Models;

namespace RecipeBook.Business.Models;

public class CategoryDTO
{
    public long Id { get; set; }

    [Required]
    [MinLength(3)]
    public string Name { get; set; }

    public List<Recipe> Recipes { get; set; } = new();

    public CategoryDTO(string name)
    {
        Name = name;
    }
}
