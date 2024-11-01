using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.mvvm.Models.DTO
{
    public class CrearProductoDTO
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
        public int stock { get; set; }
        public int categoriaId { get; set; } 
        
        public string marca { get; set; }
        public string imagen { get; set; }  
    }
}
