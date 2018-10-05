using Microsoft.Extensions.Primitives;

namespace api.Services
{
    public interface IUserService
    {
        int CurrentUserId { get; }
        void SetCurrentUser(string phone);
    }
}