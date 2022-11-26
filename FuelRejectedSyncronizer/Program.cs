using FuelRejectedSyncronizer.DTO;
using FuelRejectedSyncronizer.Models;
using FuelRejectedSyncronizer.RepositoryServices;
using System;
using System.Collections.Generic;
using FuelRejectedSyncronizer.CustomServices;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelRejectedSyncronizer
{
    internal class Program
    {
        private static ApplicationDbContext _context = new ApplicationDbContext();
        private static FuelRepository _repo = new FuelRepository(_context);

        static void Main(string[] args)
        {
            int rowsAffected = 0;
            try
            {
                Update(out rowsAffected);
                LogFileService.CreateLogFileAndAppend(rowsAffected > 0 ? $"Successfully updated {rowsAffected} rows ({DateTime.Now})" : rowsAffected == 0 ? $"No rows affected ({DateTime.Now})" : null);
            }
            catch (Exception e)
            {
                LogFileService.CreateLogFileAndAppend($"Fetching Data: {e.Message}");
            }
        }

        private  static void Update(out int rowsAffected)
        {
            rowsAffected = 0;
            if (_repo.TestConnection())
            {
                _repo.UpdateSyncto1WhereSyncIs3(out rowsAffected);
            }
        }

        private static List<FuelDto> Get()
        {
            if (_repo.TestConnection())
            {
                return _repo.GetAll();
            }
            return null;
        }
    }
}
