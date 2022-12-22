using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class TedarikciRepository : IRepository<Tedarikci>
    {
        MarlaEntities1 db = DBTools.DbInstance;
        public void Delete(int itemId)
        {
            Tedarikci id = db.Tedarikcis.Find(itemId);
            db.Tedarikcis.Remove(id);
            db.SaveChanges();
        }

        public List<Tedarikci> GetAll()
        {
            return db.Tedarikcis.ToList();
        }

        public Tedarikci GetById(int id)
        {
            return db.Tedarikcis.Find(id);
        }

        public void Insert(Tedarikci item)
        {
            db.Tedarikcis.Add(item);
            db.SaveChanges();
        }

        public void Update(Tedarikci item)
        {
            Tedarikci exdata = db.Tedarikcis.Find(item.TedarikciID);
            db.Entry(exdata).CurrentValues.SetValues(item);
            db.SaveChanges();
        }
    }
}
