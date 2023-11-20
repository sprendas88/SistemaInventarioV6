﻿namespace SistemaInventarioV6.AD.Repositorio.IRepositorio
{
    public interface IUnidadTrabajo : IDisposable
    {
        IBodegaRepositorio Bodega { get; }

        ICategoriaRepositorio Categoria { get; }
        IMarcaRepositorio Marca { get; }

        IProductoRepositorio Producto { get; }

        Task Guardar();
    }
}
