using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Models;

namespace RestWithASPNETUdemy.Repository
{
    public interface IUserRepository
    {
        User ValidateCredential(UserVO user);

        User ValidateCredential(string username);

        bool RevokeToken(string username);

        User UpdateRefreshUserInfo(User user);
    }
}
