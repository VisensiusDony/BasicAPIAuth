using API.Context;
using API.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository
{
    public class GeneralRepository<Context, Entity, Key> : IRepository<Entity, Key>
        where Entity : class
        where Context : MyContext
    {
        private readonly MyContext myContext;
        private readonly DbSet<Entity> entities;
        public GeneralRepository(MyContext myContext)
        {
            this.myContext = myContext;
            entities = myContext.Set<Entity>();
        }
        public int Delete(Key key)
        {
            //throw new NotImplementedException();
            var entity = entities.Find(key);
            if (entity != null)
            {
                myContext.Remove(entity);
                myContext.SaveChanges();
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public IEnumerable<Entity> Get()
        {
            return entities.ToList();
        }

        public Entity Get(Key key)
        {
            return entities.Find(key);
            //return myContext.Employees.Where(e => e.NIK == NIK).SingleOrDefault();
            //return myContext.Employees.Where(e => e.NIK == NIK).FirstOrDefault();
        }

        public int Insert(Entity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            //var empCount = this.Get().Count();
            //var year = DateTime.Now.Year;
            //entity.NIK = year + '0' + empCount.ToString();
            entities.Add(entity);
            myContext.SaveChanges();
            return 0;
        }

        public int Update(Entity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            myContext.Entry(entity).State = EntityState.Modified;
            var result= myContext.SaveChanges();
            return result;
        }
    }
}
