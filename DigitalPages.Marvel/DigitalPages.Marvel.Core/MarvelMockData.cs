using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitalPages.Marvel.Core.Interfaces;
using DigitalPages.Marvel.Core.Models;

namespace DigitalPages.Marvel.Core
{
	public class MarvelMockData : IMarvelService
	{
		private static ICollection<Character> Items = new List<Character>()
		{
			new Character("Deadpool", 1, "http://i.annihil.us/u/prod/marvel/i/mg/9/50/4ce18691cbf04.jpg", "Formerly known as Emil Blonsky, a spy of Soviet Yugoslavian origin working for the KGB, the Abomination gained his powers after receiving a dose of gamma radiation similar to that which transformed Bruce Banner into the incredible Hulk."),
			new Character("Capitão America", 2, "http://i.annihil.us/u/prod/marvel/i/mg/9/50/4ce18691cbf04.jpg", "Formerly known as Emil Blonsky, a spy of Soviet Yugoslavian origin working for the KGB, the Abomination gained his powers after receiving a dose of gamma radiation similar to that which transformed Bruce Banner into the incredible Hulk."),
			new Character("Homem de Ferro", 3, "http://i.annihil.us/u/prod/marvel/i/mg/9/50/4ce18691cbf04.jpg", "Formerly known as Emil Blonsky, a spy of Soviet Yugoslavian origin working for the KGB, the Abomination gained his powers after receiving a dose of gamma radiation similar to that which transformed Bruce Banner into the incredible Hulk."),
			new Character("Doctor Strange", 4, "http://i.annihil.us/u/prod/marvel/i/mg/9/50/4ce18691cbf04.jpg", "Formerly known as Emil Blonsky, a spy of Soviet Yugoslavian origin working for the KGB, the Abomination gained his powers after receiving a dose of gamma radiation similar to that which transformed Bruce Banner into the incredible Hulk."),
			new Character("Viuva Negra", 5, "http://i.annihil.us/u/prod/marvel/i/mg/9/50/4ce18691cbf04.jpg", "Formerly known as Emil Blonsky, a spy of Soviet Yugoslavian origin working for the KGB, the Abomination gained his powers after receiving a dose of gamma radiation similar to that which transformed Bruce Banner into the incredible Hulk."),
			new Character("Thanos", 6, "http://i.annihil.us/u/prod/marvel/i/mg/9/50/4ce18691cbf04.jpg", "Formerly known as Emil Blonsky, a spy of Soviet Yugoslavian origin working for the KGB, the Abomination gained his powers after receiving a dose of gamma radiation similar to that which transformed Bruce Banner into the incredible Hulk.")
		};

		private static ICollection<Comic> Comics = new List<Comic>()
		{ 
			new Comic("Avengers (1998) #61", "http://i.annihil.us/u/prod/marvel/i/mg/b/40/image_not_available.jpg"),
			new Comic("Doctor Strange, Sorcerer Supreme (1988) #27", "http://i.annihil.us/u/prod/marvel/i/mg/b/40/image_not_available.jpg"),
			new Comic("Doctor Strange, Sorcerer Supreme (1988) #32", "http://i.annihil.us/u/prod/marvel/i/mg/b/40/image_not_available.jpg"),
			new Comic("Infinity Gauntlet (1991)", "http://i.annihil.us/u/prod/marvel/i/mg/b/40/image_not_available.jpg"),
			new Comic("Fear Itself", "http://i.annihil.us/u/prod/marvel/i/mg/b/40/image_not_available.jpg"),
			new Comic("Triumph On Terra-Two", "http://i.annihil.us/u/prod/marvel/i/mg/b/40/image_not_available.jpg"),
			new Comic("You Must Remember This", "http://i.annihil.us/u/prod/marvel/i/mg/b/40/image_not_available.jpg"),
			new Comic("Peril of the Paired Planets", "http://i.annihil.us/u/prod/marvel/i/mg/b/40/image_not_available.jpg"),
		};

		public async Task<ICollection<Character>> GetCharacters(string name = "", int skip = 0, int limit = 20)
		{
			var result = Items.Where(p => p.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) > -1);

			return result.ToList();
		}

		public Task<Character> GetById(long id)
		{
			var result = Items.FirstOrDefault(p => p.Id == id);

			return Task.FromResult(result);
		}

		public async Task<ICollection<Comic>> GetComicsByIdCharacter(long id, int skip = 0, int limit = 20)
		{
			return Comics;
		}
	}
}
