﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.RepositoryPattern
{
    public interface IGenericRepository<T> where T:class
    {
        List<T> GetAll();
        List<T> GetCommandByBlogId(int id);
        void Create(T entity);
        void Remove(T entity);
        void Update(T entity);
        T GetById(int id);
       public int GetCountCommentByBlog(int id);
    }
}
