using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class CalisanRepository : IRepository<Calisan>
    {
        MarlaEntities1 db = new MarlaEntities1();
        public void Delete(int itemId)
        {
            Calisan id = db.Calisans.Find(itemId);
            db.Calisans.Remove(id);
            db.SaveChanges();
        }

        public List<Calisan> GetAll()
        {
            return db.Calisans.ToList();
        }

        public Calisan GetById(int id)
        {
            return db.Calisans.Find(id);
        }

        public void Insert(Calisan item)
        {
            db.Calisans.Add(item);
            db.SaveChanges();
        }

        public void Update(Calisan item)
        {
            Calisan exdata = db.Calisans.Find(item.CalisanID);
            db.Entry(exdata).CurrentValues.SetValues(item);
            db.SaveChanges();
        }
    }
}
