using AppStore.mvvm.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AppStore.mvvm.ViewModels
{
    public class ProductoDetalleViewModel : INotifyPropertyChanged
    {
        private Producto _producto;

        public Producto Producto
        {
            get => _producto;
            set
            {
                _producto = value;
                OnPropertyChanged();
            }
        }

        public ProductoDetalleViewModel()
        {
            // Constructor vacío por si necesitas lógica de inicialización
        }

        public void CargarProducto(Producto producto)
        {
            Producto = producto; // Aquí asignamos el producto a la propiedad pública
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
