using FuelRejectedSyncronizer.RepositoryServices;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelRejectedSyncronizer.DTO
{
    public class ApplicationDbContext
    {
        public readonly string ConnectionString;

        public ApplicationDbContext()
        {
            ConnectionString = ConfigurationManager.AppSettings.Get("mainContext");
        }
    }
}
