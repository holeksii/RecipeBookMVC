namespace RecipeBook.DAL.Models.Builders;

public interface IBuilder<out T>
{
    public T Build();
}
