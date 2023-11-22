using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WD7UVN_HFT_2023241.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(240)]
        public string NAME { get; set; }
        [StringLength(240)]
        public string EMAIL { get; set; }
        [StringLength(240)]
        public string PHONE { get; set; }
        [ForeignKey(nameof(MaintainerTeam))]
        public int MAINTAINER_ID { get; set; }
        [ForeignKey(nameof(Employee))]
        public int MANAGER_ID { get; set; }
    }
}
