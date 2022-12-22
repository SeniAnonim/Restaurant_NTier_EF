using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class malzemeKategoriRepository : IRepository<MalzemeKategori>
    {
        MarlaEntities1 db = DBTools.DbInstance;
        public void Delete(int itemId)
        {
            MalzemeKategori id = db.MalzemeKategoris.Find(itemId);
            db.MalzemeKategoris.Remove(id);
            db.SaveChanges();
        }

        public List<MalzemeKategori> GetAll()
        {
            return db.MalzemeKategoris.ToList();
        }

        public MalzemeKategori GetById(int id)
        {
            return db.MalzemeKategoris.Find(id);
        }

        public void Insert(MalzemeKategori item)
        {
            db.MalzemeKategoris.Add(item);
            db.SaveChanges();
        }

        public void Update(MalzemeKategori item)
        {
            MalzemeKategori exdata = db.MalzemeKategoris.Find(item.MalzemeKategoriID);
            db.Entry(exdata).CurrentValues.SetValues(item);
            db.SaveChanges();
        }
    }
}
