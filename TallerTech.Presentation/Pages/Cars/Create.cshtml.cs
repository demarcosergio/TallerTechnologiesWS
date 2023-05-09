using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TallerTech.Presentation.Data;
using TallerTech.Presentation.Data.Entities;
using TallerTech.Presentation.Vms;

namespace TallerTech.Presentation.Cars
{
    public class CreateModel : PageModel

    {
        private readonly TallerDbContext _dbContext;
        public CreateModel(TallerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [BindProperty]
        public CarVm CarVm { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            _dbContext.Cars.Add(new Car
            {
                Id = CarVm.Id,
                Make = CarVm.Make,
                Model = CarVm.Model,
                Year = CarVm.Year,
                Doors = CarVm.Doors,
                Color = CarVm.Color,
                Price = CarVm.Price,
                Guess = 0,
                Guessed = false
            });
            await _dbContext.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
}