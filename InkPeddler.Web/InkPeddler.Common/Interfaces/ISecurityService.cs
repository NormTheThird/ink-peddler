using InkPeddler.Common.RequestAndResponses;
using System.Threading.Tasks;

namespace InkPeddler.Common.Interfaces
{
    public interface ISecurityService
    {
        Task<RegisterUserResponse> RegisterUserWithDeviceTokenAsync(RegisterUserWithDeviceTokenRequest request);
        Task<RegisterUserResponse> RegisterUserWithEmailAsync(RegisterUserWithEmailRequest request);
        Task<AuthenticateUserResponse> AuthenticateUser(AuthenticateUserRequest request);
        Task<RefreshUserAuthenticationResponse> RefreshUserAuthenticationAsync(RefreshUserAuthenticationRequest request);
    }
}