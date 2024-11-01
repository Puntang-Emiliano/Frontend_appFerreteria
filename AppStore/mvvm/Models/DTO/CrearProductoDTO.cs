using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.mvvm.Models.DTO
{
    public class CrearProductoDTO
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int CategoriaId { get; set; } 
        
        public string Marca { get; set; }
        public string Imagen { get; set; }  
    }
}
