using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class MalzemeRepository : IRepository<Malzeme>
    {
        MarlaEntities1 db = DBTools.DbInstance;
        public void Delete(int itemId)
        {
            Malzeme id = db.Malzemes.Find(itemId);
            db.Malzemes.Remove(id);
            db.SaveChanges();
        }

        public List<Malzeme> GetAll()
        {
            return db.Malzemes.ToList();
        }

        public Malzeme GetById(int id)
        {
            return db.Malzemes.Find(id);
        }

        public void Insert(Malzeme item)
        {
            db.Malzemes.Add(item);
            db.SaveChanges();
        }

        public void Update(Malzeme item)
        {
            Malzeme exdata = db.Malzemes.Find(item.MalzemeID);
            db.Entry(exdata).CurrentValues.SetValues(item);
            db.SaveChanges();
        }
    }
}
