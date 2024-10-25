using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APP.ACCESODATOS.Data.Repository.IRepository;
using APP.MODELO;

//Es una interfaz que define los repositorios disponibles y el 
//método Save() para guardar los cambios en la base de datos. También extiende IDisposable para liberar recursos.

namespace APP.ACCESODATOS.Data.Repository.IRepository
{
    public interface IContenedorTrabajo :IDisposable
    {
        //Se agregan los repositorios
        ICategoriaRepository Categoria { get; }
        IArticuloRepository Articulo { get; }
        void Save();
       // void Add();
    }
}
