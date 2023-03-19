using System.ComponentModel.DataAnnotations;

namespace RecipeBookMVC.Models;

public class Category
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
