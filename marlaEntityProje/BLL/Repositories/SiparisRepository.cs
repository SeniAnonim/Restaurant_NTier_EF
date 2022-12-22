using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class SiparisRepository : IRepository<Sipari>
    {
        MarlaEntities1 db = DBTools.DbInstance;
        public void Delete(int itemId)
        {
            Sipari id = db.Siparis.Find(itemId);
            db.Siparis.Remove(id);
            db.SaveChanges();
        }

        public List<Sipari> GetAll()
        {
            return db.Siparis.ToList();
        }

        public Sipari GetById(int id)
        {
            return db.Siparis.Find(id);
        }

        public void Insert(Sipari item)
        {
            db.Siparis.Add(item);
            db.SaveChanges();
        }

        public void Update(Sipari item)
        {
            Sipari exdata = db.Siparis.Find(item.SiparisID);
            db.Entry(exdata).CurrentValues.SetValues(item);
            db.SaveChanges();
        }
    }
}
