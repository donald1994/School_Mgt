using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using School_Mgt.Data;
using School_Mgt.Model;

namespace School_Mgt.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly School_Mgt.Data.ApplicationDbContext _context;
        [BindProperty]
        public Student Student { get; set; }
        public CreateModel(School_Mgt.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(string userId = null)
        {
            Student = new Student();
            if (userId == null)
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                userId = claim.Value;

            }
            Student.UserId = userId;
            return Page();
        }

       
        [TempData]
        public string StatusMessage { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Student.Add(Student);
            await _context.SaveChangesAsync();
            StatusMessage = "Student has been Successfully Added.";
            return RedirectToPage("Index", new { userId = Student.UserId });
        }
    }
}
