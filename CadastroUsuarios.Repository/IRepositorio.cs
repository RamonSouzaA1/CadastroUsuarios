using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarios.Repositorio
{
    public interface IRepositorio<TTipo>
    {
        void Adicionar(TTipo objeto);
        void Alterar(TTipo objeto);
        List<TTipo> Listar();
        void Excluir(TTipo objeto);
    }
}
