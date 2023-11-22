using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WD7UVN_HFT_2023241.Models
{
    public class Service
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey(nameof(MaintainerTeam))]
        [Required]
        public int MAINTAINER_ID { get; set; }
        [Required]
        public string NAME { get; set; }
        public int VERSION { get; set; }
        [StringLength(240)]
        public string ACCOUNT { get; set; }
        [StringLength(240)]
        public string NOTES { get; set; }
        [StringLength(240)]
        public string SERVICE_DOMAIN { get; set; }
        [StringLength(240)]
        public string IP { get; set; }
        [StringLength(240)]
        public int PORT { get; set; }
    }
}
