using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScrumChores.Model.Entities
{
    public class SprintTask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TaskID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal RemainingHours { get; set; }
        public Story Story { get; set; }
    }
}
