using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WD7UVN_HFT_2023241.Models
{
    public class Company
    {
        public List<MaintainerTeam> Maintainers { get; set; }
        public List<Client> Customers { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Client> Clients { get; set; }
        public List<Service> Services { get; set; }
    }
}
