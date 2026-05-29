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
        private readonly IRepository<AppUser> _repository;


        //Urspünglicher Constructur für direkte Verwendung des Context
        //public AppUserService(AppDbContext context)
        //{
        //    _context = context;
        //}

        //Neuer Constructor für die Verwendung des Repositorys
        public AppUserService(IRepository<AppUser> repository)
        {
            _repository = repository;
        }

        //Urspüngliche Methode für die direkte Verwendung des Context
        //public List<AppUser> GetAllUsers()
        //{
        //    //var useCount = _context.AppUsers.Count();
        //    var userList = _context.AppUsers.OrderBy(u=>u.Lastname).ThenBy(u=>u.Name).ToList();
        //    return userList;
        //}

        //Neue Methode für die Verwendung des Repositorys
        public async Task<List<AppUser>> GetAllUsersAsync()
        {
            return await _repository.GetAllAsync();
        }

        public AppUser New()
        {
            return new AppUser { Sex = "weiblich", IsActive = true, Birthday = DateTime.Today };
        }

        public void Add(AppUser user)
        {
            _repository.AddAsync(user);
            _repository.SaveAsync();
        }

        public void Update(AppUser user)
        {
            _repository.Update(user);
            _repository.SaveAsync();
        }

        public void Delete(AppUser user)
        {
            _repository.Delete(user);
            _repository.SaveAsync();
        }



        //Suchmethode vor Umstellung auf Repository
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

        public async Task<List<AppUser>> SearchAsync(string searchValue)
        {
            searchValue = searchValue.ToLower(); //heißt, dass egal ist, ob bei Suche Groß- oder Kleinbuchstaben 
            var userList = await _repository.GetAllByFilter(
                s => 
                (s.Name != null && s.Name.ToLower().Contains(searchValue))
                ||
                (s.Lastname != null && s.Lastname.ToLower().Contains(searchValue))
                );
            return userList;


        }
    }
}
