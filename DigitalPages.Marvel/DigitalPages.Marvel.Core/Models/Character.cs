using System;
using System.Collections.Generic;

namespace DigitalPages.Marvel.Core.Models
{
	public class Character
	{
		public Character(string name, long id, string avatar, string description)
		{
			Name = name;
			Id = id;
			Avatar = avatar;
			Description = description;
		}

		public Character()
		{

		}

		public string Name { get; set; }
		public long Id { get; set; }
		public string Avatar { get; set; }
		public string Description { get; set; }
		public ICollection<Comic> Comics { get; set; }
	}
}
