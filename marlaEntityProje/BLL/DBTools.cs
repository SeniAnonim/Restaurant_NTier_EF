using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DBTools
    {
        private static MarlaEntities1 _dbInstance;
        public static MarlaEntities1 DbInstance
        {
            get
            {
                if (_dbInstance == null)
                {
                    _dbInstance = new MarlaEntities1();
                }
                return _dbInstance;
            }

        }
    }
}
