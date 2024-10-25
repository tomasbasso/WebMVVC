using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.MODELO
{
    public class Categoria
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Ingrese nombre de Categoria")]
        [StringLength(50)]
        public string Nombre {get;set;}
        public int ? habilitada {get;set;}

    }
}
