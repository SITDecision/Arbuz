using Arbuz.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Arbuz.Pages.Operations
{
    public class DetailsModel : PageModel
    {
        private readonly Arbuz.Data.ApplicationDbContext _context;

        public DetailsModel(Arbuz.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
