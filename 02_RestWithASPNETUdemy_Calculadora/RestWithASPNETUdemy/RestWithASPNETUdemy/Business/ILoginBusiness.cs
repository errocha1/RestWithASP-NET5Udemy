using RestWithASPNETUdemy.Data.VO;

namespace RestWithASPNETUdemy.Business
{
    public interface ILoginBusiness
    {
        TokenVO ValidationCredentials(UserVO user);

        TokenVO ValidationCredentials(TokenVO token);

        bool RevokeToken(string username);
    }
}
