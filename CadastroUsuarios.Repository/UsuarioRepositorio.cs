using CadastroUsuarios.Domain;
using CadastroUsuarios.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarios.Repositorio
{
    public class UsuarioRepositorio : IRepositorio<Usuario>
    {
        private readonly CadastroUsuariosDbContext _context;

        public UsuarioRepositorio()
        {
            _context = new CadastroUsuariosDbContext();
        }

        public void Adicionar(Usuario objeto)
        {
            _context.Usuarios.Add(objeto);
            _context.SaveChanges();
        }

        public void Alterar(Usuario objeto)
        {
            var usuario = _context.Usuarios.First(x => x.Id == objeto.Id);
            usuario.Nome = objeto.Nome;
            usuario.Sobrenome = objeto.Sobrenome;
            usuario.Email = objeto.Email;
            usuario.Escolaridade = objeto.Escolaridade;
            usuario.DataNascimento = objeto.DataNascimento;

            _context.SaveChanges();
        }

        public void Excluir(int id)
        {
            var usuario = _context.Usuarios.First(x => x.Id == id);
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
        }

        public Usuario GetById(int id)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public List<Usuario> Listar()
        {
            List<Usuario> usuarios = _context.Usuarios.OrderBy(x => x.Id).ToList();
            return usuarios;
        }
    }
}
