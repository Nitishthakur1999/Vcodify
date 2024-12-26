
using Microsoft.AspNetCore.Authorization;
using VCodify.DatabaseEntities;
using VCodify.Models;
using VCodify.Services.Repositories;
namespace VCodify.Services.Services

{
    public class Services : IServices
    {
        public readonly IRepository _iRepository;
        public readonly ICryptoServices _cryptoService;
        public Services(IRepository iRepository, ICryptoServices cryptoService)
        {
            _iRepository = iRepository;
            _cryptoService = cryptoService;

        }

        public async Task<ApiResponseModel> GetEnquriesList()
        {
            return await _iRepository.GetEnquriesList();
        }

        public async Task<ApiResponseModel> GetEnquriesById(int id)
        {
            return await _iRepository.GetEnquriesById(id);
        }

        public async Task<ApiResponseModel> GetEnquiryDetailById(int id)
        {
            return await _iRepository.GetEnquiryDetailById(id);
        }
       

        public async Task<ApiResponseModel> SaveEnquries(EnquiryVM ser)
        {
            return await _iRepository.SaveEnquries(ser);
        }
        #region Login
        [AllowAnonymous]
        public async Task<LoginVM> Authenticate(LoginVM loginmodel)
        {
            LoginVM loginViewModel = new LoginVM();
            loginViewModel = await _iRepository.GetAdminUser(loginmodel);
            if (loginViewModel == null)
            {
                return null;
            }
            if (!await _cryptoService.ValidatePassword(loginmodel.Password, loginViewModel.Salt, loginViewModel.Password))
            {
                // _logger.LogError($"Password is invalid for '{loginViewModel.Email}' not found!");
                return null;
            }


            //var updateuser = await _iRepository.UpdateAuthToken(loginViewModel);
            loginViewModel.Password = null;
            loginViewModel.Salt = null;
            return loginViewModel;
        }

        #endregion Login

    }
}
