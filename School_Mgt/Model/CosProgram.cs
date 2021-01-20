using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace School_Mgt.Model
{
    public class CosProgram
    {
        public int Id { get; set; }
        public string ProgramName { get; set; }

        public int Credits { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser {get;set; }
    }
}
