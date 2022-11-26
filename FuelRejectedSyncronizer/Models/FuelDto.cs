using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelRejectedSyncronizer.Models
{
    public class FuelDto
    {
        public int Whouse { get; set; }
        public DateTime DtStart { get; set; }
        public DateTime DtStop { get; set; }
        public string FuelType { get; set; }
        public string RsrcCode { get; set; }
        public int Rsrc { get; set; }
        public string RsrcName { get; set; }
        public int Klm { get; set; }
        public double Hours { get; set; }
        public int Users { get; set; }
        public string UserName { get; set; }
        public double QuantStart { get; set; }
        public double QuantStart15 { get; set; }
        public double QuantStop { get; set; }
        public double QuantStop15 { get; set; }
        public double QuantDiff15 { get; set; }
        public double Temp { get; set; }
        public string Ip { get; set; }
        public int Sync { get; set; }
        public double Litres { get; set; }
        public long Pulses { get; set; }
        public double Litres15 { get; set; }
        public double FuelHeightStart { get; set; }
        public double FuelHeightStop { get; set; }
        public double WaterHeight { get; set; }
    }
}
