using DAL.Contexts;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UoW
{
    public class UnitofWork : IUnitofWork
    {
        private LinkedinWebPageContext linkedinWebPageContext;
        public UnitofWork(LinkedinWebPageContext _linkedinWebPageContext)
        {
            linkedinWebPageContext = _linkedinWebPageContext;
        }
        public void Dispose()
        {
            linkedinWebPageContext.Dispose();
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(linkedinWebPageContext);
        }

        public int saveChanges()
        {
            return linkedinWebPageContext.SaveChanges();
        }
    }
}
