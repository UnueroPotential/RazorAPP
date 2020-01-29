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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MainAdmin = await _context.MainAdmins.FindAsync(id);

            if (MainAdmin != null)
            {
                _context.MainAdmins.Remove(MainAdmin);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
