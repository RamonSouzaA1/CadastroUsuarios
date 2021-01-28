using CadastroUsuarios.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarios.Persistence
{
    public class CadastroUsuariosDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
