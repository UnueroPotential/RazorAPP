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
    public class IndexModel : PageModel
    {
        private readonly RazorAPP.Data.ApplicationDbContext _context;

        public IndexModel(RazorAPP.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<MainAdmin> MainAdmin { get;set; }

        public async Task OnGetAsync()
        {
            MainAdmin = await _context.MainAdmins.ToListAsync();
        }
    }
}
