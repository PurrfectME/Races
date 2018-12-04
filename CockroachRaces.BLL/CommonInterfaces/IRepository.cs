﻿namespace CockroachRaces.BLL.CommonInterfaces
{
    public interface IRepository<in T> where T : class
    {
        void Create(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
