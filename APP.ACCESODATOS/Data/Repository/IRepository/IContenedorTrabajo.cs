using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.ACCESODATOS.Data.Repository.IRepository
{
    public interface IContenedorTrabajo :IDisposable
    {
        //Se agregan los repositorios
        ICategoriaRepository Categoria { get; }
        void Save();
    }
}
