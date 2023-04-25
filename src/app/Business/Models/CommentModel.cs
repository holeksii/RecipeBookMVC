using RecipeBook.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RecipeBook.BLL.Models;

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
}
