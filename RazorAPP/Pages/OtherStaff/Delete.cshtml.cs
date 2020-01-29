using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorAPP.Data;

namespace RazorAPP
{
    public class DeleteModel : PageModel
    {
        private readonly RazorAPP.Data.ApplicationDbContext _context;

        public DeleteModel(RazorAPP.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MainStaff MainStaff { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MainStaff = await _context.MainStaffs.FirstOrDefaultAsync(m => m.Id == id);

            if (MainStaff == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MainStaff = await _context.MainStaffs.FindAsync(id);

            if (MainStaff != null)
            {
                _context.MainStaffs.Remove(MainStaff);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
