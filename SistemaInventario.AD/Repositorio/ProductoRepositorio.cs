using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaInventarioV6.AD.Data;
using SistemaInventarioV6.AD.Repositorio.IRepositorio;
using SistemaInventarioV6.Modelos;

namespace SistemaInventarioV6.AD.Repositorio
{
    public class ProductoRepositorio : Repositorio<Producto>, IProductoRepositorio
    {
        private readonly ApplicationDbContext _db;

        public ProductoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        } 
        public void Actualizar(Producto producto)
        {
            var ProductoDB = this._db.Productos.FirstOrDefault(b => b.Id == producto.Id);
            if (ProductoDB != null)
            {
                if (producto.ImagenUrl != null)
                {
                    ProductoDB.ImagenUrl = producto.ImagenUrl;
                }
                ProductoDB.NumeroSerie = producto.NumeroSerie;
                ProductoDB.Descripcion = producto.Descripcion;  
                ProductoDB.Precio = producto.Precio;
                ProductoDB.Costo = producto.Costo;
                ProductoDB.CategoriaId = producto.CategoriaId;
                ProductoDB.MarcaId = producto.MarcaId;
                ProductoDB.PadreId = producto.PadreId;
                ProductoDB.Estado = producto.Estado;

                _db.SaveChanges();             
            }
        }

        public IEnumerable<SelectListItem>? ObtenerTodosDropdownLista(string obj)
        {
            if (obj == "Categoria")
            {
                return _db.Categorias.Where(c => c.Estado == true).Select(c => new SelectListItem
                {
                    Text = c.Nombre,
                    Value = c.Id.ToString()
                });
            }
            if (obj == "Marca")
            {
                return _db.Marcas.Where(c => c.Estado == true).Select(c => new SelectListItem
                {
                    Text = c.Nombre,
                    Value = c.Id.ToString()
                });
            }
            if (obj == "Producto")
            {
                return _db.Productos.Where(c => c.Estado == true).Select(c => new SelectListItem
                {
                    Text = c.Descripcion,
                    Value = c.Id.ToString()
                });
            }

            return null;
        }
    }
}
