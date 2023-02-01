using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Warehouse.DataAccess.Entities.Users;
using Warehouse.Infrasturucture.Extensions;
using Warehouse.Infrasturucture.Utilities.Security.Encryption;

namespace Warehouse.Infrasturucture.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
        private readonly TokenOptions _tokenOptions;
        private readonly DateTime _accessTokenExpiration;

        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            //_tokenOptions = Configuration.GetSection(key: "TokenOptions").Get<TokenOptions>();
            _accessTokenExpiration = DateTime.UtcNow.AddMinutes(_tokenOptions.AccessTokenExpiration);
        }

        public AccessToken CreateToken(ApplicationUser user, IList<Claim> claims)
        {
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signinCredentials = SigninCredentialsHelper.CreateSigninCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signinCredentials, claims);
            var jwtSecurityHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration,
            };
        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, ApplicationUser user, SigningCredentials signingCredentials, IList<Claim> claims)
        {
            var jwt = new JwtSecurityToken
                (
                  issuer: _tokenOptions.Issuer,
                  audience: _tokenOptions.Audience,
                  expires: _accessTokenExpiration,
                  notBefore: DateTime.UtcNow,
                  claims: SetClaims(user, claims),
                  signingCredentials: signingCredentials
                );

            return jwt;
        }

        private IEnumerable<Claim> SetClaims(ApplicationUser user, IList<Claim> claim)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.Name} {user.Surname}");
            claim.AddUserName(user.UserName);
            claims.AddRoles(claim.Select(x => x.Value).ToArray());
            claims.AddId(user.Id.ToString());
            return claims;
        }
    }
}
