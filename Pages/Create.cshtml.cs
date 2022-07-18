using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StarWarsAPIExercise.Models;
using StarWarsAPIExercise.DataAccess;

namespace StarWarsAPIExercise.Pages
{
    public class CreateModel : PageModel
    {
        private readonly StarshipContext _context;

        public CreateModel(StarshipContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Starship Starship { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Starships == null || Starship == null)
            {
                return Page();
            }

            _context.Starships.Add(Starship);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
