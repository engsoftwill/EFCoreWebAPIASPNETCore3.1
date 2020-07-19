using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public interface IRepository
    {
        void Add<T> (T entity) where T : class;
        void Delete<T> (T entity) where T : class;
        void Update<T> (T entity) where T : class;
        bool SaveChanges();
         
    }
}