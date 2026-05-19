using SimpleSteps.Data;
using SimpleSteps.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSteps.Business.Services
{
    public class AppUserService
    {
        private readonly AppDbContext _context;

        public AppUserService(AppDbContext context)
        {
            _context = context;
        }

        public List<AppUser> GetAllUsers()
        {
            //var useCount = _context.AppUsers.Count();
            var userList = _context.AppUsers.OrderBy(u=>u.Lastname).ThenBy(u=>u.Name).ToList();
            return userList;
        }

        public AppUser New()
        {
            return new AppUser { Sex = "weiblich", IsActive = true };
        }

        public void Update(AppUser user)
        {

        }

        public void Delete(AppUser user)
        {

        }

        public List<AppUser> Search(string searchValue)
        {
            List<AppUser> userList = new List<AppUser>();

            //contains entspricht einem like %suchbegriff% in SQL
            //startswith entspricht einem like suchbegriff% in SQL
            //endswith entspricht einem like %suchbegriff in SQL
            userList = _context.AppUsers
                        .Where(u => u.Lastname.Contains(searchValue.ToLower()))
                        .OrderBy(u => u.Lastname)
                        .ThenBy(u => u.Name)
                        .ToList();

            return userList;
        }
    }
}
