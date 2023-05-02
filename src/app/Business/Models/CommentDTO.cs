using RecipeBook.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RecipeBook.Business.Models;

public class CommentDTO
{
    public long Id { get; set; }

    [Required]
    [MinLength(3)]
    public string Text { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime Time { get; set; }

    public CommentDTO(string text, DateTime time)
    {
        Text = text;
        Time = time;
    }

    public static Comment mapCommentModel(CommentDTO model)
    {
        return new Comment(model.Text, model.Time);
    }
}
