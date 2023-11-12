using SistemaInventarioV6.AD.Data;
using SistemaInventarioV6.AD.Repositorio.IRepositorio;
using SistemaInventarioV6.Modelos;

namespace SistemaInventarioV6.AD.Repositorio
{
    public class CategoriaRepositorio : Repositorio<Categoria>, ICategoriaRepositorio
    {
        private readonly ApplicationDbContext _db;

        public CategoriaRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        } 
        public void Actualizar(Categoria categoria)
        {
            var categoriaDB = this._db.Categorias.FirstOrDefault(b => b.Id == categoria.Id);
            if (categoria != null)
            {
                categoriaDB.Nombre = categoria.Nombre;
                categoriaDB.Descripcion = categoria.Descripcion;
                categoriaDB.Estado = categoria.Estado;
                _db.SaveChanges();             
            }
        }
    }
}
