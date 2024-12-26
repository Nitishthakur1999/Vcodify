using VCodify.DatabaseEntities;
using VCodify.Models;

namespace VCodify.Services.Repositories
{
    public interface IRepository
    {
        #region Enquiry

        Task<ApiResponseModel> GetEnquriesList();
        Task<ApiResponseModel> GetEnquriesById(int id);
        Task<ApiResponseModel> GetEnquiryDetailById(int id);

        Task<ApiResponseModel> SaveEnquries(EnquiryVM ser);

        #endregion Enquiry

        #region Login Api
        Task<Users> UpdateAuthToken(LoginVM userprofilemodel);
        Task<LoginVM> GetAdminUser(LoginVM loginViewModel);

        #endregion Login Api
    }
}
