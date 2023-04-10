namespace RecipeBook.DAL.Models.Builders;

public class RecipeBuilder : IBuilder<Recipe>
{
    private readonly Recipe _recipe;

    public RecipeBuilder()
    {
        _recipe = new Recipe();
    }

    public RecipeBuilder SetTimeToCook(int timeToCook)
    {
        _recipe.TimeToCook = timeToCook;
        return this;
    }

    public RecipeBuilder SetName(string name)
    {
        _recipe.Name = name;
        return this;
    }

    public RecipeBuilder SetInstructions(string instructions)
    {
        _recipe.Instructions = instructions;
        return this;
    }

    public RecipeBuilder SetImageUrl(string imageUrl)
    {
        _recipe.ImageUrl = imageUrl;
        return this;
    }

    public RecipeBuilder SetCategory(Category category)
    {
        _recipe.Category = category;
        return this;
    }

    public RecipeBuilder SetUser(User user)
    {
        _recipe.User = user;
        return this;
    }

    public RecipeBuilder AddIngredient(Ingredient ingredient)
    {
        _recipe.AddIngredient(ingredient);
        return this;
    }

    public RecipeBuilder AddLike(Like like)
    {
        _recipe.AddLike(like);
        return this;
    }

    public RecipeBuilder AddComment(Comment comment)
    {
        _recipe.AddComment(comment);
        return this;
    }

    public Recipe Build()
    {
        return _recipe;
    }
}
