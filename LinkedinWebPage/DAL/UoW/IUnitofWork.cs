using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UoW
{
    public interface IUnitofWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class;
        int saveChanges();
    }
}
