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
        public MainAdmin MainAdmin { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MainAdmin = await _context.MainAdmins.FirstOrDefaultAsync(m => m.Id == id);

            if (MainAdmin == null)
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

            _context.Attach(MainAdmin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MainAdminExists(MainAdmin.Id))
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

        private bool MainAdminExists(int id)
        {
            return _context.MainAdmins.Any(e => e.Id == id);
        }
    }
}
