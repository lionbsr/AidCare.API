using AidCare.DataAccess.Abstract;
using AidCare.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AidCare.DataAccess.Concrete.EntityFramework
{
    public class EfBloodGlucoseRepository : IBloodGlucoseRepository
    {
        private readonly AppDbContext _context;

        public EfBloodGlucoseRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(BloodGlucose bloodGlucose)
        {
            _context.BloodGlucoses.Add(bloodGlucose);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.BloodGlucoses.Find(id);
            if (entity != null)
            {
                _context.BloodGlucoses.Remove(entity);
                _context.SaveChanges();
            }
        }

        public List<BloodGlucose> GetAll()
        {
            return _context.BloodGlucoses.ToList();
        }

        public BloodGlucose? GetById(int id)
        {
            return _context.BloodGlucoses.FirstOrDefault(x => x.Id == id);
        }

        public List<BloodGlucose> GetByUserId(int userId)
        {
            return _context.BloodGlucoses
                           .Where(x => x.UserId == userId)
                           .ToList();
        }

        public void Update(BloodGlucose bloodGlucose)
        {
            _context.BloodGlucoses.Update(bloodGlucose);
            _context.SaveChanges();
        }
    }
}
