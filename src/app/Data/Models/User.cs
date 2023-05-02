namespace RecipeBook.Data.Models;

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Context;

public class User : IdentityUser, IEntity
{
    [Url]
    public string ImageUrl { get; set; } = string.Empty;

    public List<Recipe> Recipes { get; set; } = new();

    public List<Like> Likes { get; set; } = new();

    public List<Comment> Comments { get; set; } = new();

    public void AddRecipe(Recipe recipe)
    {
        Recipes.Add(recipe);
    }

    public void RemoveRecipe(Recipe recipe)
    {
        Recipes.Remove(recipe);
    }

    public void AddLike(Like like)
    {
        Likes.Add(like);
    }

    public void RemoveLike(Like like)
    {
        Likes.Remove(like);
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public void RemoveComment(Comment comment)
    {
        Comments.Remove(comment);
    }
}
