using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Implement_Identity_In_MVC_App.Models
{
    public class UserInfo : IUserInfo
    {
        private readonly IHttpContextAccessor httpContext;

        public UserInfo(IHttpContextAccessor _httpContext)
        {
            httpContext = _httpContext;
        }
        public string getUserId()
        {
            return httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);

        }
    }
}
