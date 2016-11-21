namespace DigitalPages.Marvel.Core.Models
{
	public class Comic
	{
		public Comic()
		{

		}

		public Comic(string name, string thumb)
		{
			Thumb = thumb;
			Name = name;
		}

		public string Thumb { get; set; }
		public string Name { get; set; }
	}
}