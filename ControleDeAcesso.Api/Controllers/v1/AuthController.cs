using AccessControl.Application.Dto;
using AccessControl.Application.MappingsConfig;
using AccessControl.Core;
using AccessControl.Domain.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AccessControl.Api.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ApiControllerBase
    {
        private readonly SignInManager<User> _signInMangager;
        private readonly UserManager<User> _userManager;    
        private readonly RoleManager<IdentityRole> _roleManager;    
        
        public AuthController(
            SignInManager<User> signInMangager,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            INotifier notifier,
            IUser user
            ) : base(notifier, user)
        {
            _signInMangager = signInMangager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult> Registrar(RegisterUserDto registerUser)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            registerUser.ContaId = ContaId;

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
    }
}
