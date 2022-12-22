using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    interface IRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        void Insert(T item);
        void Update(T item);
        void Delete(int itemId);
    }
}
