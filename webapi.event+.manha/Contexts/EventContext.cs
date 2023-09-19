using Microsoft.EntityFrameworkCore;
using webapi.event_.manha.Domains;

namespace webapi.event_.manha.Contexts
{
    public class EventContext : DbContext
    {
        public DbSet<TiposUsuario> TiposUsuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<TiposEvento> TiposEvento { get; set; }
        public DbSet<Evento> Evento { get; set; }
        public DbSet<ComentariosEvento> ComentariosEventos { get; set; }
        public DbSet<Instituicao> Instituicao { get; set; }
        public DbSet<PresencasEvento> PresencasEvento { get; set; }

        //Define as opcoes de construcao do banco(String Conexao)

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE02-S15; DataBase= event+manha; User Id = sa; Pwd = Senai@134; TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
