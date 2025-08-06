using AidCare.Business.Abstract;
using AidCare.DataAccess.Abstract;
using AidCare.Entities;
using System.Collections.Generic;

namespace AidCare.Business.Concrete
{
    public class BloodGlucoseManager : IBloodGlucoseService
    {
        private readonly IBloodGlucoseRepository _repository;

        public BloodGlucoseManager(IBloodGlucoseRepository repository)
        {
            _repository = repository;
        }

        public void Add(BloodGlucose bloodGlucose)
        {
            _repository.Add(bloodGlucose);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<BloodGlucose> GetAll()
        {
            return _repository.GetAll();
        }

        public BloodGlucose? GetById(int id)
        {
            return _repository.GetById(id);
        }

        public List<BloodGlucose> GetByUserId(int userId)
        {
            return _repository.GetByUserId(userId);
        }

        public void Update(BloodGlucose bloodGlucose)
        {
            _repository.Update(bloodGlucose);
        }
    }
}
