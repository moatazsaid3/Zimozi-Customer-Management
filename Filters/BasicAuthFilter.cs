using CustomerManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

namespace CustomerManagement.Filters
{
    public class BasicAuthFilter : IAsyncAuthorizationFilter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;

        public BasicAuthFilter(IHttpContextAccessor httpContextAccessor, IUserService userService)
        {
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
        }
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var path = context.HttpContext.Request.Path.Value?.ToLower();

            // Allow anonymous access to login page and static files
            if (path == "/login" || path.StartsWith("/css") || path.StartsWith("/js") || path.StartsWith("/images") || path == "/favicon.ico")
            {
                return;
            }

            var session = context.HttpContext.Session;
            if (session.GetString("IsAuthenticated") == "true")
                return;

            // Optional: If you want to still support Basic Auth header, keep this block:
            var authHeader = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
            if (authHeader != null && authHeader.StartsWith("Basic "))
            {
                var encodedCredentials = authHeader.Substring("Basic ".Length).Trim();
                var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(encodedCredentials));
                var parts = credentials.Split(':');

                if (parts.Length == 2 && _userService.ValidateUser(parts[0], parts[1]))
                {
                    session.SetString("IsAuthenticated", "true");
                    session.SetString("Username", parts[0]);
                    return;
                }
            }

            // Redirect unauthorized users to login page
            context.Result = new RedirectToActionResult("Index", "Login", null);
        }


    }

}
