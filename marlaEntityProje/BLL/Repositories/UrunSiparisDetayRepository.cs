using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class UrunSiparisDetayRepository : IRepository<UrunSiparisDetay>
    {
        MarlaEntities1 db = DBTools.DbInstance;
        public void Delete(int itemId)
        {

            UrunSiparisDetay id = db.UrunSiparisDetays.Find(itemId);
            db.UrunSiparisDetays.Remove(id);
            db.SaveChanges();
        }

        public List<UrunSiparisDetay> GetAll()
        {
            return db.UrunSiparisDetays.ToList();
        }

        public UrunSiparisDetay GetById(int id)
        {
            return db.UrunSiparisDetays.Find(id);
        }

        public void Insert(UrunSiparisDetay item)
        {
            db.UrunSiparisDetays.Add(item);
            db.SaveChanges();
        }

        public void Update(UrunSiparisDetay item)
        {
            UrunSiparisDetay exdata = db.UrunSiparisDetays.Find(item.UrunSiparisDetay1);
            db.Entry(exdata).CurrentValues.SetValues(item);
            db.SaveChanges();
        }
    }
}
