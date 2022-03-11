using System;
using System.ComponentModel.DataAnnotations;

namespace W7D2_webAPI.Models
{
    public class Organization
    {
        [Key]
        public Guid Id { get; set; }


        [Required]
        public DateTimeOffset CreationTime { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [RegularExpression("Hospital|Clinic|Pharmacy", ErrorMessage = "Only Hospital, Clinic, Pharmacy allowed.")]
        public string Type { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
