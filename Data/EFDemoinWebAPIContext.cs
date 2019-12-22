using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EFDemoinWebAPI.Model;

namespace EFDemoinWebAPI.Data
{
    public class EFDemoinWebAPIContext : DbContext
    {
        public EFDemoinWebAPIContext (DbContextOptions<EFDemoinWebAPIContext> options)
            : base(options)
        {
        }

        public DbSet<EFDemoinWebAPI.Model.employee> employee { get; set; }
    }
}
