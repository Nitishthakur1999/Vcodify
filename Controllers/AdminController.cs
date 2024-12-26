using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using VCodify.Models;
using VCodify.Services.Configuration;
using VCodify.Services.Extensions;
namespace VCodify.Controllers
{
    public class AdminController : Controller
    {
        private readonly HttpClient _client;
        private readonly ILogger<HomeController> _logger;
        private readonly IOptions<BaseUrl> _baseurl;
        private readonly IHttpContextAccessor _httpContextAccessor;
        HttpResponseMessage responseMessage = new HttpResponseMessage();
        public AdminController(IOptions<BaseUrl> baseurl, IHttpContextAccessor httpContextAccessor, ILogger<HomeController> logger)
        {
            _logger = logger;
            _baseurl = baseurl;
            _client = new HttpClient();
            _client.BaseAddress = new Uri(_baseurl.Value.BASE_URL);
            _httpContextAccessor = httpContextAccessor;

        }
        public IActionResult Index()
        {
            if (!IdentityExtention.CheckSuperadminIdentity(_httpContextAccessor))
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }
        #region EnquiryList


        [HttpGet]

        public async Task<ActionResult> EnquiryList(int Id)
        {

            if (!IdentityExtention.CheckSuperadminIdentity(_httpContextAccessor))
            {
                return RedirectToAction("Login", "Home");
            }
                EnquiryVM enquiry = new EnquiryVM();
            if (Id > 0)
            {
                try
                {

                    responseMessage = await _client.GetAsync("api/GetEnquiryDetailById/" + Id);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                        var response = JsonConvert.DeserializeObject<ApiResponseModel>(responseData);
                        if (response != null && response.Data != null)
                        {
                            enquiry = JsonConvert.DeserializeObject<EnquiryVM>(response.Data.ToString());
                        }
                    }


                }
                catch (Exception ex)
                {

                }
            }


            responseMessage = await _client.GetAsync("api/GetEnquriesList/");
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                var response = JsonConvert.DeserializeObject<ApiResponseModel>(responseData);
                if (response != null && response.Data != null)
                {
                    enquiry.EnquiryList = JsonConvert.DeserializeObject<List<EnquiryVM>>(response.Data.ToString()).ToList();
                }
            }
            return View(enquiry);
        }


        #endregion EnquiryList



    }
}
