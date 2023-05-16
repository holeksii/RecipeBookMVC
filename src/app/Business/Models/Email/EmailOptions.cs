using System.Collections.Generic;

namespace RecipeBook.Business.Models;

public class EmailOptions
{
    public string ToEmail { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
}