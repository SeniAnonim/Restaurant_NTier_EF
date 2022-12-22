using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class MusteriRepository : IRepository<Musteri>
    {
        MarlaEntities1 db = DBTools.DbInstance;
        public void Delete(int itemId)
        {
            Musteri id = db.Musteris.Find(itemId);
            db.Musteris.Remove(id);
            db.SaveChanges();
        }

        public List<Musteri> GetAll()
        {
            return db.Musteris.ToList();
        }

        public Musteri GetById(int id)
        {
            return db.Musteris.Find(id);
        }

        public void Insert(Musteri item)
        {
            db.Musteris.Add(item);
            db.SaveChanges();
        }

        public void Update(Musteri item)
        {
            Musteri exdata = db.Musteris.Find(item.MusteriID);
            db.Entry(exdata).CurrentValues.SetValues(item);
            db.SaveChanges();
        }
    }
}
