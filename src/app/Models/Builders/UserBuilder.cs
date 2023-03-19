namespace RecipeBookMVC.Models.Builders;

public class UserBuilder : IBuilder<User>
{
    private User _user;

    public UserBuilder()
    {
        _user = new User();
    }

    public UserBuilder SetUsername(string username)
    {
        _user.Username = username;
        return this;
    }

    public UserBuilder SetEmail(string email)
    {
        _user.Email = email;
        return this;
    }

    public UserBuilder SetPassword(string password)
    {
        _user.Password = password;
        return this;
    }

    public UserBuilder SetImageUrl(string imageUrl)
    {
        _user.ImageUrl = imageUrl;
        return this;
    }

    public UserBuilder AddRecipe(Recipe recipe)
    {
        _user.AddRecipe(recipe);
        return this;
    }

    public UserBuilder AddLike(Like like)
    {
        _user.AddLike(like);
        return this;
    }

    public User Build()
    {
        return _user;
    }
}
