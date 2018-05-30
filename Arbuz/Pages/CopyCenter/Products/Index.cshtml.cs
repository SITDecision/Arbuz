using Arbuz.Data.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Arbuz.Pages.CopyCenter.Products
{
    public class IndexModel : PageModel
    {
        private readonly Arbuz.Data.ApplicationDbContext _context;

        public IndexModel(Arbuz.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }

        public async Task OnGetAsync()
        {
            Product = await _context.Products.ToListAsync();
        }
    }
}
