using CV_Project.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CV_Project.Repositories
{
    
    public class GenericRepository<T> where T : class
    {
        DbCVEntities db= new DbCVEntities();
        
       

        public List<T> GetList()
        {
            return db.Set<T>().ToList();
        }

        public void Insert(T t) 
        {
            db.Set<T>().Add(t);
            db.SaveChanges();
        }
        

        public void Delete(T t) 
        {
        db.Set<T>().Remove(t);
        db.SaveChanges();
        }

        public T GetByID(int id)
        {

            return db.Set<T>().Find(id);
        }

        public void Update(T t) 
        {
            db.SaveChanges();
        }
    }
}