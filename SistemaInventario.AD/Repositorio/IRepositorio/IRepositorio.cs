using SistemaInventarioV6.Modelos.Especificaciones;
using System.Linq.Expressions;

namespace SistemaInventarioV6.AD.Repositorio.IRepositorio
{
    public interface IRepositorio<T> where T: class
    {
        public Task<T> Obtener(int id);
        public Task<IEnumerable<T>> ObtenerTodos(
            Expression<Func<T, bool>> filtro = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy = null, 
            string incluirPropiedades = null,
            bool isTracking = true
            );

        PageList<T> ObtenerTodosPaginado(Parametros parametros, Expression<Func<T, bool>> filtro = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy = null,
            string incluirPropiedades = null,
            bool isTracking = true
            );

        public Task<T> ObtenerPrimero(
            Expression<Func<T, bool>> filtro = null,
            string incluirPropiedades = null,
            bool isTracking = true
            );


        public Task Agregar(T entidad);

        public void Remover(T entidad);

        public void RemoverRango(IEnumerable<T> entidad); 


    }
}
