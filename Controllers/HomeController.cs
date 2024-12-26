using Microsoft.AspNetCore.Mvc;
using System.Text;
using VCodify.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
using VCodify.Services.Configuration;
using VCodify.Services.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
namespace VCodify.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _client;
        private readonly ILogger<HomeController> _logger;
        private readonly IOptions<BaseUrl> _baseurl;
        private readonly IHttpContextAccessor _httpContextAccessor;
        HttpResponseMessage responseMessage = new HttpResponseMessage();
        public HomeController(IOptions<BaseUrl> baseurl, IHttpContextAccessor httpContextAccessor, ILogger<HomeController> logger)
        {
            _logger = logger;
            _baseurl = baseurl;
            _client = new HttpClient();
            _client.BaseAddress = new Uri(_baseurl.Value.BASE_URL);
            _httpContextAccessor = httpContextAccessor;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Project()
        {
            return View();
        }

        public IActionResult Service()
        {
            return View();
        }
        public IActionResult Testimonial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Enquiry(EnquiryVM models)
        {
            // Check if the model is valid
            if (!ModelState.IsValid)
            {
                // If the model is not valid, return to the Contact view with the current model
                return View(models);
            }


            var content = new StringContent(JsonConvert.SerializeObject(models), Encoding.UTF8, "application/json");
            responseMessage = await _client.PostAsync("api/SaveEnquires/", content);



            TempData["message"] = "Enquiry Submitted Successfully.";
            return RedirectToAction("Index", "Home");

        }
        #region Login


        [Route("Login")]
        [HttpGet]

        public IActionResult Login()
        {
            return View();
        }
        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM login)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");
                responseMessage = await _client.PostAsync("api/LoginApi/", content);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    if (string.IsNullOrEmpty(responseData))
                    {
                        ModelState.AddModelError(string.Empty, "You have entered incorrect email or password.");
                        return View(login); // Return the same view with the error
                    }
                    else
                    {
                        var loginViewModel = JsonConvert.DeserializeObject<LoginVM>(responseData);
                        var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, loginViewModel.Id.ToString()),
                    new Claim(ClaimTypes.GivenName, loginViewModel.FirstName),
                    new Claim(ClaimTypes.Email, loginViewModel.Email),
                    new Claim(ClaimTypes.Role, loginViewModel.UserType.ToString()),
                };

                        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);
                        var props = new AuthenticationProperties
                        {
                            IsPersistent = loginViewModel.RememberMe
                        };

                        await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props);
                         return RedirectToAction("EnquiryList", "Admin");
                    }
                }

                ModelState.AddModelError(string.Empty, "Login failed. Please try again.");
                return View(login); // Return the view with the error
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred. Please try again.");
                return View(login); // Handle any other exceptions
            }
        }


        #endregion Login
        public async Task<IActionResult> Logout()
        {
            // Clear the user's authentication information
            await HttpContext.SignOutAsync(); // Use this if you're using cookie authentication

            // Redirect to the login page or home page
            return RedirectToAction("Index", "Home"); // Change "Account" to your controller name
        }

    }
}
