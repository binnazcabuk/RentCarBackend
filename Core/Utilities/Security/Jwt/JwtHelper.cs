
using Core.Entities.Concrete;
using Core.Extension;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        //using Microsoft.Extensions.Configuration;----->ıconfiguration
        //appsetting dosyasının içini okumaya yarar
        public IConfiguration Configuration { get; }

        //dosya içerisindeki okuduğum değerleri bir tokenOptions nesnesine atıyorum
        private TokenOptions _tokenOptions;
        //token geçersiz olacağı tarih
        private DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            //appsetting içerisinde tokenoptions bölümünü al içeriğini tek tek token options nesnesine ata
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

        }
        //user ve yetki bilgisine göre token oluşturma
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            //ne zaman geçersiz olacak bilgisi
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);

            //security keyimi veriyorum
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);

            //imzayı veriyorum
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);

            //tüm bilgiler doğrutulsunda tokenı oluştur.
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());

            return claims;
        }
    }
}
