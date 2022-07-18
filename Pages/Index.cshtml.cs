using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StarWarsAPIExercise.Models;
using StarWarsAPIExercise.DataAccess;

namespace StarWarsAPIExercise.Pages
{
    public class IndexModel : PageModel
    {
        private readonly StarshipContext _context;
        public int randomNum;

        public IndexModel(StarshipContext context)
        {
            Random rand = new Random();
            randomNum = rand.Next(0, 10);
            _context = context;
        }

        public IList<Starship> Starship { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Starships != null)
            {
                Starship = await _context.Starships.ToListAsync();
            }
        }
    }
}
