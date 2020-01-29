using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorAPP.Data;

namespace RazorAPP
{
    public class EditModel : PageModel
    {
        private readonly RazorAPP.Data.ApplicationDbContext _context;

        public EditModel(RazorAPP.Data.ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MainStaff).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MainStaffExists(MainStaff.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MainStaffExists(int id)
        {
            return _context.MainStaffs.Any(e => e.Id == id);
        }
    }
}
