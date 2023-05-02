namespace RecipeBook.Business.Services;

using Data.Repositories;
using Data.Models;
using Business.Models;
using AutoMapper;

public class RecipeService : IRecipeService
{
    private readonly RecipeRepository _repository;
    private readonly Mapper _mapper;

    public RecipeService(RecipeRepository recipeRepository)
    {
        _repository = recipeRepository;
        var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Recipe, RecipeDetailsDTO>();
                cfg.CreateMap<Recipe, RecipeDTO>().ConvertUsing(r => RecipeDTO.mapRecipe(r));
                cfg.CreateMap<RecipeDetailsDTO, Recipe>();
            });
        _mapper = new Mapper(configuration);
    }

    public List<RecipeDTO>? GetAllRecipes()
    {
        var recipes = _repository.GetAll();
        if (recipes != null)
        {
            return _mapper.Map<List<Recipe> ,List<RecipeDTO>>(recipes);
        }
        return null;
    }

    public List<RecipeDTO>? GetUserRecipes(string id)
    {
        var recipes = _repository.GetUserRecipes(id);
        if (recipes != null)
        {
            return _mapper.Map<List<Recipe>, List<RecipeDTO>>(recipes);
        }
        return null;
    }

    public List<RecipeDTO>? GetLikedRecipes(string id)
    {
        var recipes = _repository.GetUserLikedRecipes(id);
        if (recipes != null)
        {
            return _mapper.Map<List<Recipe>, List<RecipeDTO>>(recipes);
        }
        return null;
    }

    public List<RecipeDTO>? GetRecipesSortedBy(string field, List<RecipeDTO> list)
    {
        return field switch
        {
            "Likes" => list.OrderByDescending(x => x.LikesCount).ToList(),
            "Comments" => list.OrderByDescending(x => x.CommentsCount).ToList(),
            "Time" => list.OrderByDescending(x => x.TimeToCook).ToList(),
            _ => list.OrderByDescending(x => x.Id).ToList(),
        };
    }

    public RecipeDetailsDTO? GetRecipe(long id)
    {
        var recipe = _repository.Get(id);
        if (recipe != null)
        {
            return _mapper.Map<RecipeDetailsDTO>(recipe);
        }
        return null;
    }

    public RecipeDetailsDTO? AddRecipe(string userId, RecipeDetailsDTO recipeDTO)
    {
        Recipe recipe = _mapper.Map<Recipe>(recipeDTO);
        recipe = _repository.Add(userId, recipe);
        if(recipe != null)
        {
            return _mapper.Map<RecipeDetailsDTO>(recipe);
        }
        return null;
    }
}
