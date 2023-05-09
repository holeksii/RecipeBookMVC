namespace RecipeBook.Business.Services;

using Data.Models;
using Business.Models;

public interface ICategoryService
{
    public CategoryDTO? AddNewCategory(string name);

    public List<CategoryDTO> GetAll();
}