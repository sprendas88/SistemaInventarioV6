using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaInventarioV6.Modelos;

namespace SistemaInventarioV6.AD.Repositorio.IRepositorio
{
    public interface IProductoRepositorio : IRepositorio<Producto>
    {
        void Actualizar(Producto producto);

        IEnumerable<SelectListItem> ObtenerTodosDropdownLista(string obj);
    }
}
