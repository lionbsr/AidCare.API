using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

using System;

namespace AidCare.Entities
{
    public class BloodGlucose
    {
        public int Id { get; set; }
        public int UserId { get; set; } // Foreign Key
        public int GlucoseValue { get; set; }
        private DateTime _measurementTime;

        public DateTime MeasurementTime
        {
            get => _measurementTime;
            set => _measurementTime = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }



        [JsonIgnore]
        public User? User { get; set; }


    }
}
