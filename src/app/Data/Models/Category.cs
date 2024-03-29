namespace RecipeBook.Data.Models;

using System.ComponentModel.DataAnnotations;
using Context;

public class Category : IEntity
{
    [Key]
    public long Id { get; set; }

    [Required]
    [MinLength(3)]
    public string Name { get; set; }

    public List<Recipe> Recipes { get; set; } = new();

    public Category(string name)
    {
        Name = name;
    }
}
