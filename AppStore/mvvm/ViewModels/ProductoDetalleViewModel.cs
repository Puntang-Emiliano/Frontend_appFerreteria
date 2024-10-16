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
          
        }

        public void CargarProducto(Producto producto)
        {
            Producto = producto; 
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
