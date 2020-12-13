using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using icbincvdt.Data;
using icbincvdt.Models;

namespace icbincvdt.Pages.CVs
{
    public class CreateModel : PageModel
    {
        private readonly icbincvdt.Data.CVContext _context;

        public CreateModel(icbincvdt.Data.CVContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CV CV { get; set; }
        
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyCV = new CV();

            if (await TryUpdateModelAsync<CV>(
                emptyCV,
                "CV",
                c => c.Summary))
            {
                _context.CVs.Add(emptyCV);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
