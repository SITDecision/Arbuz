using Arbuz.Data;
using Arbuz.Data.Entities;
using Arbuz.DTO;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arbuz.Pages.CopyCenter.Summary
{
    public class SummaryModel : PageModel
    {
        private readonly Arbuz.Data.ApplicationDbContext _context;

        public SummaryModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<OperationInfo> OperationInfoGroupedByDateAndProduct { get; private set; }

        public async Task OnGetAsync()
        {
            var operationsInfo = await _context.Operations
                .Include(o => o.Product)
                .Select(o => GetOperationInfo(o))
                .ToListAsync();
            OperationInfoGroupedByDateAndProduct = (from operation in operationsInfo
                group operation by new {operation.Result.Date, operation.Result.ProductName}
                into gr
                select new OperationInfo
                {
                    Date = gr.Key.Date,
                    ProductName = gr.Key.ProductName,
                    Price = gr.Sum(p => p.Result.Price),
                    Quantity = gr.Sum(p => p.Result.Quantity)
                })?.OrderBy(o => o.Date);
        }

        private async Task<OperationInfo> GetOperationInfo(Operation operation)
        {
            var correspondingPrice = await _context.Prices.OrderByDescending(p => p.Date)
                .FirstOrDefaultAsync(p => p.Date <= operation.Date && p.ProductId == operation.ProductId);
            return
                new OperationInfo
                {
                    Price = correspondingPrice?.Value,
                    Quantity = operation.Quantity,
                    ProductName = operation.Product.Name,
                    Date = operation.Date.ToShortDateString()
                };
        }
    }
}