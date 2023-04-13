using Microsoft.EntityFrameworkCore;
using OdontoCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdontoCloud.Infrastructure.Context
{
    public class OdontoCloudDBContext: DbContext
    {

        public DbSet<Anamnese> Anamnese { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:odontocloud.database.windows.net,1433;Initial Catalog=OdontoCloud;Persist Security Info=False;User ID=odontocloud@hotmail.com@odontocloud;Password=Od0nt0cl0ud;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

    }
}
