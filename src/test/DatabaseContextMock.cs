using Moq;
using RecipeBook.Data.Models;

namespace RecipeBookTest;

public class DatabaseContextMock
{
    public Mock<HashSet<User>> Users { get; set; }

    public Mock<HashSet<Recipe>> Recipes { get; set; }

    public DatabaseContextMock()
    {
        Users = new();
        Recipes = new();
        InitMockMethods();
    }

    void InitMockMethods()
    {
        Users.Setup(r =>
                r.Add(It.IsAny<User>())).
            Returns(true);
    }
}
