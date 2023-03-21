using Microsoft.AspNetCore.Mvc;

namespace FirstMVCApp.Controllers
{
    public class AccountController : Controller
    {
        public async Task Login(string returnURL = "/")
        {
            var authenticationProperties =new LoginAuthenticationPropertiesBuilder()
                .WithRedirectUri(returnURL)
                .Build();
            await HttpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
        }
        [Authorize]
        public async Task Logout()
        {
            var authenticationProperties = new LogoutAuthenticationPropertiesBuilder()
                .WithRedirectUri(Url.Action("Index","Home"))
                .Build();
            await HttpContext.SignOutAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
       /*public IActionResult Index()
        {
            return View();
       }*/
    }

}
