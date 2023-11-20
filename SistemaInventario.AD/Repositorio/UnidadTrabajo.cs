using SistemaInventarioV6.AD.Data;
using SistemaInventarioV6.AD.Repositorio.IRepositorio;

namespace SistemaInventarioV6.AD.Repositorio
{
    public class UnidadTrabajo : IUnidadTrabajo
    {
        private readonly ApplicationDbContext _db;
        public IBodegaRepositorio Bodega { get; private set; }

        public ICategoriaRepositorio Categoria { get; private set; }

        public IMarcaRepositorio Marca { get; private set; }

        public IProductoRepositorio Producto { get; private set; }

        public UnidadTrabajo(ApplicationDbContext db) 
        { 
            this._db = db;
            this.Bodega = new BodegaRepositorio(_db);
            this.Categoria = new CategoriaRepositorio(_db);
            this.Marca = new MarcaRepositorio(_db); 
            this.Producto = new ProductoRepositorio(_db);
        }

        public void Dispose()
        {
            _db.Dispose(); 
        }

        public async Task Guardar()
        {
            await _db.SaveChangesAsync();
        }
    }
}
