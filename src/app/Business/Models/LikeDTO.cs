using System.ComponentModel.DataAnnotations;
using RecipeBook.Data.Models;

namespace RecipeBook.Business.Models;

public class LikeDTO
{
    public long Id { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime Time { get; set; }

    public LikeDTO(DateTime time)
    {
        Time = time;
    }

    public static Like mapLikeModel(LikeDTO model)
    {
        return new Like(model.Time);
    }
}
