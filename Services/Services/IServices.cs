using VCodify.DatabaseEntities;
using VCodify.Models;
namespace VCodify.Services.Services




{
    public interface IServices
    {
        #region Enquiry

        Task<ApiResponseModel> GetEnquriesList();
        Task<ApiResponseModel> GetEnquriesById(int id);
        Task<ApiResponseModel> GetEnquiryDetailById(int id);
        Task<ApiResponseModel> SaveEnquries(EnquiryVM ser);
        #endregion Enquiry

        #region Login Api
        Task<LoginVM> Authenticate(LoginVM loginViewModel);

        #endregion Login Api
    }
}
