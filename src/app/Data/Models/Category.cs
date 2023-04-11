namespace RecipeBook.Data.Models;

using System.ComponentModel.DataAnnotations;
using RecipeBook.Data.Context;

public class Category : IEntity
{
    [Key]
    public long Id { get; set; }

    [Required]
    [MinLength(3)]
    public string Name { get; set; }

    public Category(string name)
    {
        Name = name;
    }
}
