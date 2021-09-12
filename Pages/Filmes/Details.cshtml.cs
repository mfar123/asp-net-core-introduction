using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FilmesCrud.Models;

namespace FilmesCrud.Pages.Filmes
{
    public class DetailsModel : PageModel
    {
        private readonly FilmesCrud.Models.FilmeContext _context;

        public DetailsModel(FilmesCrud.Models.FilmeContext context)
        {
            _context = context;
        }

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
    }
}
