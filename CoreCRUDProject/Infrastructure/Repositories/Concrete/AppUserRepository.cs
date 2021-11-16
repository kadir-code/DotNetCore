using CoreCRUDProject.Infrastructure.Context;
using CoreCRUDProject.Infrastructure.Repositories.Interface;
using CoreCRUDProject.Models.Entities.Abstract;
using CoreCRUDProject.Models.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CoreCRUDProject.Infrastructure.Repositories.Concrete
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly DataContext _context;
        public AppUserRepository(DataContext dataContext)
        {
            this._context = dataContext;
        }
        public void Create(AppUser entity)
        {
            _context.AppUsers.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(AppUser entity)
        {
            entity.DeleteDate = DateTime.Now;
            entity.Status = Status.Passive;
            _context.SaveChanges();
        }

        public AppUser GetByDefault(Expression<Func<AppUser, bool>> expression)
        {
            return _context.AppUsers.FirstOrDefault(expression);
        }

        public List<AppUser> GetByDefaults(Expression<Func<AppUser, bool>> expression)
        {
            return _context.AppUsers.Where(expression).ToList();
        }

        public void Update(AppUser entity)
        {
            entity.Status = Status.Modified;
            entity.UpdateDate = DateTime.Now;
            _context.SaveChanges();
        }
    }
}
