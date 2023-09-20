using System.ComponentModel.DataAnnotations;

namespace webapi.event_.manha.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O email do usuário obrigatório!")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "A senha do usuário é obrigatório!")]
        public string? Senha { get; set; }
    }
}
