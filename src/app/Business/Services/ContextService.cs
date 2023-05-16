using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace RecipeBook.Business.Services;

public class ContextService : IContextService
{
    private readonly IHttpContextAccessor _httpContext;

    public ContextService(IHttpContextAccessor httpContext)
    {
        _httpContext = httpContext;
    }

    public string GetUserId()
    {
        return _httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}