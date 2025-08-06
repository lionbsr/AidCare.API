using AidCare.Entities;

namespace AidCare.DataAccess.Repositories
{
    public interface IUserRepository// ne yapacagımı söyler ama nasıl yaptıgımı söylemez
    {
        List<User> GetAll();// tüm kullanıcıları getirir
        User? GetById(int id);// belirli bir kullanıcıyı getirir
        void Add(User user);// yeni kullanıcı ekler
        void Update(User user);// kullanıcı bilgilerini günceller
        void Delete(int id);// buarda siler
    }
}
// interfacede ne yapacagından bahseder nasıl yapacagın classlarda olur