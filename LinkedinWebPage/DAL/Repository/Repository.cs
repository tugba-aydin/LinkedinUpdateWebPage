using DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly LinkedinWebPageContext linkedinWebPageContext;
        private readonly DbSet<T> table;
        public Repository(LinkedinWebPageContext _linkedinWebPageContext)
        {
            linkedinWebPageContext = _linkedinWebPageContext;
            table = linkedinWebPageContext.Set<T>();
        }
        public void Add(T entity)
        {
            table.Add(entity);
        }

        public void Delete(int id)
        {
            T entity = table.Find(id);
            table.Remove(entity);
        }

        public List<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(int id)
        {
            return table.Find(id);
        }

        public void Update(T entity)
        {
            table.Attach(entity);
            linkedinWebPageContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
