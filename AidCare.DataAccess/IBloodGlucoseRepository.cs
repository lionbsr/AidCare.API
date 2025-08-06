using AidCare.Entities;
using System.Collections.Generic;

namespace AidCare.DataAccess.Abstract
{
    public interface IBloodGlucoseRepository
    {
        void Add(BloodGlucose bloodGlucose);
        void Update(BloodGlucose bloodGlucose);
        void Delete(int id);
        List<BloodGlucose> GetAll();
        BloodGlucose? GetById(int id);
        List<BloodGlucose> GetByUserId(int userId);
    }
}
