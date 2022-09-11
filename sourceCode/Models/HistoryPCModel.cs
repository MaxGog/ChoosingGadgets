using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.UI.Xaml;

using SQLite;

namespace PC_support.Models
{
    public class HistoryPC
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string type { get; set; }
        public string model { get; set; }
        public string СPU_model { get; set; }
        public string image { get; set; }
        public string ROM_str { get; set; }
        public string OS_str { get; set; }
        public string typeCPU { get; set; } 
        public string VideoCard_model { get; set; }
        public string typeRAM { get; set; }
        public int RAM { get; set; }
        public int ROM { get; set; }
        public int kernels { get; set; }
        public int VideoCard { get; set; }
        private double CPU { get; set; }
    }
}
