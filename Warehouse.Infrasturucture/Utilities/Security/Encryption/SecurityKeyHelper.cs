using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Warehouse.Infrasturucture.Utilities.Security.Encryption
{
    public static class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
