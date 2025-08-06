using System.Collections.Generic;
using System.Linq;
using AidCare.DataAccess.Repositories;
using AidCare.Entities; // User sınıfı burada tanımlı
using Microsoft.EntityFrameworkCore; // DbContext gibi sınıflar burada

namespace AidCare.DataAccess
{
    // IUserRepository arayüzünü uyguluyoruz
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context; // Veritabanı bağlantısı

        // Kurucu metot: dışarıdan veritabanı context'i alır
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        // Kullanıcıyı ID ile bul
        public User? GetById(int id)
        {
            return _context.Users.Find(id);
        }

        // Tüm kullanıcıları getir
        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        // Yeni kullanıcı ekle
        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges(); // Veritabanına kaydet
        }

        // Kullanıcıyı sil
        public void Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        // Kullanıcıyı güncelle
        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}
