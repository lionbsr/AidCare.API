using AidCare.Entities;

namespace AidCare.Business.Abstract
{
    public interface IUserService
    {
        // Tüm kullanıcıları getirir
        List<User> GetAll();

        // ID'ye göre kullanıcıyı getirir
        User? GetById(int id);

        // Yeni kullanıcı ekler
        void Add(User user);

        // Kullanıcıyı günceller
        void Update(User user);

        // Kullanıcıyı siler
        void Delete(int id);
    }
}
