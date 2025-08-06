using AidCare.Entities;

namespace AidCare.DataAccess.Repositories
{
    public class EfUserRepository : IUserRepository
    {
        private static List<User> _users = new List<User> // Geçici veri
        {
            new User { Id = 1, Name = "Ali", Email = "ali@example.com" },
            new User { Id = 2, Name = "Ayşe", Email = "ayse@example.com" }
        };

        public List<User> GetAll() => _users;

        public User GetById(int id) => _users.FirstOrDefault(u => u.Id == id);

        public void Add(User user) => _users.Add(user);

        public void Update(User user)
        {
            var existing = _users.FirstOrDefault(u => u.Id == user.Id);
            if (existing != null)
            {
                existing.Name = user.Name;
                existing.Email = user.Email;
            }
        }

        public void Delete(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user != null) _users.Remove(user);
        }
    }
}
