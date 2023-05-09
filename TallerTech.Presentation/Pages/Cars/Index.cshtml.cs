using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TallerTech.Presentation.Data;
using TallerTech.Presentation.Data.Entities;

namespace TallerTech.Presentation.Cars
{
    public class IndexModel : PageModel
    {
        private readonly TallerDbContext _tallerDbContext;
        public IndexModel(TallerDbContext tallerDbContext)
        {
            _tallerDbContext = tallerDbContext;
        }

        //public List<Car> AllCars = new List<Car>();
        public IEnumerable<Car> AllCars { get; set; } = Enumerable.Empty<Car>();

        public async Task<IActionResult> OnGetAsync()
        {
            AllCars = await _tallerDbContext.Cars.ToListAsync();
            return Page();
        }
        //public void OnGet()
        //{
        //    AllCars = _tallerDbContext.Cars.ToList();
        //}
    }
}