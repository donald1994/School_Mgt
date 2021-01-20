using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using School_Mgt.Data;
using School_Mgt.Model;
using School_Mgt.Model.ViewModel;

namespace School_Mgt.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly School_Mgt.Data.ApplicationDbContext _context;
        [BindProperty]
        public ProgramStudentViewModel ProgramStudentVM { get; set; }
        [TempData]
        public string StatusMessage { get; set; }
        public IndexModel(School_Mgt.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        // public IList<Student> Student { get;set; }

        public async Task<IActionResult> OnGet(string userId=null)
        {
            if (userId == null)
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                userId = claim.Value;

            }
            ProgramStudentVM = new ProgramStudentViewModel()
            {
                Students = await _context.Student.Where(c => c.UserId == userId).ToListAsync(),
                FacilitorsUserObj = await _context.ApplicationUser.FirstOrDefaultAsync(u => u.Id == userId)
               
            };

            return Page();

        }

    }
}
