using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazerPageExercise.Data;

namespace RazerPageExercise.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext db;

        public IndexModel(AppDbContext db)
        {
            this.db = db;
        }

        [BindProperty]
        public IList<Customer> Customers { get; private set; }

        public async Task OnGetAsync()
        {
            this.Customers = await this.db.Customers.AsNoTracking().ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var contact = await this.db.Customers.FindAsync(id);

            if (contact != null)
            {
                this.db.Customers.Remove(contact);
                await this.db.SaveChangesAsync();
            }

            return RedirectToPage();

        }
    }
}