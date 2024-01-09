using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WD7UVN_HFT_2023241.Models
{
    public class MaintainerTeam
    {
        [Key]
        public int ID {  get; set; }
        [Required]
        public string NAME { get; set; }
        public string EMAIL { get; set; }
        [Required]
        [ForeignKey(nameof(Employee))]
        public int LEADER_ID { get; set; }
    }
}
