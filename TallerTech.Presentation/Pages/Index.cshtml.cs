using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TallerTech.Presentation.Data;
using TallerTech.Presentation.Data.Entities;

namespace TallerTech.Presentation.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;
		private readonly TallerDbContext _tallerDbContext;
		public IEnumerable<Car> AllCars { get; set; } = Enumerable.Empty<Car>();

		public IndexModel(TallerDbContext tallerDbContext, ILogger<IndexModel> logger)
		{
			_tallerDbContext = tallerDbContext;
			_logger = logger;
		}


		public async Task OnGetAsync()
		{
			AllCars = await _tallerDbContext.Cars.ToListAsync();
		}
        public async Task<IActionResult> OnPostAsync(int id, int guess)
        {
			AllCars = await _tallerDbContext.Cars.ToListAsync();
			var car = AllCars.ToList().Where(c => c.Id == id).FirstOrDefault();
            if (car != null)
            {
                car.Guess = guess;
                car.Guessed = true;
            }

            return Page();
        }
    }
}