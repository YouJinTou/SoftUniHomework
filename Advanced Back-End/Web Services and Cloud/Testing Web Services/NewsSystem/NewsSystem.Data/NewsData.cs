﻿using NewsSystem.Data.Interfaces;
using NewsSystem.Data.Repositories;
using NewsSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace NewsSystem.Data
{
    public class NewsData : INewsContext
    {
        private DbContext context;
        private IDictionary<Type, object> repositories;

        public NewsData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<News> News
        {
            get { return this.GetRepository<News>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public int SaveChangesAsync()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var type = typeof(T);
            if (!this.repositories.ContainsKey(type))
            {
                var typeOfRepository = typeof(GenericRepository<T>);
                var repository = Activator.CreateInstance(
                    typeOfRepository, this.context);

                this.repositories.Add(type, repository);
            }

            return (IRepository<T>)this.repositories[type];
        }
    }
}
