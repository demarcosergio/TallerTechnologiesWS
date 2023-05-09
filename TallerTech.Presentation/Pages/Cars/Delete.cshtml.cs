using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TallerTech.Presentation.Data;
using TallerTech.Presentation.Vms;

namespace TallerTech.Presentation.Cars;

public class DeleteModel : PageModel
{
	private readonly TallerDbContext _tallerDbContext;
	public DeleteModel(TallerDbContext tallerDbContext)
	{
        _tallerDbContext = tallerDbContext;
	}

	public string ErrorMessage { get; set; }
	public CarVm? CarVm { get; set; }
	public async Task<IActionResult> OnGetAsync(int id, bool? saveChangesError)
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
		if (saveChangesError ?? false)
		{
			ErrorMessage = $"Error to delete the record id - {id}";
		}
		return Page();
	}

	public async Task<IActionResult> OnPostAsync(int id)
	{
		var recordToDelete = await _tallerDbContext.Cars.FindAsync(id);

		if (recordToDelete == null)
		{
			return Page();
		}

		try
		{
            _tallerDbContext.Cars.Remove(recordToDelete);
			await _tallerDbContext.SaveChangesAsync();
            return Redirect("car/home");
        }
		catch
		{
			return Redirect($"./delete?id={id}&saveChangesError=true");
		}
	}
}