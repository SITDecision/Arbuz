using Arbuz.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Arbuz.Pages.Operations
{
    public class DeleteModel : PageModel
    {
        private readonly Arbuz.Data.ApplicationDbContext _context;

        public DeleteModel(Arbuz.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Operation = await _context.Operations.FindAsync(id);

            if (Operation != null)
            {
                _context.Operations.Remove(Operation);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
