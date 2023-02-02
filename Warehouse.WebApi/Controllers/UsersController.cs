using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Warehouse.Business.Dtos.Post.User;
using Warehouse.Business.Results;
using Warehouse.Business.Services.Abstractions.User;

namespace Warehouse.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetUser([FromBody] string userId)
        {
            return Ok(await _userService.GetUser(userId));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> LogIn(LoginUserDto loginUser)
        {
            return Ok(await _userService.LogIn(loginUser));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> LogOut()
        {
            return Ok(await _userService.LogOut());
        }

        [HttpPost]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ServiceResult>> Register([FromBody] RegisterUserDto registerUser)
        {
            var result = await _userService.Register(registerUser);
            if (result.Success)
            {
                var emailConf = await _userService.EmailConfirmAsync(registerUser.Email);
                if (emailConf)
                {
                    return new ServiceResult(true, "registration completed");
                }
                else
                {
                    throw new Exception();
                }

            }
            return BadRequest();
        }

        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]

        public async Task<ActionResult<ServiceResult>> GetUsers()
        {
            return Ok(await _userService.GetUsers());
        }




        [HttpPost]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]


        public async Task<ActionResult<ServiceResult>> AddClaim(AddClaimDto addClaim)
        {
            return Ok(await _userService.AddClaim(addClaim));
        }

        [HttpGet]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public IActionResult GetLoggedUser()
        {
            return Ok(_userService.GetLoggedUser());
        }
        [HttpPost("password-reset")]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> PasswordReset(string email)
        {
            await _userService.PasswordResetAsync(email);
            return Ok();
        }
        [HttpPost("update-password")]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdatePassword(string userName, string token, string password, string confirmPassword)
        {
            var result = await _userService.UpdatePassword(userName, token, password);
            if (result)
            {
                return Ok(result);
            }
            else
            {

            }
            return BadRequest(result);
        }
        [HttpPost("password-reset-verify")]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> PasswordResetVerify(string resetToken, string userName)
        {
            var response = await _userService.VerifyResetTokenAsync(resetToken, userName);
            return Ok(response);
        }
        [HttpPost]
        [ProducesResponseType(typeof(ServiceResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ConfirmEmail(string userName, string confirmToken)
        {
            var response = await _userService.VerifyConfirmAsync(userName, confirmToken);
            return Ok(response);
        }
    }
}
