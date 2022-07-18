using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StarWarsAPIExercise.DataAccess;
using StarWarsAPIExercise.Models;

namespace StarWarsAPIExercise.Pages
{
    public class AllProductsModel : PageModel
    {
        private readonly StarWarsAPIExercise.DataAccess.StarshipContext _context;

        public AllProductsModel(StarWarsAPIExercise.DataAccess.StarshipContext context)
        {
            _context = context;
        }

        public IList<Starship> Starship { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Starships != null)
            {
                Starship = await _context.Starships.ToListAsync();
            }
        }
    }
}
