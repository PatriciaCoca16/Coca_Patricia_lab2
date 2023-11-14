using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Coca_Patricia_lab2.Data;
using Coca_Patricia_lab2.Models;

namespace Coca_Patricia_lab2.Pages.Borrowings
{
    public class IndexModel : PageModel
    {
        private readonly Coca_Patricia_lab2.Data.Coca_Patricia_lab2Context _context;

        public IndexModel(Coca_Patricia_lab2.Data.Coca_Patricia_lab2Context context)
        {
            _context = context;
        }

        public IList<Borrowing> Borrowing { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Borrowing != null)
            {
                Borrowing = await _context.Borrowing
                .Include(b => b.Book)
                 .ThenInclude(b => b.Author)

                .Include(b => b.Member).ToListAsync();
            }
        }
    }
}
