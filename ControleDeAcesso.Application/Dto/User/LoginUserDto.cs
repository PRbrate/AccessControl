using System.ComponentModel.DataAnnotations;

namespace AccessControl.Application.Dto
{
    public class LoginUserDto
    {

        public string UserName { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 8)]
        public string Password { get; set; }
    }
}
