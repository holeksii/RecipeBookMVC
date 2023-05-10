namespace RecipeBook.Business.Services;

using Data.Repositories;
using Data.Models;
using Models;
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
            cfg.CreateMap<Recipe, RecipeDetailsDTO>()
                .ConstructUsing(r => RecipeDetailsDTO.mapRecipe(r));
            cfg.CreateMap<Recipe, RecipeDTO>().ConvertUsing(r => RecipeDTO.mapRecipe(r));
            cfg.CreateMap<RecipeDetailsDTO, Recipe>()
                .ConstructUsing(rdto => RecipeDetailsDTO.mapRecipeDetailsDTO(rdto));
        });
        _mapper = new Mapper(configuration);
    }

    public List<RecipeDTO>? GetAllRecipes()
    {
        var recipes = _repository.GetAll();
        return recipes is not null ? _mapper.Map<List<Recipe>, List<RecipeDTO>>(recipes) : null;
    }

    public List<RecipeDTO>? GetUserRecipes(string id)
    {
        var recipes = _repository.GetUserRecipes(id);
        return recipes is not null ? _mapper.Map<List<Recipe>, List<RecipeDTO>>(recipes) : null;
    }

    public List<RecipeDTO>? GetLikedRecipes(string id)
    {
        var recipes = _repository.GetUserLikedRecipes(id);
        return _mapper.Map<List<Recipe>, List<RecipeDTO>>(recipes);
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
        return recipe is not null ? _mapper.Map<RecipeDetailsDTO>(recipe) : null;
    }

    public void DeleteRecipe(long id)
    {
        _repository.Delete(id);
    }

    public RecipeDetailsDTO? AddRecipe(string userId, long categoryId, RecipeDetailsDTO recipeDTO)
    {
        Recipe recipe = _mapper.Map<Recipe>(recipeDTO);
        recipe = _repository.Add(userId, categoryId, recipe);
        return recipe is not null ? _mapper.Map<RecipeDetailsDTO>(recipe) : null;
    }
}