using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Warehouse.DataAccess.Entities.Users;

namespace Warehouse.Infrasturucture.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(ApplicationUser user, IList<Claim> claims);
    }
}
