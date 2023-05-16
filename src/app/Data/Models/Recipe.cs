namespace RecipeBook.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Builders;
using Context;

public class Recipe : IEntity
{
    [Key]
    public long Id { get; set; }

    [Range(1, 1000, ErrorMessage =
        "The value must be between 1 and 1000")]
    public int TimeToCook { get; set; }

    [Required]
    [MinLength(3)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MinLength(10)]
    public string Instructions { get; set; } = string.Empty;

    [Url]
    public string? ImageUrl { get; set; }

    [Required]
    [ForeignKey("CategoryId")]
    public virtual Category? Category { get; set; }

    [ForeignKey("UserId")]
    public virtual User? User { get; set; }

    [Required]
    public List<Ingredient> Ingredients { get; set; } = new();

    public List<Like> Likes { get; set; } = new();

    public List<Comment> Comments { get; set; } = new();

    public void AddIngredient(Ingredient ingredient)
    {
        Ingredients.Add(ingredient);
    }

    public void RemoveIngredient(Ingredient ingredient)
    {
        Ingredients.Remove(ingredient);
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

    public static RecipeBuilder CreateBuilder() => new();
}
