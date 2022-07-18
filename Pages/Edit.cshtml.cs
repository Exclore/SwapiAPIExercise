using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StarWarsAPIExercise.Models;
using StarWarsAPIExercise.DataAccess;

namespace StarWarsAPIExercise.Pages
{
    public class EditModel : PageModel
    {
        private readonly StarshipContext _context;

        public EditModel(StarshipContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Starship Starship { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Starships == null)
            {
                return NotFound();
            }

            var starship =  await _context.Starships.FirstOrDefaultAsync(m => m.Id == id);
            if (starship == null)
            {
                return NotFound();
            }
            Starship = starship;
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

            _context.Attach(Starship).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StarshipExists(Starship.Id))
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

        private bool StarshipExists(int id)
        {
          return (_context.Starships?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
