using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using School_Mgt.Data;
using SparkAuto.Models.ViewModel;

namespace School_Mgt.Pages.Facilitator
{
    public class IndexModel : PageModel
    {
        public readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]

        public FacListViewModel FacListVM { get; set; }
        public async Task<IActionResult> OnGet()
        {
            FacListVM = new FacListViewModel()
            {
                ApplicationUserList = await _context.ApplicationUser.ToListAsync()
            };
            return Page();
        }
    }
}
