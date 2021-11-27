using BlogApp.Infrastructure.Repositories.Interface.BaseRepository;
using BlogApp.Model.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Infrastructure.Repositories.Interface.EntityTypeRepositories
{
    public interface ILikeRepository : IBaseRepository<Like>
    {
    }
}
