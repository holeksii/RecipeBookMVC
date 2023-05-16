namespace RecipeBook.Data.Models.Builders;

public interface IBuilder<out T>
{
    public T Build();
}
