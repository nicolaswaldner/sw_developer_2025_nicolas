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
            var useCount = _context.AppUsers.Count();
            var userList = _context.AppUsers.ToList();
            return userList;
        }

    }
}
