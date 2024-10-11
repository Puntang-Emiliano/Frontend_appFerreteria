using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.mvvm.Models.DTO
{
    public class UsuarioListaDTO
    {
        public int usuario_id { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public string direccion { get; set; }
        public string rol { get; set; }
    }
}
