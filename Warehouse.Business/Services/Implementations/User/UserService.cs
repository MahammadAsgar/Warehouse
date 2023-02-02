﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Business.Dtos.Get.User;
using Warehouse.Business.Dtos.Post.User;
using Warehouse.Business.Helpers;
using Warehouse.Business.Results;
using Warehouse.Business.Services.Abstractions.User;
using Warehouse.DataAccess.Context;
using Warehouse.DataAccess.Entities.Users;
using Warehouse.DataAccess.Models;
using Warehouse.DataAccess.UnitOfWorks;
using Warehouse.Infrasturucture.Extensions;
using Warehouse.Infrasturucture.Utilities.Security.Jwt;

namespace Warehouse.Business.Services.Implementations.User
{
    public class UserService: IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly WarehouseDbContext _dbContext;
        private readonly ITokenHelper _tokenHelper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISession _session;
        private readonly IMailService _mailService;
        public UserService(UserManager<ApplicationUser> userManager,
                            SignInManager<ApplicationUser> signInManager,
                            IMapper mapper,
                            ITokenHelper tokenHelper,
                            IHttpContextAccessor httpContextAccessor,
                            IUnitOfWork unitOfWork, WarehouseDbContext dbContext,
                            IMailService mailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _tokenHelper = tokenHelper;
            _unitOfWork = unitOfWork;
            _session = httpContextAccessor.HttpContext.Session;
            _dbContext = dbContext;
            _mailService = mailService;
        }

        public async Task<ServiceResult> AddClaim(AddClaimDto addClaim)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(addClaim.UserId);
                var claim = new Claim(addClaim.ClaimType, addClaim.ClaimName);

                if (user == null)
                    return new ServiceResult(false, "user not found");

                var result = await _userManager.AddClaimAsync(user, claim);

                if (result.Succeeded)
                    return new ServiceResult(true, "aded claim successfull");

                return new ServiceResult(false, String.Join(';', result.Errors.Select(x => x.Code)));
            }
            catch (Exception ex)
            {
                return new ServiceResult(false, ex.Message);
            }
        }

        public async Task<ServiceResult> AddUser(RegisterUserDto registerUser)
        {
            var requestData = _mapper.Map<ApplicationUser>(registerUser);
            IdentityResult result = await _userManager.CreateAsync(requestData, "1234dd");

            if (result.Succeeded)
                return new ServiceResult(true, "registration completed");

            return new ServiceResult(false, String.Join(';', result.Errors.Select(x => x.Code)));
        }


        public ServiceResult GetLoggedUser()
        {
            try
            {
                var userData = _session.GetObject<UserSessionDto>("userdetail");
                if (userData == null)
                    return new ServiceResult(false, "data not found");

                return new ServiceResult(true, userData);
            }
            catch (Exception)
            {
                return new ServiceResult(false, "data not found");
            }
        }

        public async Task<ServiceResult> GetUser(string userId)
        {
            try
            {
                var result = await _userManager.FindByIdAsync(userId);

                if (result != null)
                {
                    var response = _mapper.Map<ApplicationUserDto>(result);
                    return new ServiceResult(true, response, "user successfully found");
                }

                return new ServiceResult(false, "user not found");
            }
            catch (Exception ex)
            {
                return new ServiceResult(false, ex.Message);
            }
        }

        public async Task<ServiceResult> GetUsers()
        {
            try
            {
                var users = await _dbContext.Users.ToListAsync();

                if (users != null)
                {
                    var response = _mapper.Map<IEnumerable<ApplicationUserDto>>(users);
                    return new ServiceResult(true, response);
                }

                return new ServiceResult(false, "user not found");
            }
            catch (Exception ex)
            {
                return new ServiceResult(false, ex.Message);
            }
        }

        public async Task<ServiceResult> LogIn(LoginUserDto loginUser)
        {
            try
            {
                ApplicationUser user = await _userManager.FindByNameAsync(loginUser.UserName);

                if (user == null)
                    return new ServiceResult(false, "user not found");

                var result = await _signInManager.PasswordSignInAsync(user, loginUser.Password, true, false);
                var claims = await _userManager.GetClaimsAsync(user);


                var token = _tokenHelper.CreateToken(_mapper.Map<ApplicationUser>(user), claims);
                if (user.EmailConfirmed == false)
                    return new ServiceResult(true, "emailnotverify");
                if (!result.Succeeded)
                {

                    return new ServiceResult(false, "user is login");
                }

                var detail = new UserSessionDto
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    FirstName = user.Name,
                    LastName = user.Surname,
                    Email = user.Email,
                };
                _session.SetObject("userdetail", detail);
                return new ServiceResult(true, token, "login success");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ServiceResult> LogOut()
        {
            try
            {
                await _signInManager.SignOutAsync();

                return new ServiceResult(true, "successfully logout");
            }
            catch (Exception ex)
            {
                return new ServiceResult(false, ex.Message);
            }
        }

        public async Task PasswordResetAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                resetToken = resetToken.UrlEncode();
                await _mailService.SendPasswordResetMail(email, user.UserName, resetToken);



            }

        }
        public async Task<bool> EmailConfirmAsync(string email)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(email);
            var x = 0;
            if (user != null)
            {
                string confirmToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                confirmToken = confirmToken.UrlEncode();
                await _mailService.SendEmailConfirmMail(email, user.UserName, confirmToken);
                return true;
            }
            return false;
        }

        public async Task<ServiceResult> Register(RegisterUserDto registerUser)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(registerUser.Email);
                if (user != null)
                    return new ServiceResult(false, "this email already registered");
                var requestData = _mapper.Map<ApplicationUser>(registerUser);
                IdentityResult result = await _userManager.CreateAsync(requestData, registerUser.Password);

                if (result.Succeeded)
                {
                    return new ServiceResult(true, "registration completed");
                }
                return new ServiceResult(false, String.Join(';', result.Errors.Select(x => x.Code)));
            }
            catch (Exception ex)
            {
                return new ServiceResult(false, ex.Message);
            }
        }

        public async Task<bool> UpdatePassword(string userName, string resetToken, string newPassword)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user != null)
            {
                resetToken = resetToken.UrlDecode();
                IdentityResult result = await _userManager.ResetPasswordAsync(user, resetToken, newPassword);
                if (result.Succeeded)
                {
                    await _userManager.UpdateSecurityStampAsync(user);
                    return true;

                }


                else
                    return false;

            }
            return false;
        }

        public async Task<bool> VerifyConfirmAsync(string userName, string confirmToken)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user != null)
            {
                confirmToken = confirmToken.UrlDecode();
                var result = await _userManager.ConfirmEmailAsync(user, confirmToken);
                if (result.Succeeded)
                    return true;
                else
                    return false;



            }
            return false;
        }

        public async Task<bool> VerifyResetTokenAsync(string resetToken, string UserName)
        {
            var user = await _userManager.FindByNameAsync(UserName);
            if (user != null)
            {
                resetToken = resetToken.UrlDecode();
                return await _userManager.VerifyUserTokenAsync(user, _userManager.Options.Tokens.PasswordResetTokenProvider, "ResetPassword", resetToken);
            }
            return false;
        }

    }
}
