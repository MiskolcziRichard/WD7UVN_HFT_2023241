using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WD7UVN_HFT_2023241.Models
{
    public class Client
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
		[ForeignKey(nameof(Service))]
        public int SERVICE_ID { get; set; }
    }
}
