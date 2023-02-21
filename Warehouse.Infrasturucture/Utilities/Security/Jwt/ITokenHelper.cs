using System.Security.Claims;
using Warehouse.DataAccess.Entities.Users;

namespace Warehouse.Infrasturucture.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(ApplicationUser user, IList<Claim> claims);
    }
}
