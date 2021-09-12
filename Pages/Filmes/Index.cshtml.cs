using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FilmesCrud.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FilmesCrud.Pages.Filmes
{
    public class IndexModel : PageModel
    {
        private readonly FilmesCrud.Models.FilmeContext _context;

        public IndexModel(FilmesCrud.Models.FilmeContext context)
        {
            _context = context;
        }

        public IList<Filmess> Filmes { get;set; }
        public SelectList Generos;
        public string FilmePorGenero {get; set;}

        public async Task OnGetAsync(string buscaPorGeneroNome, string filmePorGenero)
        {
            IQueryable<string> queryGenero = from f in _context.Filmes orderby f.Genero select f.Genero; // select genero from Filmes where filme.genero ==genero; 
            #region Inicio logica input

            var filmes = from f in _context.Filmes select f;// select * from filmes

            if(!String.IsNullOrEmpty(buscaPorGeneroNome))
            {
                filmes = filmes.Where(busca => busca.Titulo.Contains(buscaPorGeneroNome));
            }
            #endregion
            #region Logica Select
            if(!String.IsNullOrEmpty(filmePorGenero))
            {
                filmes = filmes.Where( bf => bf.Genero == filmePorGenero);
            }
            #endregion
            Generos = new SelectList(await queryGenero.Distinct().ToListAsync());
            Filmes = await filmes.ToListAsync();
        }
    }
}
