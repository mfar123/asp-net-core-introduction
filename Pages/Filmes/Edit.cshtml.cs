using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FilmesCrud.Models;

namespace FilmesCrud.Pages.Filmes
{
    public class EditModel : PageModel
    {
        private readonly FilmesCrud.Models.FilmeContext _context;

        public EditModel(FilmesCrud.Models.FilmeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Filmess Filmes { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Filmes = await _context.Filmes.FirstOrDefaultAsync(m => m.FilmeId == id);

            if (Filmes == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Filmes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmesExists(Filmes.FilmeId))
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

        private bool FilmesExists(int id)
        {
            return _context.Filmes.Any(e => e.FilmeId == id);
        }
    }
}
