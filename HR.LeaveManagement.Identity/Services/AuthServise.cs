using HR.LeaveManagement.Application.Constants;
using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Application.Models.Identity;
using HR.LeaveManagement.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Identity.Services
{
    public class AuthServise : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AuthServise(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
           _signInManager = signInManager;
        }
        public async Task<AuthResponse> Login(AuthRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user==null)
            {
                throw new Exception($"User with {request.Email} not found.");
            }
            var result = await _signInManager.PasswordSignInAsync(user.UserName,request.Password,false,lockoutOnFailure:false);
            if (!result.Succeeded)
            {
                throw new Exception($"Credential for '{request.Email} aren't valid'.");
            }
            AuthResponse response = new AuthResponse
            {
                Id=user.Id,
                Email=request.Email,
                UserName=user.UserName
            };
            return response;    
        }

        public async Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            var existingUser=await _userManager.FindByNameAsync(request.UserName);
            if (existingUser != null)
            {
                throw new Exception($"Username '{request.UserName}' already exists.");
            }

            var user = new ApplicationUser
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                EmailConfirmed = true,
            };

            var existingEmail = await _userManager.FindByEmailAsync(request.Email);
            if (existingEmail==null)
            {
                var result = await _userManager.CreateAsync(user,request.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Employee");
                    await _userManager.AddClaimAsync(user,new System.Security.Claims.Claim(CustomClaimTypes.Uid, user.Id));
                    return new RegistrationResponse() { UserId = user.Id };
                }
                else
                {
                    throw new Exception($"{result.Errors}");
                }
            }
            else
            {
                throw new Exception($"Email {request.Email} already exists."); 
            }
        }
    }
}
