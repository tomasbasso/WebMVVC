using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APP.MODELO;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace Web.ViewModels
{
    public class ArticuloMV
    {
        public Articulo Articulo { get; set; }
        public IEnumerable<SelectListItem>? ListaCategorias { get; set; }
    }
}
