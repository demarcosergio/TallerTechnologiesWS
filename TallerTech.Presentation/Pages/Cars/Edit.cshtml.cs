using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TallerTech.Presentation.Data;
using TallerTech.Presentation.Data.Entities;
using TallerTech.Presentation.Vms;

namespace TallerTech.Presentation.Cars;

public class EditModel : PageModel
{
	private TallerDbContext _tallerDbContext;
	public EditModel(TallerDbContext myWorldDbContext)
	{
        _tallerDbContext = myWorldDbContext;
	}

	[BindProperty]
	public CarVm? CarVm { get; set; }

	public async Task<IActionResult> OnGetAsync(int id)
	{
        CarVm = await _tallerDbContext.Cars
				.Where(_ => _.Id == id)
                .Select(c => new CarVm
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    Year = c.Year,
                    Doors = c.Doors,
                    Color = c.Color,
                    Price = c.Price
                })
				.FirstOrDefaultAsync();

		if (CarVm == null)
		{
			return NotFound();
		}
		return Page();
	} 

	public async Task<IActionResult> OnPostAsync(int id)
	{
		var carToUpdate = await _tallerDbContext.Cars.FindAsync(id);

		if (carToUpdate == null)
		{
			return NotFound();
		}

        if (await TryUpdateModelAsync<Car>(
    carToUpdate,
    "CarVm",
    c => c.Id, c => c.Make, c => c.Model, c => c.Year,
    c => c.Doors, c => c.Color, c => c.Price
	))
        {
			await _tallerDbContext.SaveChangesAsync();
			return Redirect("home");
		}

		return Page();
	}
}
