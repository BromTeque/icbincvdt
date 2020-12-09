using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using icbincvdt.Data;
using icbincvdt.Models;

namespace icbincvdt.Pages.CVs
{
    public class DeleteModel : PageModel
    {
        private readonly icbincvdt.Data.CVContext _context;

        public DeleteModel(icbincvdt.Data.CVContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CV CV { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CV = await _context.CVs.FirstOrDefaultAsync(m => m.CVID == id);

            if (CV == null)
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

            CV = await _context.CVs.FindAsync(id);

            if (CV != null)
            {
                _context.CVs.Remove(CV);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
