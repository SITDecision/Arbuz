﻿using System.Collections.Generic;
using Arbuz.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Arbuz.Pages.CopyCenter.Prices
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
        public Price Price { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Price = await _context.Prices.SingleOrDefaultAsync(m => m.Id == id);

            if (Price == null)
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

            _context.Attach(Price).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PriceExists(Price.Id))
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

        private bool PriceExists(int id)
        {
            return _context.Prices.Any(e => e.Id == id);
        }
    }
}
