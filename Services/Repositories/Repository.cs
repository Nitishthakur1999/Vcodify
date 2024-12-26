using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VCodify.DatabaseEntities;
using VCodify.Models;
namespace VCodify.Services.Repositories
{
    public class Repository : IRepository
    {
        private readonly VcodifyContext _Context;
        private readonly IMapper _mapper;
        public Repository(VcodifyContext Context, IMapper mapper)
        {
            _Context = Context;
            _mapper = mapper;
        }

        public async Task<ApiResponseModel> GetEnquriesList()
        {
            try
            {
                var data = await _Context.Enquiry.OrderByDescending(x => x.CreatedOn).ToListAsync();

                if (data != null && data.Any())
                {
                    return new ApiResponseModel
                    {
                        Data = data,
                        Message = "Data fetched successfully",
                        StatusCode = (int)System.Net.HttpStatusCode.OK,

                    };
                }

                return new ApiResponseModel
                {
                    Message = "No data found",
                    StatusCode = (int)System.Net.HttpStatusCode.OK,

                };
            }
            catch (Exception ex)
            {
                return new ApiResponseModel
                {
                    Data = null,
                    Message = "Something went wrong while fetching data",
                    StatusCode = (int)System.Net.HttpStatusCode.BadRequest,
                    Status = false
                };
            }
        }
        public async Task<ApiResponseModel> GetEnquriesById(int Id)
        {
            try
            {
                var data = await _Context.Enquiry.Where(x => x.Id == Id).ToListAsync();
                if (data != null)
                {
                    return new ApiResponseModel()
                    {
                        Data = data,
                        Message = "Data fetch successfully",
                        StatusCode = Convert.ToInt32(System.Net.HttpStatusCode.OK),

                    };
                }
                // If data is empty, return a success response with an empty list
                return new ApiResponseModel
                {
                    Message = "No data found",
                    StatusCode = (int)System.Net.HttpStatusCode.OK,

                };
            }
            catch (Exception ex)
            {
                return new ApiResponseModel()
                {
                    Data = null,
                    Message = "Something went wrong",
                    StatusCode = Convert.ToInt32(System.Net.HttpStatusCode.BadRequest),
                    Status = false
                };
            }
        }

        public async Task<ApiResponseModel> GetEnquiryDetailById(int Id)
        {
            try
            {
                var data = await _Context.Enquiry.Where(x => x.Id == Id).FirstOrDefaultAsync();
                if (data != null)
                {
                    return new ApiResponseModel()
                    {
                        Data = data,
                        Message = "Data fetch successfully",
                        StatusCode = Convert.ToInt32(System.Net.HttpStatusCode.OK),

                    };
                }
                // If data is empty, return a success response with an empty list
                return new ApiResponseModel
                {
                    Message = "No data found",
                    StatusCode = (int)System.Net.HttpStatusCode.OK,

                };
            }
            catch (Exception ex)
            {
                return new ApiResponseModel()
                {
                    Data = null,
                    Message = "Something went wrong",
                    StatusCode = Convert.ToInt32(System.Net.HttpStatusCode.BadRequest),
                    Status = false
                };
            }
        }
        public async Task<ApiResponseModel> SaveEnquries(EnquiryVM ser)
        {
            try
            {
                var _ServiceModel = await AddEditEnquries(ser);
                if (_ServiceModel != null)
                {
                    return new ApiResponseModel()
                    {
                        Data = _ServiceModel.Id,
                        Message = "Data saved successfully",
                        StatusCode = Convert.ToInt32(System.Net.HttpStatusCode.OK),
                    };
                }
                return new ApiResponseModel()
                {
                    Data = null,
                    Message = "Something went wrong",
                    StatusCode = Convert.ToInt32(System.Net.HttpStatusCode.BadRequest),
                };
            }
            catch (Exception ex)
            {
                return new ApiResponseModel()
                {
                    Data = ex.Message,
                    Message = "Something went wrong",
                    StatusCode = Convert.ToInt32(System.Net.HttpStatusCode.BadRequest),
                };
            }
        }
        private async Task<Enquiry> AddEditEnquries(EnquiryVM Ser)
        {
            try
            {
                var Services = new Enquiry();
                if (Ser.Id != 0)
                {
                    Services = await _Context.Enquiry.FirstOrDefaultAsync(s => s.Id == Ser.Id);
                    if (Services != null)
                    {

                        _mapper.Map(Ser, Services);
                    }
                    else
                    {

                        Services = _mapper.Map<Enquiry>(Ser);
                    }
                }

                if (Ser.Id == 0)
                {
                    Ser.CreatedOn = DateTime.UtcNow.ToUniversalTime();
                    Services = _mapper.Map<Enquiry>(Ser);
                    await _Context.Enquiry.AddAsync(Services);
                }
                await _Context.SaveChangesAsync();
                return Services;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<LoginVM> GetAdminUser(LoginVM loginViewModel)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(loginViewModel.Email))
                    throw new ArgumentException("Email cannot be null or empty.");

                var user = await _Context.Users
                    .Where(u => u.Email.ToLower().Trim() == loginViewModel.Email.ToLower().Trim())
                    .Select(u => new LoginVM
                    {
                        Id = u.Id,
                        Email = u.Email,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Salt = u.Salt,
                        Password = u.Password,
                    })
                    .FirstOrDefaultAsync();

                if (user == null)
                    throw new InvalidOperationException("User not found.");

                return user;
            }
            catch (Exception ex)
            {
                // Log the error for debugging purposes
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                return null;
            }
        }



        public async Task<Users> UpdateAuthToken(LoginVM userprofilemodel)
        {
            try
            {
                var user = new Users();
                //if (userprofilemodel.Id != Guid.Empty)
                //{
                //    user = await _Context.User.FirstOrDefaultAsync(s => s.Id == userprofilemodel.Id);


                //}
                //await _CMSContext.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
