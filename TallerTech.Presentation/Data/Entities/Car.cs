namespace TallerTech.Presentation.Data.Entities
{
	public class Car
	{
		public int Id { get; set; }
		public string Make { get; set; }
		public string Model { get; set; }
		public int Year { get; set; }
		public int Doors { get; set; }
		public string Color { get; set; }
		public int Price { get; set; }
		public int? Guess { get; set; } = 0;
		public bool? Guessed { get; set; } = false;
	}
}
