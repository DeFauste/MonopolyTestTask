using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Database.InMemory.Repositories
{
    public interface IRepository<T, ID>
    {
        void Create(T entity);
        void DeleteById(ID ID);
        T GetById(ID ID);
        IEnumerable<T> GetAll();
        void Update(T entity, T data);
        bool SaveChange();
    }
}
