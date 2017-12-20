using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindDetayliVeriCekme.DAL
{
  public abstract class DataAccessLayer <T>
    {
        public abstract List<T> List();
        public abstract int Save(T instance);
        public abstract int Update(T instance);
        public abstract int Delete(object instanceID);
    }
}
