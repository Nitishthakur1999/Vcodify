using System.Security.Claims;

namespace VCodify.Services.Services
{
    
        public class LoginUserIdentity : ILoginUserIdentity
        {
            private readonly IHttpContextAccessor _httpContext;
            public LoginUserIdentity(IHttpContextAccessor httpContext)
            {
                _httpContext = httpContext;
            }
            public string GetUserID()
            {
                var user = _httpContext.HttpContext.User;
                var s = user.FindFirstValue(ClaimTypes.Name);
                return s;
            }
            public string GetUserRole()
            {
                return _httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.Role);
            }
        }
    }

