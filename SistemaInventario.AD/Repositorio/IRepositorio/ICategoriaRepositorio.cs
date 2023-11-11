using SistemaInventarioV6.Modelos;

namespace SistemaInventarioV6.AD.Repositorio.IRepositorio
{
    public interface ICategoriaRepositorio : IRepositorio<Categoria>
    {
        void Actualizar(Categoria categoria);
    }
}
