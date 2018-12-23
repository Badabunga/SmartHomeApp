using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoggaApp.Domain.Context
{
    public class ConfigContext : DbContext
    {
        public ConfigContext(DbContextOptions options) : base(options)
        {

        }

        
        public DbSet<DbConfig> Configs { get; set; }
    }
}
