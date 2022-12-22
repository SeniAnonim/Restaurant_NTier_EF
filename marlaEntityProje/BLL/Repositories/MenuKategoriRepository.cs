using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class MenuKategoriRepository : IRepository<MenuKategori>
    {
        MarlaEntities1 db = DBTools.DbInstance;
        public void Delete(int itemId)
        {
            MenuKategori id = db.MenuKategoris.Find(itemId);
            db.MenuKategoris.Remove(id);
            db.SaveChanges();
        }

        public List<MenuKategori> GetAll()
        {
            return db.MenuKategoris.ToList();
        }

        public MenuKategori GetById(int id)
        {
            return db.MenuKategoris.Find(id);
        }

        public void Insert(MenuKategori item)
        {
            db.MenuKategoris.Add(item);
            db.SaveChanges();
        }

        public void Update(MenuKategori item)
        {
            MenuKategori exdata = db.MenuKategoris.Find(item.MenuKategoriID);
            db.Entry(exdata).CurrentValues.SetValues(item);
            db.SaveChanges();
        }
    }
}
