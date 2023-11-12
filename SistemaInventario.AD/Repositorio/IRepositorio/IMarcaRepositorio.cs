using SistemaInventarioV6.Modelos;

namespace SistemaInventarioV6.AD.Repositorio.IRepositorio
{
    public interface IMarcaRepositorio : IRepositorio<Marca>
    {
        void Actualizar(Marca categoria);
    }
}
