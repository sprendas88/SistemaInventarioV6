using SistemaInventarioV6.AD.Data;
using SistemaInventarioV6.AD.Repositorio.IRepositorio;

namespace SistemaInventarioV6.AD.Repositorio
{
    public class UnidadTrabajo : IUnidadTrabajo
    {
        private readonly ApplicationDbContext _db;
        public IBodegaRepositorio Bodega { get; private set; }

        public UnidadTrabajo(ApplicationDbContext db) 
        { 
            _db = db;
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
