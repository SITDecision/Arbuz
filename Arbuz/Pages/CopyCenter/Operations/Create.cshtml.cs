using Arbuz.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Arbuz.Pages.Operations
{
    public class CreateModel : PageModel
    {
        private readonly Arbuz.Data.ApplicationDbContext _context;

        public CreateModel(Arbuz.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Operation Operation { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Operations.Add(Operation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}