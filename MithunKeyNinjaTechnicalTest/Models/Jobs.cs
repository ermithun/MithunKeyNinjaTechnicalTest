using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MithunKeyNinjaTechnicalTest.Models
{
    public class Jobs
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public int RiderId { get; set; }

        [Required]
        public int ReviewScore { get; set; }

        [Required]
        public string ReviewComment { get; set; }

        [Required]
        public DateTime CompletedAt { get; set; }

        [ForeignKey("RiderId")]
        public virtual Rider Rider { get; set; }
    }
}
