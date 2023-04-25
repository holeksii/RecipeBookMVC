using System.ComponentModel.DataAnnotations;
using RecipeBook.Data.Models;

namespace RecipeBook.Business.Models;

public class LikeModel
{
    public long Id { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime Time { get; set; }

    public LikeModel(DateTime time)
    {
        Time = time;
    }

    public static Like mapLikeModel(LikeModel model)
    {
        return new Like(model.Time);
    }
}
