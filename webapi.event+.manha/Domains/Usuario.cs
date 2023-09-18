using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.manha.Domains
{
    [Table(nameof(Usuario))]
    //Identifica o email como unico
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage ="O nome do usuário obrigatário!")]
        [Column(TypeName = "VARCHAR(100)")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O email do usuário obrigatório!")]
        [Column(TypeName = "VARCHAR(100)")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "A senha do usuário é obrigatório!")]
        [Column(TypeName = "CHAR(60)")]
        [StringLength(60, MinimumLength =6, ErrorMessage ="Senha deve conter de 6 a 60 caracteres")]
        public string? Senha { get; set; }

        //referencia da tabela tiposUsuario = FK
        [Required(ErrorMessage ="Informe o tipo de usuario!")]
        public Guid IdTipoUsuario { get; set; }

        [ForeignKey(nameof(IdTipoUsuario))]
        public TiposUsuario? TiposUsuario { get; set; }
    }
}
