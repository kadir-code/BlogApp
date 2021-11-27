using BlogApp.Infrastructure.Context;
using BlogApp.Infrastructure.Repositories.Abstract;
using BlogApp.Infrastructure.Repositories.Interface.EntityTypeRepositories;
using BlogApp.Model.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Infrastructure.Repositories.Concrete
{
    public class AppUserRepository : BaseRepository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(DataContext data) : base(data)
        {

        }
    }
}
