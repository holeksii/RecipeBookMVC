using System.ComponentModel.DataAnnotations;
using RecipeBook.Data.Models;

namespace RecipeBook.Business.Models;

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

    public static CategoryModel mapCategory(Category category)
    {
        CategoryModel model = new CategoryModel(category.Name);
        model.Id = category.Id;
        return model;
    }
    public static Category mapCategoryModel(CategoryModel model)
    {
        return new Category(model.Name);
    }
}
