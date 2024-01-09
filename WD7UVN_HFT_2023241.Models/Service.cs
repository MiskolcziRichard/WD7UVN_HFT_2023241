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
        public string VERSION { get; set; }
        public string ACCOUNT { get; set; }
        public string NOTES { get; set; }
        public string SERVICE_DOMAIN { get; set; }
        public string IP { get; set; }
        public int PORT { get; set; }
    }
}
