using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracKing.Infrastructure.Repository
{
    public interface IWriteRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void DetectUpdate(T entity);
        void Delete(T entity);
        void Delete(Guid Id);
        void Save();
    }
}
