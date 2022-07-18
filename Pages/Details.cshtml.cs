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
    public class DetailsModel : PageModel
    {
        private readonly StarshipContext _context;

        public DetailsModel(StarshipContext context)
        {
            _context = context;
        }

      public Starship Starship { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Starships == null)
            {
                return NotFound();
            }

            var starship = await _context.Starships.FirstOrDefaultAsync(m => m.Id == id);
            if (starship == null)
            {
                return NotFound();
            }
            else 
            {
                Starship = starship;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Starships == null)
            {
                return NotFound();
            }
            var starship = await _context.Starships.FindAsync(id);

            if (starship != null)
            {
                Starship = starship;
                _context.Starships.Remove(Starship);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
