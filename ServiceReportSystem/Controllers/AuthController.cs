using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ServiceReportSystem.Data;
using ServiceReportSystem.DTOs;
using ServiceReportSystem.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ServiceReportSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("signup")]
        public async Task<ActionResult<AuthResponseDto>> SignUp(SignUpDto signUpDto)
        {
            if (signUpDto.Password != signUpDto.ConfirmPassword)
            {
                return BadRequest(new AuthResponseDto
                {
                    Success = false,
                    Message = "Passwords do not match"
                });
            }

            var userExists = await _context.Users.AnyAsync(u => u.Email == signUpDto.Email);
            if (userExists)
            {
                return BadRequest(new AuthResponseDto
                {
                    Success = false,
                    Message = "Email already registered"
                });
            }

            var user = new User
            {
                FirstName = signUpDto.FirstName,
                LastName = signUpDto.LastName,
                Email = signUpDto.Email,
                MobileNo = signUpDto.MobileNo,
                Gender = signUpDto.Gender,
                LoginPassword = BCrypt.Net.BCrypt.HashPassword(signUpDto.Password),
                IsDeleted = false,
                LastLogin = DateTime.Now
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var token = GenerateJwtToken(user);

            return Ok(new AuthResponseDto
            {
                Success = true,
                Message = "User registered successfully",
                Token = token,
                User = MapToUserDto(user)
            });
        }

        [HttpPost("signin")]
        public async Task<ActionResult<AuthResponseDto>> SignIn(SignInDto signInDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == signInDto.Email && !u.IsDeleted);

            if (user == null || !BCrypt.Net.BCrypt.Verify(signInDto.Password, user.LoginPassword))
            {
                return BadRequest(new AuthResponseDto
                {
                    Success = false,
                    Message = "Invalid email or password"
                });
            }

            user.LastLogin = DateTime.Now;
            await _context.SaveChangesAsync();

            var token = GenerateJwtToken(user);

            return Ok(new AuthResponseDto
            {
                Success = true,
                Message = "Login successful",
                Token = token,
                User = MapToUserDto(user)
            });
        }

        [HttpPost("forgot-password")]
        public async Task<ActionResult<AuthResponseDto>> ForgotPassword(ForgotPasswordDto forgotPasswordDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == forgotPasswordDto.Email && !u.IsDeleted);

            if (user == null)
            {
                return BadRequest(new AuthResponseDto
                {
                    Success = false,
                    Message = "User not found"
                });
            }

            // Generate password reset token
            var resetToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
            
            // TODO: Implement email sending logic here
            // For now, we'll just return the token in the response
            return Ok(new AuthResponseDto
            {
                Success = true,
                Message = "Password reset instructions sent to your email",
                Token = resetToken
            });
        }

        [HttpPost("reset-password")]
        public async Task<ActionResult<AuthResponseDto>> ResetPassword(ResetPasswordDto resetPasswordDto)
        {
            if (resetPasswordDto.NewPassword != resetPasswordDto.ConfirmPassword)
            {
                return BadRequest(new AuthResponseDto
                {
                    Success = false,
                    Message = "Passwords do not match"
                });
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == resetPasswordDto.Email && !u.IsDeleted);

            if (user == null)
            {
                return BadRequest(new AuthResponseDto
                {
                    Success = false,
                    Message = "User not found"
                });
            }

            // TODO: Validate reset token
            // For now, we'll just update the password
            user.LoginPassword = BCrypt.Net.BCrypt.HashPassword(resetPasswordDto.NewPassword);
            await _context.SaveChangesAsync();

            return Ok(new AuthResponseDto
            {
                Success = true,
                Message = "Password reset successful"
            });
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserDto MapToUserDto(User user)
        {
            return new UserDto
            {
                ID = user.ID,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                MobileNo = user.MobileNo,
                Gender = user.Gender
            };
        }
    }
}