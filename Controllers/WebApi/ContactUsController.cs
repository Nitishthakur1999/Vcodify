using Microsoft.AspNetCore.Mvc;
using VCodify.Models;
using VCodify.DatabaseEntities;
using VCodify.Services.Services;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VCodify.Controllers.WebApi
{

    [ApiController]
    public class ContactUsController : ControllerBase
    {

        private readonly IServices _iServices;
        public ContactUsController(IServices iServices)
        {
            _iServices = iServices;
        }
        // POST api/<ContactUsController>
        [HttpPost]
        [Route("api/SaveEnquires/")]
        public async Task<IActionResult> SaveEnquries(EnquiryVM ser)
        {
            var data = await _iServices.SaveEnquries(ser);
            return Ok(data);
        }
        [HttpGet]
        [Route("api/GetEnquiryDetailById/{Id}")]
        public async Task<IActionResult> GetEnquiryDetailById(int Id)
        {
            var data = await _iServices.GetEnquiryDetailById(Id);
            return Ok(data);
        }
        [HttpGet]
        [Route("api/GetEnquriesList/")]
        public async Task<IActionResult> GetEnquriesList()
        {
            var data = await _iServices.GetEnquriesList();
            return Ok(data);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/LoginApi/")]
        public async Task<IActionResult> Authenticate(LoginVM users)
        {
            var data = await _iServices.Authenticate(users);
            return Ok(data);
        }

    }
}
