using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorAPP.Data;

namespace RazorAPP
{
    public class CreateModel : PageModel
    {
        private readonly RazorAPP.Data.ApplicationDbContext _context;

        public CreateModel(RazorAPP.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MainAdmin MainAdmin { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MainAdmins.Add(MainAdmin);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}