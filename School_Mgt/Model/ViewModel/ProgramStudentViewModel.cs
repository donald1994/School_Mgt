using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School_Mgt.Model.ViewModel
{
    public class ProgramStudentViewModel
    {
        public ApplicationUser FacilitorsUserObj { get; set; }
        public IEnumerable<Student> Students { get; set; }
        
    }
}
//i need to see the student details 