using ChatWebServer.Models;
using ChatWebServer.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChatWebServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet("/create")]
        public async void create()
        {
            User user = new User { UserName = "govnoGovna" };
            await _userManager.CreateAsync(user, "HuiZaJopuCapnul_500ka_6lya");            
        }
        [HttpGet("/get")]
        public List<User> get()
        {
            return _userManager.Users.ToList();
        }

        [HttpPost("/reg")]
        public async Task<string> register([FromBody] Reg regData)
        {
            User user = new User { UserName = regData.Name, Email = regData.Email };
            // добавляем пользователя
            var result = await _userManager.CreateAsync(user, regData.Password);
            if (result.Succeeded)
            {
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, regData.Name) };
                // создаем JWT-токен
                var jwt = new JwtSecurityToken(
                        issuer: AuthOptions.ISSUER,
                        audience: AuthOptions.AUDIENCE,
                        claims: claims,
                        expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                        signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

                return new JwtSecurityTokenHandler().WriteToken(jwt);
            }
            else
            {
                return result.ToString();
            }
        }
        // POST api/<AuthController>
        [HttpPost("/log")]
        public async Task<string> login([FromBody] Log loginData)
        {
            var us = _userManager.Users.ToList();
            var u = await _userManager.FindByNameAsync(loginData.Username);            
            var ress = await _userManager.CheckPasswordAsync(u, loginData.Password);
            if (ress)
            {
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, u.UserName) };
                // создаем JWT-токен
                var jwt = new JwtSecurityToken(
                        issuer: AuthOptions.ISSUER,
                        audience: AuthOptions.AUDIENCE,
                        claims: claims,
                        expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                        signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

                return new JwtSecurityTokenHandler().WriteToken(jwt);
            } else { return ress.ToString(); }            
        }

        // PUT api/<AuthController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuthController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
