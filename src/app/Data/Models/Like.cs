namespace RecipeBook.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Context;

public class Like : IEntity
{
    [Key]
    public long Id { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime Time { get; set; }

    [ForeignKey("UserId")]
    public virtual User? User { get; set; }

    [ForeignKey("RecipeId")]
    public virtual Recipe? Recipe { get; set; }

    public Like(DateTime time)
    {
        Time = time;
    }
}
