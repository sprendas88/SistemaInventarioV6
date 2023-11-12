using SistemaInventarioV6.AD.Data;
using SistemaInventarioV6.AD.Repositorio.IRepositorio;
using SistemaInventarioV6.Modelos;

namespace SistemaInventarioV6.AD.Repositorio
{
    public class MarcaRepositorio : Repositorio<Marca>, IMarcaRepositorio
    {
        private readonly ApplicationDbContext _db;

        public MarcaRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        } 
        public void Actualizar(Marca marca)
        {
            var marcaDB = this._db.Marcas.FirstOrDefault(b => b.Id == marca.Id);
            if (marca != null)
            {
                marcaDB.Nombre = marca.Nombre;
                marcaDB.Descripcion = marca.Descripcion;
                marcaDB.Estado = marca.Estado;
                _db.SaveChanges();             
            }
        }
    }
}
