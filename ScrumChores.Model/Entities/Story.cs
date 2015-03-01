using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScrumChores.Model.Entities
{
    public class Story
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid StoryID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Effort { get; set; }
        public Sprint Sprint { get; set; }
        public virtual List<SprintTask> Tasks { get; set; } 
    }
}
