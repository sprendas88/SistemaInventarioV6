using SistemaInventarioV6.Modelos;

namespace SistemaInventarioV6.AD.Repositorio.IRepositorio
{
    public interface IBodegaRepositorio : IRepositorio<Bodega>
    {
        void Actualizar(Bodega bodega);
    }
}
