using Arbuz.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Arbuz.Pages.CopyCenter.Prices
{
    public class DetailsModel : PageModel
    {
        private readonly Arbuz.Data.ApplicationDbContext _context;

        public DetailsModel(Arbuz.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Price Price { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Price = await _context.Prices.Include(p => p.Product).SingleOrDefaultAsync(m => m.Id == id);

            if (Price == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}