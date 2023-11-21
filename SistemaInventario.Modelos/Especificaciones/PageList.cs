using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarioV6.Modelos.Especificaciones
{
    public class PageList<T> : List<T>
    {
        public MetaData MetaData { get; set; }

        public PageList(List<T> items, int count, int pageNumber, int pageSize)
        {
            MetaData = new MetaData()
            {
                TotalCount = count,
                PageSize = pageSize,
                TotalPage = (int)Math.Ceiling(count / (double)pageSize) // Por ejemplo 1.5 transforma a 2 
            };
            AddRange(items);
        }

        public static PageList<T> toPagedList(IEnumerable<T> entidad, int pageNumber, int pageSize)
        {
            var count = entidad.Count();
            var items = entidad.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return new PageList<T>(items, count, pageNumber, pageSize);
        
        }
    }
}
