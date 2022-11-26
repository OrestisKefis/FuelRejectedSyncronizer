using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelRejectedSyncronizer.CustomServices
{
    public  class LogFileService
    {
        public static void CreateLogFileAndAppend(string message)
        {
            using (StreamWriter sw = new StreamWriter("./\\FuelLogFile.txt", true))
            {
                sw.WriteLine(message);
                sw.Close();
            }
        }
    }
}
