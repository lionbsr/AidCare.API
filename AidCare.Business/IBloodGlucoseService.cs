using AidCare.Entities;
using System.Collections.Generic;

namespace AidCare.Business.Abstract
{
    public interface IBloodGlucoseService
    {
        void Add(BloodGlucose bloodGlucose);
        void Update(BloodGlucose bloodGlucose);
        void Delete(int id);
        BloodGlucose? GetById(int id);
        List<BloodGlucose> GetByUserId(int userId);
        List<BloodGlucose> GetAll();
    }
}
