using Arbuz.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arbuz.Pages.CopyCenter.Prices
{
    public class CreateModel : PageModel
    {
        private readonly Arbuz.Data.ApplicationDbContext _context;

        public CreateModel(Arbuz.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> ProductsForSelect { get; set; }

        public async Task OnGetAsync()
        {
            var products = await _context.Products.ToListAsync();
            ProductsForSelect = products.Select(p => new SelectListItem {Value = p.Id.ToString(), Text = p.Name});
        }

        [BindProperty]
        public Price Price { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Prices.Add(Price);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}