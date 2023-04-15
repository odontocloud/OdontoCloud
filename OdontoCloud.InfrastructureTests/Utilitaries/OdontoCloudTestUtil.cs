using Microsoft.EntityFrameworkCore;
using OdontoCloud.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdontoCloud.InfrastructureTests.Utilitaries
{
    public class OdontoCloudUtil
    {
        public static OdontoCloudDBContext GetDbContextInMemory()
        {
            var optionsBuilder = new DbContextOptionsBuilder<OdontoCloudDBContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
            var context = new OdontoCloudDBContext(optionsBuilder.Options);
            return context;
        }
    }
}
