// AidCare.Entities/User.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AidCare.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string IdentityNumber { get; set; } = string.Empty;

        [Required]
        private DateTime _birthDate;

        [Required]
        public DateTime BirthDate
        {
            get => _birthDate;
            set => _birthDate = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }


        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        public List<BloodGlucose> BloodGlucoses { get; set; } = new();
    }
}
