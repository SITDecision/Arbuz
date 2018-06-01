using Arbuz.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arbuz.Pages.Operations
{
    public class EditModel : PageModel
    {
        private readonly Arbuz.Data.ApplicationDbContext _context;

        public EditModel(Arbuz.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> ProductsForSelect { get; set; }

        [BindProperty]
        public Operation Operation { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Operation = await _context.Operations.SingleOrDefaultAsync(m => m.Id == id);

            if (Operation == null)
            {
                return NotFound();
            }
            var products = await _context.Products.ToListAsync();
            ProductsForSelect = products.Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Name });
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Operation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OperationExists(Operation.Id))
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

        private bool OperationExists(int id)
        {
            return _context.Operations.Any(e => e.Id == id);
        }
    }
}
