using System.ComponentModel.DataAnnotations;
using RecipeBook.DAL.Models;

namespace RecipeBook.BLL.Models;

public class CategoryModel
{
    public long Id { get; set; }

    [Required]
    [MinLength(3)]
    public string Name { get; set; }

    public CategoryModel(string name)
    {
        Name = name;
    }

    public CategoryModel(Category category)
    {
        Id = category.Id;
        Name = category.Name;
    }
}
