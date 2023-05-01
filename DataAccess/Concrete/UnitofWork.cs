﻿using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class UnitofWork : IUnitofWork
    {
        private CICRequestContext _context;

        public UnitofWork(CICRequestContext context)
        {
            this._context = context;
            User=new EfUserDal(this._context);
            Request=new EfRequestDal(this._context);
            Category=new EfCategoryDal(this._context);
            CategoryUser=new EfCategoryUserDal(this._context);
            Comment = new EfCommentDal(this._context);
        }

        public IUserDal User { get; private set; }

        public IRequestDal Request { get; private set; }

        public ICategoryDal Category { get; private set; }

        public ICategoryUserDal CategoryUser { get; private set; }
        public ICommentDal Comment { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}
