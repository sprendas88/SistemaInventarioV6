﻿using Microsoft.EntityFrameworkCore;
using SistemaInventarioV6.AD.Data;
using SistemaInventarioV6.AD.Repositorio.IRepositorio;
using SistemaInventarioV6.Modelos.Especificaciones;
using System.Linq.Expressions;

namespace SistemaInventarioV6.AD.Repositorio
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {

        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repositorio(ApplicationDbContext db) {
            _db = db;
            this.dbSet = _db.Set<T>(); 
        }

        public async Task Agregar(T entidad)
        {
            await dbSet.AddAsync(entidad);
        }

        public async Task<T> Obtener(int id)
        {
            return await dbSet.FindAsync(id); 
        }

        public async Task<T> ObtenerPrimero(Expression<Func<T, bool>> ?filtro, string ?incluirPropiedades, bool isTracking = true)
        {
            IQueryable<T> query = dbSet;
            if (filtro != null)
            {
                query = query.Where(filtro);    // select * from where ...
            }
            if (incluirPropiedades != null)
            {
                foreach (var incluirProp in incluirPropiedades.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(incluirProp);   // ejemplo "Categoria, Marca"
                }
            }
            if (!isTracking)
            {
                query = query.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> ObtenerTodos(Expression<Func<T, bool>> filtro = null, Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy = null, string incluirPropiedades = null, bool isTracking = true)
        {
            IQueryable<T> query = dbSet;
            if (filtro != null)
            {
                query = query.Where(filtro);    // select * from where ...
            }
            if (incluirPropiedades != null)
            {
                foreach (var incluirProp in incluirPropiedades.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(incluirProp);   // ejemplo "Categoria, Marca"
                }
            }
            if (OrderBy != null)
            {
                query = OrderBy(query);
            }
            if (!isTracking)
            {
                query = query.AsNoTracking();
            }
            return await query.ToListAsync(); 
        }

        public PageList<T> ObtenerTodosPaginado(Parametros parametros, Expression<Func<T, bool>> filtro = null, Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy = null, string incluirPropiedades = null, bool isTracking = true)
        {
            IQueryable<T> query = dbSet;
            if (filtro != null)
            {
                query = query.Where(filtro);    // select * from where ...
            }
            if (incluirPropiedades != null)
            {
                foreach (var incluirProp in incluirPropiedades.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(incluirProp);   // ejemplo "Categoria, Marca"
                }
            }
            if (OrderBy != null)
            {
                query = OrderBy(query);
            }
            if (!isTracking)
            {
                query = query.AsNoTracking();
            }
            return PageList<T>.toPagedList(query, parametros.PageNumber, parametros.PageSize);
        }

        public void Remover(T entidad)
        {
            dbSet.Remove(entidad);
        }

        public void RemoverRango(IEnumerable<T> entidad)
        {
            dbSet.RemoveRange(entidad);
        }
    }
}
