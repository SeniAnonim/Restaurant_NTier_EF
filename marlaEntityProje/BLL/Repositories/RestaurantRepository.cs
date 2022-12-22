using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class RestaurantRepository : IRepository<Restaurant>
    {
        MarlaEntities1 db = DBTools.DbInstance;
        public void Delete(int itemId)
        {
            Restaurant id = db.Restaurants.Find(itemId);
            db.Restaurants.Remove(id);
            db.SaveChanges();
        }

        public List<Restaurant> GetAll()
        {
            return db.Restaurants.ToList();
        }

        public Restaurant GetById(int id)
        {
            return db.Restaurants.Find(id);
        }

        public void Insert(Restaurant item)
        {
            db.Restaurants.Add(item);
            db.SaveChanges();
        }

        public void Update(Restaurant item)
        {
            Restaurant exdata = db.Restaurants.Find(item.RestaurantID);
            db.Entry(exdata).CurrentValues.SetValues(item);
            db.SaveChanges();
        }
    }
}
