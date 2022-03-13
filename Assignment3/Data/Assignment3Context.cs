using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Assignment3.Models;
using W7D2_webAPI.Models;
using assignment3.Models;

namespace Assignment3.Data
{
    public class Assignment3Context : DbContext
    {
        public Assignment3Context (DbContextOptions<Assignment3Context> options)
            : base(options)
        {
        }

        public DbSet<Provider> Provider { get; set; }

        public DbSet<Immunization> Immunization { get; set; }

        public DbSet<Organization> Organization { get; set; }

        public DbSet<Patient> Patient { get; set; }
    }
}
