using FuelRejectedSyncronizer.CustomServices;
using FuelRejectedSyncronizer.DTO;
using FuelRejectedSyncronizer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelRejectedSyncronizer.RepositoryServices
{
    public class FuelRepository
    {
        private readonly ApplicationDbContext _context;

        public FuelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<FuelDto> GetAll()
        {
            string query = "SELECT * FROM fuellog";
            List<FuelDto> fuelDto = new List<FuelDto>();

            using (SqlConnection conn = new SqlConnection(_context.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        fuelDto.Add(new FuelDto
                        {
                            Whouse = (int)dr["whouse"],
                            DtStart = (DateTime)dr["dt_start"],
                            DtStop = (DateTime)dr["dt_stop"],
                            FuelType = (string)dr["fueltype"],
                            RsrcCode = (string)dr["rsrc_code"],
                            Rsrc = (int)dr["rsrc"],
                            RsrcName = (string)dr["rsrcname"],
                            Klm = (int)dr["klm"],
                            Hours = (double)dr["hours"],
                            Users = (int)dr["users"],
                            UserName = (string)dr["username"],
                            QuantStart = (double)dr["quant_start"],
                            QuantStart15 = (double)dr["quant_start_15"],
                            QuantStop = (double)dr["quant_stop"],
                            QuantStop15 = (double)dr["quant_stop_15"],
                            QuantDiff15 = (double)dr["quant_diff_15"],
                            Temp = dr["temperature"] as double? ?? default(double),
                            Ip = (string)dr["ip"],
                            Sync = (int)dr["sync"],
                            Litres = dr["litres"] as double? ?? default(double),
                            Pulses = (long)dr["pulses"],
                            Litres15 = dr["litres_15"] as double? ?? default(double),
                            FuelHeightStart = dr["fuel_height_start"] as double? ?? default(double),
                            FuelHeightStop = dr["fuel_height_stop"] as double? ?? default(double),
                            WaterHeight = dr["water_height"] as double? ?? default(double)

                        });
                    }
                }
                conn.Close();
                dr.Close();
                
            }
            return fuelDto;
        }

        public void UpdateSyncto1WhereSyncIs3(out int rowsAffected)
        {
            string query = "UPDATE fuellog SET sync = 1 WHERE sync = 3";
            rowsAffected = 0;

            using (SqlConnection conn = new SqlConnection(_context.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);

                conn.Open();
                rowsAffected = command.ExecuteNonQuery();
                conn.Close();
            }
        }

        public bool TestConnection()
        {
            using (SqlConnection conn = new SqlConnection(_context.ConnectionString))
            {
                try
                {
                    conn.Open();
                    conn.Close();
                    return true;
                }
                catch (SqlException e)
                {
                    LogFileService.CreateLogFileAndAppend($"Connection Testing: {e.Message} ({DateTime.Now})");
                    return false;
                }
            }
        }
    }
}
