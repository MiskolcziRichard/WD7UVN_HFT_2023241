﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WD7UVN_HFT_2023241.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string NAME { get; set; }
        public string EMAIL { get; set; }
        public string PHONE { get; set; }
        [ForeignKey(nameof(MaintainerTeam))]
        public int? MAINTAINER_ID { get; set; }
        [ForeignKey(nameof(Employee))]
        public int? MANAGER_ID { get; set; }
    }
}
