using Microsoft.IdentityModel.Tokens;

namespace Warehouse.Infrasturucture.Utilities.Security.Encryption
{
    public static class SigninCredentialsHelper
    {
        public static SigningCredentials CreateSigninCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        }
    }
}
