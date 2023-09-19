using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.manha.Domains
{
    [Table("ComentariosEvento")]
    public class ComentariosEvento
    {
        [Key]
        public Guid IdComentarioEvento { get; set; } = Guid.NewGuid();

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "A descrição é obrigatória!")]
        public string? Descricao { get; set; }

        [Column(TypeName = "BIT")]
        [Required(ErrorMessage = "Exibe é obrigatório!")]
        public bool? Exibe { get; set; }


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
