using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WD7UVN_HFT_2023241.Models
{
    internal class Employee
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public string EMAIL { get; set; }
        public string PHONE { get; set; }
        public int MAINTAINER_ID { get; set; }
        public int MANAGER { get; set; }
    }
}
