using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.manha.Domains
{
    [Table("PresencasEvento")]
    public class PresencasEvento
    {
        [Key]
        public Guid IdPresencaEvento { get; set; } = Guid.NewGuid();

        [Column(TypeName = "BIT")]
        [Required(ErrorMessage = "Situação obrigatória!")]
        public bool Situacao { get; set; }

        //referência tabela Usuário = FK

        [Required(ErrorMessage = "Usuário obrigatório!")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }

        //Referência da tabela Evento = FK

        [Required(ErrorMessage = "Evento obrigatório!")]
        public Guid IdEvento { get; set; }

        [ForeignKey(nameof(IdEvento))]
        public Evento? Evento { get; set; }
    }
}
