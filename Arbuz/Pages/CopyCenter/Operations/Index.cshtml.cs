using Arbuz.Data.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Arbuz.Pages.Operations
{
    public class IndexModel : PageModel
    {
        private readonly Arbuz.Data.ApplicationDbContext _context;

        public IndexModel(Arbuz.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Operation> Operation { get;set; }

        public async Task OnGetAsync()
        {
            Operation = await _context.Operations.Include(o => o.Product).ToListAsync();
        }
    }
}
