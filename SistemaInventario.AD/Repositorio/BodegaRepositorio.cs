using SistemaInventarioV6.AD.Data;
using SistemaInventarioV6.AD.Repositorio.IRepositorio;
using SistemaInventarioV6.Modelos;

namespace SistemaInventarioV6.AD.Repositorio
{
    public class BodegaRepositorio : Repositorio<Bodega>, IBodegaRepositorio
    {
        private readonly ApplicationDbContext _db;

        public BodegaRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        } 
        public void Actualizar(Bodega bodega)
        {
            var BodegaDB = this._db.Bodegas.FirstOrDefault(b => b.Id == bodega.Id);
            if (bodega != null)
            {
                BodegaDB.Nombre = bodega.Nombre;
                BodegaDB.Descripcion = bodega.Descripcion;
                BodegaDB.Estado = bodega.Estado;
                _db.SaveChanges();             
            }
        }
    }
}
