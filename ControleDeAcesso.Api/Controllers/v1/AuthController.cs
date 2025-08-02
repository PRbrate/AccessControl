using AccessControl.Application.Dto;
using AccessControl.Application.MappingsConfig;
using AccessControl.Core;
using AccessControl.Domain.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AccessControl.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ApiControllerBase
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly JwtSettings _jwtSettings;


        public AuthController(
            SignInManager<User> signInMangager,
            UserManager<User> userManager,
            IOptions<JwtSettings> jwtSettings,
            INotifier notifier,
            IUser user
            ) : base(notifier, user)
        {
            _signInManager = signInMangager;
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult> Register(RegisterUserDto registerUser)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            registerUser.ContaId = ContaId;

            if(await _userManager.FindByEmailAsync(registerUser.Email) != null)
            {
                NotifyError("Já existe um usuário com este e-mail");
                return CustomResponse();
            }

            var user = AutoMapperUsers.Map(registerUser);

            var result = await _userManager.CreateAsync(user, registerUser.Password);

            if (result.Succeeded)
            {
                //await RegistrarLog("Patrimonio", $"Incluiu um Registro - {user.UserName}", user);
                return Ok();
            }

            foreach (var error in result.Errors)
            {
                NotifyError(error.Description);
            }

            return CustomResponse();
        }


        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserDtoWithToken>> Login(LoginUserDto loginUser)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var result = await _signInManager.PasswordSignInAsync(loginUser.UserName, loginUser.Password, false, false);

            if (result.Succeeded)
            {
                //await RegistrarLog("Patrimonio", $"Usuário Entrou com Sucesso - {loginUser.Email}", loginUser);
                
                return CustomResponse(await GenerateToken(_appUser.GetUserEmail()));

            }

            if (result.IsLockedOut)
            {
                //await RegistrarLog("Patrimonio", $"Usuário Tentou entrar sem exito - {loginUser.Email}");
                NotifyError("Usuário temporariamente bloqueado por tentativas inválidas");
                return CustomResponse();
            }


            //await RegistrarLog("Patrimonio", $"Usuário Tentou entrar sem exito - {loginUser.Email}");
            NotifyError("Usuário ou Senha incorretos");

            return CustomResponse();
        }

        private async Task<UserDtoWithToken> GenerateToken(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.UserType.ToString()),
                new Claim("UserId", user.Id),
                new Claim("ContaId", user.ContaId.ToString()),

            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = _jwtSettings.Broadcaster,
                Audience = _jwtSettings.Audience,
                Expires = DateTime.UtcNow.AddHours(_jwtSettings.ExpireHours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(securityTokenDescriptor);

            var encodedToken = tokenHandler.WriteToken(token);

            var tokenModel = new UserDtoWithToken
            {
                AccessToken = encodedToken,
                UserDto = user.Map()
            };
            return tokenModel;
        }
    }
}