using System.ComponentModel.DataAnnotations;
using RecipeBook.Data.Models;

namespace RecipeBook.Business.Models;

public class CategoryDTO
{
    public long Id { get; set; }

    [Required]
    [MinLength(3)]
    public string Name { get; set; }

    public CategoryDTO(string name)
    {
        Name = name;
    }

    public static CategoryDTO mapCategory(Category category)
    {
        CategoryDTO model = new CategoryDTO(category.Name);
        model.Id = category.Id;
        return model;
    }
    public static Category mapCategoryModel(CategoryDTO model)
    {
        return new Category(model.Name);
    }
}
