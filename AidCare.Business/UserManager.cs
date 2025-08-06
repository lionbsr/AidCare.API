using AidCare.Business.Abstract;
using AidCare.DataAccess;
using AidCare.Entities;
using Microsoft.EntityFrameworkCore;

namespace AidCare.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly AppDbContext _context;

        // Constructor üzerinden context enjekte edilir (dependency injection)
        public UserManager(AppDbContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            // Aynı TC Kimlik Numarası zaten varsa kayıt yapılmaz
            var existingUser = _context.Users.FirstOrDefault(u => u.IdentityNumber == user.IdentityNumber);
            if (existingUser != null)
            {
                throw new Exception("Bu TC kimlik numarasıyla kayıtlı bir kullanıcı zaten var.");
            }

            _context.Users.Add(user);
            _context.SaveChanges();
        }


        public void Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User? GetById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}
