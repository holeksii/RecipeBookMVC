namespace RecipeBook.Business.Services;

using Data.Repositories;
using Data.Models;
using Business.Models;
using AutoMapper;

public class CategoryService : ICategoryService
{
    private readonly CategoryRepository _repository;
    private readonly Mapper _mapper;

    public CategoryService(CategoryRepository categoryRepository)
    {
        _repository = categoryRepository;
        var configuration = new MapperConfiguration( cfg => {
        cfg.CreateMap<Category, CategoryDTO>();
        cfg.CreateMap<CategoryDTO, Category>();
        });
        _mapper = new Mapper(configuration);
    }

    public CategoryDTO? AddNewCategory(string name)
    {
        var category = _repository.Add(new Category(name));
        return _mapper.Map<CategoryDTO>(category);
    }

    public List<CategoryDTO> GetAll()
    {
        var categories = _repository.GetAll();
        if (categories != null)
        {
            return _mapper.Map<List<Category>, List<CategoryDTO>>(categories);
        }
        return null;
    }
}