using API.Requests;

namespace API.Services
{
    public interface IUserService
    {
        Task<string> SignUpAsync(SignupRequest request);
    }
}
