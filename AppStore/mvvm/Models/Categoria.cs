using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.mvvm.Models
{
    public  class  Categoria
    {

        public int categoria_id { get; set; }
        public string nombre { get; set; }

        // Relación con Productos
        //public ICollection<Producto> Productos { get; set; }
    }
}
