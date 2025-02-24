using CourseManagementAPI.Application.DTOs;
using CourseManagementAPI.Application.Interfaces;
using CourseManagementAPI.Domain.Entities;
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

namespace CourseManagementAPI.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<Trainer> _userManager;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<Trainer> _signInManager;

        public AuthService(UserManager<Trainer> userManager, IConfiguration configuration, SignInManager<Trainer> signInManager)
        {
            _userManager = userManager;
            _configuration = configuration;
            _signInManager = signInManager;
        }

        public string GenerateJwtToken(string username)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Secret"]));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(
            _configuration["Jwt:Issuer"],
            _configuration["Jwt:Audience"],
            claims,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

        public async Task<AuthResponse> LoginTrainerAsync(LoginModel model)
        {
            var trainer = await _userManager.FindByNameAsync(model.Username);
            if (trainer == null || !(await _userManager.CheckPasswordAsync(trainer, model.Password)))
            {
                return new AuthResponse { Success = false, Message = "Invalid username or password." };
            }

            var token = GenerateJwtToken(trainer?.UserName);
            return new AuthResponse { Success = true, Token = token };
        }
        public async Task<AuthResponse> CreateTrainerAsync(CreateTrainerDto model)
        {
            if (await _userManager.FindByNameAsync(model.UserName) != null ||
                await _userManager.FindByEmailAsync(model.Email) != null)
            {
                return new AuthResponse { Success = false, Message = "Username or email already exists." };
            }

            var trainer = new Trainer
            {
                Id = Guid.NewGuid().ToString(),
                UserName = model.UserName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber
            };

            var result = await _userManager.CreateAsync(trainer, model.Password);

            if (!result.Succeeded)
            {
                return new AuthResponse
                {
                    Success = false,
                    Message = string.Join(", ", result.Errors.Select(e => e.Description))
                };
            }
            var token = GenerateJwtToken(trainer.UserName);

            return new AuthResponse { Success = true, Token = token };
        }
    }
}
