using RecipeBook.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RecipeBook.Business.Models;

public class CommentModel
{
    public long Id { get; set; }

    [Required]
    [MinLength(3)]
    public string Text { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime Time { get; set; }

    public CommentModel(string text, DateTime time)
    {
        Text = text;
        Time = time;
    }

    public static Comment mapCommentModel(CommentModel model)
    {
        return new Comment(model.Text, model.Time);
    }
}
