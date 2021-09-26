using RestWithASPNETUdemy.Configurations;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Repository;
using RestWithASPNETUdemy.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class LoginBusinessImplementation : ILoginBusiness
    {
        private const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";
        private TokenConfiguration _configuration;
        private IUserRepository _repository;
        private readonly ITokenService _tokenService;

        public LoginBusinessImplementation(TokenConfiguration configuration, IUserRepository repository, ITokenService tokenService)
        {
            _configuration = configuration;
            _repository = repository;
            _tokenService = tokenService;
        }

        public TokenVO ValidationCredentials(UserVO userCredentials)
        {
            // valida o usuário
            var user = _repository.ValidateCredential(userCredentials);

            if (user == null) return null;

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName,user.UserName)

            };

            // Criar o access token
            var accessToken = _tokenService.GenerateAccessToKen(claims);

            // Criar o refresh token
            var refreshToken = _tokenService.GenerateRefreshToken();

            // Atualizamos as informações do token no usuário
            user.RefreshToKen = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(_configuration.DaysToExpire);

            _repository.UpdateRefreshUserInfo(user);

            DateTime createDate = DateTime.Now;
            DateTime expireDate = createDate.AddMinutes(_configuration.Minutes);

            // Seta as informações do Token
            return new TokenVO(
                true,
                createDate.ToString(DATE_FORMAT),
                expireDate.ToString(DATE_FORMAT),
                accessToken,
                refreshToken
             );
        }

        public TokenVO ValidationCredentials(TokenVO token)
        {
            var accessToken = token.AccessToken;           
            var refreshToken = token.RefreshToken;
            var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken);
            var username = principal.Identity.Name;
            var user = _repository.ValidateCredential(username);

            if (user == null ||
                user.RefreshToKen != refreshToken ||
                user.RefreshTokenExpiryTime <= DateTime.Now) return null;

            accessToken = _tokenService.GenerateAccessToKen(principal.Claims);
            refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToKen = refreshToken;

            // Atualizamos as informações do token no usuário
            user.RefreshToKen = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(_configuration.DaysToExpire);

            _repository.UpdateRefreshUserInfo(user);

            DateTime createDate = DateTime.Now;
            DateTime expireDate = createDate.AddMinutes(_configuration.Minutes);

            // Seta as informações do Token
            return new TokenVO(
                true,
                createDate.ToString(DATE_FORMAT),
                expireDate.ToString(DATE_FORMAT),
                accessToken,
                refreshToken
             );
        }

        public bool RevokeToken(string userName)
        {
            return _repository.RevokeToken(userName);
        }
    }
}
