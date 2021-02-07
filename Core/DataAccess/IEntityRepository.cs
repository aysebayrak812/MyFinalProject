using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{//generic constraint 
    //CLASS REFERANS TİP OLABİLİR
    //IEntity=ya IEntity yada implemente eden bir nesne olabilir
   //new=newlenwbilir olmalı
     public interface IEntityRepository<T>where T:class,IEntity,new()
    {
        //filtreler yazabilmemezi saylıyor 
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void UpDate(T entity);
        void Delete(T entity);

    }
}
