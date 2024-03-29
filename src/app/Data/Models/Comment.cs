namespace RecipeBook.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Context;

public class Comment : IEntity
{
    [Key]
    public long Id { get; set; }

    [Required]
    [MinLength(3)]
    public string Text { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime Time { get; set; }

    [ForeignKey("UserId")]
    public virtual User? User { get; set; }

    [ForeignKey("RecipeId")]
    public virtual Recipe? Recipe { get; set; }

    public Comment(string text, DateTime time)
    {
        Text = text;
        Time = time;
    }
}
