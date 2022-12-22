using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class UrunRepository : IRepository<Urun>
    {
        MarlaEntities1 db = DBTools.DbInstance;
        public void Delete(int itemId)
        {
            Urun id = db.Uruns.Find(itemId);
            db.Uruns.Remove(id);
            db.SaveChanges();
        }

        public List<Urun> GetAll()
        {
            return db.Uruns.ToList();
        }

        public Urun GetById(int id)
        {
            return db.Uruns.Find(id);
        }

        public void Insert(Urun item)
        {

            db.Uruns.Add(item);
            db.SaveChanges();
        }

        public void Update(Urun item)
        {
            Urun exdata = db.Uruns.Find(item.UrunID);
            db.Entry(exdata).CurrentValues.SetValues(item);
            db.SaveChanges();
        }
    }
}
