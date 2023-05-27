﻿using MvcCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MvcCv.Repostories
{
    public class GenericRepostory<T> where T : class
    {
         DbCvEntities1 db=new DbCvEntities1();

        public List<T> List()
        {
            return db.Set<T>().ToList();
        }
        public void TAdd(T p)
        {
            db.Set<T>().Add(p);
            db.SaveChanges();
        }
        public void TDelete(T p) 
        {
            db.Set<T>().Remove(p);
            db.SaveChanges();
        }
        public T TGet(int id)
        {
            return db.Set<T>().Find(id);
        }
        public void TUpdate(T p) 
        {
            db.SaveChanges();
        }
        public T Find(Expression<Func<T,bool>> where)
        {
            return db.Set<T>().FirstOrDefault(where);
        }
    }
}