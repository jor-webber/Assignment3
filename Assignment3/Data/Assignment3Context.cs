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

        public DbSet<Assignment3.Models.Provider> Provider { get; set; }

        public DbSet<W7D2_webAPI.Models.Immunization> Immunization { get; set; }

        public DbSet<W7D2_webAPI.Models.Organization> Organization { get; set; }

        public DbSet<assignment3.Models.Patient> Patient { get; set; }
    }
}
